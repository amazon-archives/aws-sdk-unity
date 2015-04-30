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
    /// Returns information about the  GetBucketNotification response and response metadata.
    /// </summary>
    public class GetBucketNotificationResponse : AmazonWebServiceResponse
    {
        List<TopicConfiguration> _topicConfigurations;
        /// <summary>
        /// Gets and sets the TopicConfigurations property. TopicConfigurations are configuration 
        /// for Amazon S3 events to be sent to Amazon SNS topics.
        /// </summary>
        public List<TopicConfiguration> TopicConfigurations 
        {
            get
            {
                if (this._topicConfigurations == null)
                    this._topicConfigurations = new List<TopicConfiguration>();

                return this._topicConfigurations;
            }
            set
            {
                this._topicConfigurations = value;
            }
        }

        List<QueueConfiguration> _queueConfigurations;
        /// <summary>
        /// Gets and sets the QueueConfigurations property. QueueConfigurations are configuration 
        /// for Amazon S3 events to be sent to Amazon SQS queues.
        /// </summary>
        public List<QueueConfiguration> QueueConfigurations
        {
            get
            {
                if (this._queueConfigurations == null)
                    this._queueConfigurations = new List<QueueConfiguration>();

                return this._queueConfigurations;
            }
            set
            {
                this._queueConfigurations = value;
            }
        }

        List<CloudFunctionConfiguration> _cloudFunctionConfigurations;
        /// <summary>
        /// Gets and sets the CloudFunctionConfigurations property. CloudFunctionConfigurations are configuration 
        /// for Amazon S3 events to be sent to an Amazon Lambda cloud function.
        /// </summary>
        public List<CloudFunctionConfiguration> CloudFunctionConfigurations
        {
            get
            {
                if (this._cloudFunctionConfigurations == null)
                    this._cloudFunctionConfigurations = new List<CloudFunctionConfiguration>();

                return this._cloudFunctionConfigurations;
            }
            set
            {
                this._cloudFunctionConfigurations = value;
            }
        }

    }
}
    
