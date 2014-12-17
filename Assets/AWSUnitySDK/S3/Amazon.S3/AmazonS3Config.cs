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

using Amazon.Runtime;

namespace Amazon.S3
{

    /// <summary>
    /// Configuration for accessing AmazonS3 service
    /// </summary>
    public class AmazonS3Config : ClientConfig
    {
        private bool forcePathStyle = false;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AmazonS3Config()
        {
            this.AuthenticationServiceName = "s3";
#if BCL45
            // Set Timeout and ReadWriteTimeout for S3 to max timeout as per-request
            // timeouts are not supported.
            this.Timeout = ClientConfig.MaxTimeout;
            this.ReadWriteTimeout = ClientConfig.MaxTimeout;
#elif (WIN_RT || WINDOWS_PHONE)
            // Only Timeout property is supported for WinRT and Windows Phone.
            // Set Timeout for S3 to max timeout as per-request
            // timeouts are not supported.
            this.Timeout = ClientConfig.MaxTimeout;
#endif
        }

        /// <summary>
        /// The constant used to lookup in the region hash the endpoint.
        /// </summary>
        internal override string RegionEndpointServiceName
        {
            get
            {
                return "s3";
            }
        }

        /// <summary>
        /// Gets the ServiceVersion property.
        /// </summary>
        public override string ServiceVersion
        {
            get
            {
                return "2006-03-01";
            }
        }

        /// <summary>
        /// When true, requests will always use path style addressing.
        /// </summary>
        public bool ForcePathStyle
        {
            get { return forcePathStyle; }
            set { forcePathStyle = value; }
        }
    }
}

    
