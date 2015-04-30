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
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Container for the parameters to the PutBucketNotification operation.
    /// <para>Enables notifications of specified events for a bucket.</para>
    /// </summary>
    public partial class PutBucketNotificationRequest : AmazonWebServiceRequest
    {
        public string BucketName { get; set; }

        // Check to see if Bucket property is set
        internal bool IsSetBucketName()
        {
            return this.BucketName != null;
        }

        /// <summary>
        /// Gets and sets the TopicConfigurations property. TopicConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SNS topics.
        /// </summary>
        public List<TopicConfiguration> TopicConfigurations {get; set;}

        internal bool IsSetTopicConfigurations()
        {
            return this.TopicConfigurations != null && TopicConfigurations.Count > 0;
        }

        /// <summary>
        /// Gets and sets the QueueConfigurations property. QueueConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SQS queues.
        /// </summary>
        public List<QueueConfiguration> QueueConfigurations { get; set; }

        internal bool IsSetQueueConfigurations()
        {
            return this.QueueConfigurations != null && QueueConfigurations.Count > 0;
        }


        /// <summary>
        /// Gets and sets the CloudFunctionConfigurations property. CloudFunctionConfigurations are configuration for 
        /// Amazon S3 events to be sent to an Amazon Lambda cloud function.
        /// </summary>
        public List<CloudFunctionConfiguration> CloudFunctionConfigurations { get; set; }

        internal bool IsSetCloudFunctionConfigurations()
        {
            return this.CloudFunctionConfigurations != null && CloudFunctionConfigurations.Count > 0;
        }
    }
}
    
