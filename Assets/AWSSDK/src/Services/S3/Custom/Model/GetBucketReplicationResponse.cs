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
    /// Returns information about the  GetReplicationConfiguration response and response metadata.
    /// </summary>
    public class GetBucketReplicationResponse : AmazonWebServiceResponse
    {
        private ReplicationConfiguration configuration;

        /// <summary>
        /// The replication configuration for the buccket specified in the request.
        /// </summary>
        public ReplicationConfiguration Configuration
        {
            get
            {
                if (this.configuration == null)
                    this.configuration = new ReplicationConfiguration();

                return this.configuration;
            }
            set { this.configuration = value; }
        }
    }
}
