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
using System.Xml.Serialization;
using System.Text;

using Amazon.Runtime;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Returns information about the  GetBucketCors response and response metadata.
    /// </summary>
    public class GetCORSConfigurationResponse : AmazonWebServiceResponse
    {
        private CORSConfiguration configuration;

        /// <summary>
        /// The current CORSConfiguration for the bucket.
        /// </summary>
        public CORSConfiguration Configuration
        {
            get { return this.configuration; }
            set { this.configuration = value; }
        }

        // Check to see if Configuration property is set
        internal bool IsSetConfiguration()
        {
            return this.configuration != null;
        }
    }
}
    
