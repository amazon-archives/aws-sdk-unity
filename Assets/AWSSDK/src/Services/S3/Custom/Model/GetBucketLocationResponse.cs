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
    /// Returns information about the GetBucketLocation response and response metadata.
    /// </summary>
    public class GetBucketLocationResponse : AmazonWebServiceResponse
    {
        private string location;

        /// <summary>
        /// Gets and sets the Location property.
        /// If the the bucket is located in us-east-1 S3Region.US will be return which has a 
        /// value of empty string.
        /// </summary>
        public S3Region Location
        {
            get { return this.location; }
            set { this.location = value; }
        }
    }
}
    
