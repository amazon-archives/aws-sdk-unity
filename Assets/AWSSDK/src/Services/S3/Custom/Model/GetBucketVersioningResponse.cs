//
// Copyright 2014-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
//
//
// Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
// You may not use this file except in compliance with the License.
// A copy of the License is located in the "license" file accompanying this file.
// See the License for the specific language governing permissions and limitations under the License.
//
//

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

using Amazon.Runtime;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Returns information about the  GetBucketVersioning response and response metadata.
    /// </summary>
    public class GetBucketVersioningResponse : AmazonWebServiceResponse
    {
        private S3BucketVersioningConfig config;

        /// <summary>
        /// Gets and sets the Versioning property.
        /// Unless Versioning has been explicitly "Enabled" on a bucket,
        /// Versioning Status is "Off". Once Versioning has been 
        /// "Enabled", it can be "Suspended" but cannot be switched "Off".
        /// </summary>
        public S3BucketVersioningConfig VersioningConfig
        {
            get 
            {
                if (this.config == null)
                    this.config = new S3BucketVersioningConfig();

                return this.config; 
            }
            set { this.config = value; }
        }
    }
}
    
