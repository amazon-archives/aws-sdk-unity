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
using System.Threading;

using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using System.Collections.Generic;
using Amazon.S3.Util;
using Amazon.Unity3D;
using UnityEngine;
using System.Globalization;
using System.Collections;
using System.Text;
using System.IO;

namespace Amazon.S3
{
    /// <summary>
    /// Implementation for accessing AmazonS3.
    ///  
    /// 
    /// </summary>
    public partial class AmazonS3Client : AmazonWebServiceClient, IAmazonS3
    {
        S3Signer signer = new S3Signer ();

        #region Dispose

        protected override void Dispose (bool disposing)
        {
            base.Dispose (disposing);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs AmazonS3Client with the credentials loaded from the application's
        /// default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.
        /// 
        /// Example App.config with credentials set. 
        /// <code>
        /// &lt;?xml version="1.0" encoding="utf-8" ?&gt;
        /// &lt;configuration&gt;
        ///     &lt;appSettings&gt;
        ///         &lt;add key="AWSProfileName" value="AWS Default"/&gt;
        ///     &lt;/appSettings&gt;
        /// &lt;/configuration&gt;
        /// </code>
        ///
        /// </summary>
        public AmazonS3Client ()
            : base(FallbackCredentialsFactory.GetCredentials(), new AmazonS3Config(), AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with the credentials loaded from the application's
        /// default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.
        /// 
        /// Example App.config with credentials set. 
        /// <code>
        /// &lt;?xml version="1.0" encoding="utf-8" ?&gt;
        /// &lt;configuration&gt;
        ///     &lt;appSettings&gt;
        ///         &lt;add key="AWSProfileName" value="AWS Default"/&gt;
        ///     &lt;/appSettings&gt;
        /// &lt;/configuration&gt;
        /// </code>
        ///
        /// </summary>
        /// <param name="region">The region to connect.</param>
        public AmazonS3Client (RegionEndpoint region)
            : base(FallbackCredentialsFactory.GetCredentials(), new AmazonS3Config() { RegionEndpoint = region }, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with the credentials loaded from the application's
        /// default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.
        /// 
        /// Example App.config with credentials set. 
        /// <code>
        /// &lt;?xml version="1.0" encoding="utf-8" ?&gt;
        /// &lt;configuration&gt;
        ///     &lt;appSettings&gt;
        ///         &lt;add key="AWSProfileName" value="AWS Default"/&gt;
        ///     &lt;/appSettings&gt;
        /// &lt;/configuration&gt;
        /// </code>
        ///
        /// </summary>
        /// <param name="config">The AmazonS3 Configuration Object</param>
        public AmazonS3Client (AmazonS3Config config)
            : base(FallbackCredentialsFactory.GetCredentials(), config, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Credentials
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        public AmazonS3Client (AWSCredentials credentials)
            : this(credentials, new AmazonS3Config())
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Credentials
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="region">The region to connect.</param>
        public AmazonS3Client (AWSCredentials credentials, RegionEndpoint region)
            : this(credentials, new AmazonS3Config() { RegionEndpoint = region })
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Credentials and an
        /// AmazonS3Client Configuration object.
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="clientConfig">The AmazonS3Client Configuration Object</param>
        public AmazonS3Client (AWSCredentials credentials, AmazonS3Config clientConfig)
            : base(credentials, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonS3Config())
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="region">The region to connect.</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonS3Config() { RegionEndpoint = region })
        {
            //Debug.Log("I am in S3 constructor");
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID, AWS Secret Key and an
        /// AmazonS3Client Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="clientConfig">The AmazonS3Client Configuration Object</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey, AmazonS3Config clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonS3Config())
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="region">The region to connect.</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonS3Config() { RegionEndpoint = region })
        {
        }

        /// <summary>
        /// Constructs AmazonS3Client with AWS Access Key ID, AWS Secret Key and an
        /// AmazonS3Client Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="clientConfig">The AmazonS3Client Configuration Object</param>
        public AmazonS3Client (string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonS3Config clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        #endregion

        #region GetObject

        /// <summary>
        /// Get S3 Object
        /// This fucntion can only be called in main thread
        /// </summary>
        /// <param name="GetObjectRequest"> Get Object request </param>
        /// <param name="callback"> Call back function is fired after async operation is completed </param>
        public void GetObjectAsync (GetObjectRequest request, AmazonServiceCallback callback, object state)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new Exception ("AWSPrefab is not added to the scene");

            ThreadPool.QueueUserWorkItem (new WaitCallback (delegate
            {
                var marshaller = new GetObjectRequestMarshaller ();
                var unmarshaller = GetObjectResponseUnmarshaller.GetInstance ();
                Invoke (request, callback, state, marshaller, unmarshaller, signer);
            }));
            return;
        }

        #endregion



        #region ListObjects

        /// <summary>
        /// List all objects in bucket
        /// This fucntion can only be called in main thread
        /// </summary>
        /// <param name="ListObjectsRequest"> List Object request </param>
        /// <param name="callback"> Call back function is fired after async operation is completed </param>
        public void ListObjectsAsync (ListObjectsRequest request, AmazonServiceCallback callback, object state)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new Exception ("AWSPrefab is not added to the scene");

            ThreadPool.QueueUserWorkItem (new WaitCallback (delegate
            {
                var marshaller = new ListObjectsRequestMarshaller ();
                var unmarshaller = ListObjectsResponseUnmarshaller.GetInstance ();
                Invoke (request, callback, state, marshaller, unmarshaller, signer);
            }));
            return;
        }

        #endregion


        #region ListBuckets
        /// <summary>
        /// List all s3 bucket
        /// This fucntion can only be called in main thread
        /// </summary>
        /// <param name="ListBucketsRequest"> List Bucket request </param>
        /// <param name="callback"> Call back function is fired after async operation is completed </param>
        public void ListBucketsAsync (ListBucketsRequest request, AmazonServiceCallback callback, object state)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new Exception ("AWSPrefab is not added to the scene");

            ThreadPool.QueueUserWorkItem (new WaitCallback (delegate
            {
                var marshaller = new ListBucketsRequestMarshaller ();
                var unmarshaller = ListBucketsResponseUnmarshaller.GetInstance ();
                Invoke (request, callback, state, marshaller, unmarshaller, signer);
            }));
            return;
        }

        #endregion


        #region PostBuckets

        /// <summary>
        /// Post S3 Object
        /// This fucntion can only be called in main thread
        /// </summary>
        /// <param name="S3PostUploadRequest"> Post Object request </param>
        /// <param name="callback"> Call back function is fired after async operation is completed </param>
        public void PostObjectAsync (PostObjectRequest request, AmazonServiceCallback callback, object state)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new Exception ("AWSPrefab is not added to the scene");
            
            ThreadPool.QueueUserWorkItem (new WaitCallback (delegate
            {
                InvokeS3Post (request, callback, state);
            }));
            return;
        }

        #endregion

    }
}

