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

using Amazon.MobileAnalytics.Model;
using Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Unity3D;
using UnityEngine;

namespace Amazon.MobileAnalytics
{
    /// <summary>
    /// Implementation for accessing MobileAnalytics
    ///
    /// A service which is used to record Amazon Mobile Analytics events
    /// </summary>
    public partial class AmazonMobileAnalyticsClient : AmazonWebServiceClient, IAmazonMobileAnalytics
    {
        AWS4Signer signer = new AWS4Signer();

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Constructors

		/// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Credentials
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="region">The region to connect.</param>
        public AmazonMobileAnalyticsClient(AWSCredentials credentials, RegionEndpoint region)
            : this(credentials, new AmazonMobileAnalyticsConfig{RegionEndpoint = region})
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Credentials and an
        /// AmazonMobileAnalyticsClient Configuration object.
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="clientConfig">The AmazonMobileAnalyticsClient Configuration Object</param>
        public AmazonMobileAnalyticsClient(AWSCredentials credentials, AmazonMobileAnalyticsConfig clientConfig)
            : base(credentials, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonMobileAnalyticsConfig())
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="region">The region to connect.</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonMobileAnalyticsConfig() {RegionEndpoint=region})
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID, AWS Secret Key and an
        /// AmazonMobileAnalyticsClient Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="clientConfig">The AmazonMobileAnalyticsClient Configuration Object</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, AmazonMobileAnalyticsConfig clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonMobileAnalyticsConfig())
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="region">The region to connect.</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonMobileAnalyticsConfig{RegionEndpoint = region})
        {
        }

        /// <summary>
        /// Constructs AmazonMobileAnalyticsClient with AWS Access Key ID, AWS Secret Key and an
        /// AmazonMobileAnalyticsClient Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="clientConfig">The AmazonMobileAnalyticsClient Configuration Object</param>
        public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonMobileAnalyticsConfig clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, clientConfig, AuthenticationTypes.User | AuthenticationTypes.Session)
        {
        }

        #endregion

        
        #region  PutEvents


        /// <summary>
        /// Initiates the asynchronous execution of the PutEvents operation.
        /// <seealso cref="Amazon.MobileAnalytics.IAmazonMobileAnalytics"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the PutEvents operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void PutEventsAsync(PutEventsRequest request, AmazonServiceCallback callback, object state)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new Exception("Missing AWSPrefab, Add the AWSPrefab to the current scene");

            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                var marshaller = new PutEventsRequestMarshaller();
                var unmarshaller = PutEventsResponseUnmarshaller.Instance;
                Invoke(request, callback, state, marshaller, unmarshaller, signer);
            }));
            return;
        }


        #endregion
        
    }
}