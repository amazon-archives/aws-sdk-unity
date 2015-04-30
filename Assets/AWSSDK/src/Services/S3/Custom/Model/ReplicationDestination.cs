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
using System.Linq;
using System.Text;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Destination configuration for a replication rule.
    /// </summary>
    public class ReplicationDestination
    {
        private string bucketArn;

        /// <summary>
        /// The Amazon Resource Name (ARN) of the bucket to which replicas are sent.
        /// </summary>
        public string BucketArn
        {
            get { return this.bucketArn; }
            set { this.bucketArn = value; }
        }

        /// <summary>
        /// Checks to see if BucketArn property is set.
        /// </summary>
        /// <returns>true if BucketArn property is set.</returns>
        internal bool IsSetBucketArn()
        {
            return !System.String.IsNullOrEmpty(this.bucketArn);
        }
    }
}
