/*
 * Copyright 2014-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 *
 * Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located in the "license" file accompanying this file.
 * See the License for the specific language governing permissions and limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Util;
using Amazon.Runtime.Internal.Util;
using Amazon.Unity3D;
using System.Collections;
using UnityEngine;
using Amazon.S3.Util;
using System.Text;
using System.Xml;
using Amazon.CognitoIdentity;

namespace Amazon.Runtime
{
    /// <summary>
    /// A base class for service clients that handles making the actual requests
    /// and possibly retries if needed.
    /// </summary>
    public abstract partial class AmazonWebServiceClient : AbstractWebServiceClient
    {

        #region S3PostObject

        protected void InvokeS3Post(PostObjectRequest publicrequest, AmazonServiceCallback callback, object state)
        {
            AsyncResult asyncResult = new AsyncResult(new DefaultRequest(publicrequest, "Amazon.S3"),
                                                      publicrequest, callback,
                                                      state, new S3Signer(), null);

            try
            {

                asyncResult.Metrics.StartEvent(Metric.ClientExecuteTime);
                asyncResult.Request.Endpoint = DetermineEndpoint(asyncResult.Request);
                if (Config.LogMetrics)
                {
                    asyncResult.Metrics.IsEnabled = true;
                    asyncResult.Metrics.AddProperty(Metric.ServiceName, asyncResult.Request.ServiceName);
                    asyncResult.Metrics.AddProperty(Metric.ServiceEndpoint, asyncResult.Request.Endpoint);
                    asyncResult.Metrics.AddProperty(Metric.MethodName, asyncResult.RequestName);
                    asyncResult.Metrics.AddProperty(Metric.AsyncCall, !asyncResult.CompletedSynchronously);
                }
                //ConfigureRequest(asyncResult);

                InvokeHelperForS3PostObject(asyncResult, publicrequest);
            }
            catch (Exception e)
            {
                AmazonLogging.LogException("S3", e);
                asyncResult.IsCompleted = true;
                asyncResult.HandleException(e);
                return;
            }
            //return asyncResult;
        }
        
        private void InvokeHelperForS3PostObject(AsyncResult asyncResult, PostObjectRequest request)
        {

            if (asyncResult.RetriesAttempt == 0 || Config.ResignRetries)
            {
                // Add Post policy
                if (request.PostPolicy == null)
                {
                    int position = request.Key.LastIndexOf('.');
                    string ext = null, contentType = null;
                    if (position != -1)
                    {
                        ext = request.Key.Substring(position, request.Key.Length - position);
                        contentType = AmazonS3Util.MimeTypeFromExtension(ext);
                    } 
                    else
                    {
                        contentType = "application/octet-stream";
                    }
                    request.PostPolicy = S3PostPolicyBuilder.GetPostPolicy(request.Bucket, request.Key, contentType);
                }
                
                
                
                if (Credentials is CognitoAWSCredentials)
                {
                    var cred = Credentials as CognitoAWSCredentials;
                    // very hacky solution
                    cred.GetCredentialsAsync(delegate(AmazonServiceResult voidResult)
                    {
                        if (voidResult.Exception != null)
                        {
                            asyncResult.IsCompleted = true;
                            AmazonLogging.LogError("CognitoAWSCredentials", voidResult.Exception.Message);
                            asyncResult.HandleException(voidResult.Exception);
                            return;
                        }
                        request.SignedPolicy = S3PostUploadSignedPolicy.GetSignedPolicy(request.PostPolicy, cred);
                        ProcessS3PostRequest(asyncResult, request);
                    }, null);
                    return;
                }
                request.SignedPolicy = S3PostUploadSignedPolicy.GetSignedPolicy(request.PostPolicy, Credentials);
            }

            ProcessS3PostRequest(asyncResult, request);
        }

        private void ProcessS3PostRequest(AsyncResult asyncResult, PostObjectRequest request)
        {
            try
            {
                WWWRequestData requestData = new WWWRequestData();
                string subdomain = request.Region.Equals(RegionEndpoint.USEast1) ? "s3" : "s3-" + request.Region.SystemName;

                if (request.Bucket.IndexOf('.') > -1)
                    requestData.Url = string.Format(CultureInfo.InvariantCulture, "http://{0}.amazonaws.com/{1}/", subdomain, request.Bucket);
                else
                    requestData.Url = string.Format(CultureInfo.InvariantCulture, "http://{0}.{1}.amazonaws.com", request.Bucket, subdomain);


                // prepare WWW          
                var boundary = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace('=', 'z');
                requestData.Headers.Add(HeaderKeys.ContentTypeHeader, string.Format(CultureInfo.InvariantCulture, "multipart/form-data; boundary={0}", boundary));
#if !UNITY_WEBPLAYER
                requestData.Headers.Add(HeaderKeys.UserAgentHeader, UNITY_USER_AGENT);
#endif

                // append upload data

                using (var reqStream = new MemoryStream())
                {
                    request.WriteFormData(boundary, reqStream);

                    byte[] boundaryBytes = Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "--{0}\r\nContent-Disposition: form-data; name=\"file\"\r\n\r\n", boundary));

                    reqStream.Write(boundaryBytes, 0, boundaryBytes.Length);

                    using (var inputStream = null == request.Path ? request.InputStream : File.OpenRead(request.Path))
                    {
                        byte[] buf = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = inputStream.Read(buf, 0, 1024)) > 0)
                        {
                            reqStream.Write(buf, 0, bytesRead);
                        }
                    }

                    byte[] endBoundaryBytes = Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "\r\n--{0}--", boundary));

                    reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                    AmazonLogging.LogDebug("S3", requestData.Url);

                    requestData.Data = reqStream.ToArray();
                }
                AmazonLogging.LogDebug("S3", Encoding.Default.GetString(requestData.Data));

                asyncResult.RequestData = requestData;
                asyncResult.WaitCallback = ProcessS3PostResponse;

                // switching to main thread
                AmazonMainThreadDispatcher.QueueAWSRequest(asyncResult);
            }
            catch (Exception e)
            {
                AmazonLogging.LogError("S3", e.Message);
                asyncResult.IsCompleted = true;
                asyncResult.HandleException(e);
                return;
            }
        }

        private void ProcessS3PostResponse(object state)
        {
            AsyncResult asyncResult = null;
            try
            {
                asyncResult = state as AsyncResult;
                asyncResult.ServiceResult.HttpResponseData = asyncResult.ResponseData;
                
                S3PostUploadResponse response = new S3PostUploadResponse();

                WWWResponseData responseData = asyncResult.ResponseData;

                if (!String.IsNullOrEmpty(responseData.Error) || !String.IsNullOrEmpty(System.Text.Encoding.UTF8.GetString(responseData.GetBytes())))
                {

                    AmazonLogging.LogError("S3", responseData.Error);
                    foreach (string key in responseData.GetHeaderNames())
                    {
                        AmazonLogging.LogDebug("S3", key + " : " + responseData.GetHeaderValue(key));
                    }

                    if (asyncResult.Exception == null)
                    {
                        asyncResult.Exception = new AmazonServiceException("Bad Request");
                    }

                    asyncResult.IsCompleted = true;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    asyncResult.ServiceResult.Response = response;
                    AmazonLogging.LogError("S3", "RetriesAttempt exceeded");
                    asyncResult.HandleException(asyncResult.Exception);

                    return;
                }
                else
                {
                    asyncResult.IsCompleted = true;
                    response.StatusCode = HttpStatusCode.NoContent;
                    asyncResult.ServiceResult.Response = response;
                    asyncResult.InvokeCallback();
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                asyncResult.HandleException(e);
                return;
            }
        }
        #endregion
    }
}
