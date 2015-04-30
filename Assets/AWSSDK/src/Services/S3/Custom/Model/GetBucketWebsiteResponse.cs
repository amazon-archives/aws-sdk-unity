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
    /// Returns information about the  GetBucketWebsite response and response metadata.
    /// </summary>
    public class GetBucketWebsiteResponse : AmazonWebServiceResponse
    {
        WebsiteConfiguration websiteConfiguration;

        /// <summary>
        /// Gets and sets the WebsiteConfiguration property.
        /// 
        /// This is where the index document suffix and custom error page are defined.
        /// </summary>
        public WebsiteConfiguration WebsiteConfiguration
        {
            get { return this.websiteConfiguration; }
            set { this.websiteConfiguration = value; }
        }

    }
}
    
