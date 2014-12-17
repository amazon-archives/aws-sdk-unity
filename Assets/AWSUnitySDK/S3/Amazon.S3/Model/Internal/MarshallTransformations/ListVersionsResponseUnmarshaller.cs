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
using System.Net;
using System.Collections.Generic;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    ///    Response Unmarshaller for ListVersions operation
    /// </summary>
    internal class ListVersionsResponseUnmarshaller : S3ReponseUnmarshaller
    {
        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {   
            ListVersionsResponse response = new ListVersionsResponse();
            
            while (context.Read())
            {
                if (context.IsStartElement)
                {                    
                    UnmarshallResult(context,response);                        
                    continue;
                }
            }
                 
                        
            return response;
        }
        
        private static void UnmarshallResult(XmlUnmarshallerContext context,ListVersionsResponse response)
        {
            
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("IsTruncated", targetDepth))
                    {
                        response.IsTruncated = BoolUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("KeyMarker", targetDepth))
                    {
                        response.KeyMarker = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Delimiter", targetDepth))
                    {
                        response.Delimiter = StringUnmarshaller.GetInstance().Unmarshall(context);

                        continue;
                    } 
                    if (context.TestExpression("VersionIdMarker", targetDepth))
                    {
                        response.VersionIdMarker = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("NextKeyMarker", targetDepth))
                    {
                        response.NextKeyMarker = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("NextVersionIdMarker", targetDepth))
                    {
                        response.NextVersionIdMarker = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Version", targetDepth))
                    {
                        response.Versions.Add(VersionsItemUnmarshaller.GetInstance().Unmarshall(context));
                            
                        continue;
                    }
                    if (context.TestExpression("DeleteMarker", targetDepth))
                    {
                        var version = VersionsItemUnmarshaller.GetInstance().Unmarshall(context);
                        version.IsDeleteMarker = true;
                        response.Versions.Add(version);
                            
                        continue;
                    }
                    if (context.TestExpression("Name", targetDepth))
                    {
                        response.Name = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Prefix", targetDepth))
                    {
                        response.Prefix = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("MaxKeys", targetDepth))
                    {
                        response.MaxKeys = IntUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("CommonPrefixes", targetDepth))
                    {
                        var prefix = CommonPrefixesItemUnmarshaller.GetInstance().Unmarshall(context);

                        if (prefix != null)
                            response.CommonPrefixes.Add(prefix);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return;
                }
            }
                            


            return;
        }
        
        public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            S3ErrorResponse errorResponse = S3ErrorResponseUnmarshaller.GetInstance().Unmarshall(context);

            return new AmazonS3Exception(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode, errorResponse.Id2);
        }
        
        private static ListVersionsResponseUnmarshaller instance;

        public static ListVersionsResponseUnmarshaller GetInstance()
        {
            if (instance == null) 
            {
               instance = new ListVersionsResponseUnmarshaller();
            }
            return instance;
        }
    
    }
}
    
