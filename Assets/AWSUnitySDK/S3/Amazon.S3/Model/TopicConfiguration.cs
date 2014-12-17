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
using System.IO;

namespace Amazon.S3.Model
{
    /// <summary>Topic Configuration
    /// </summary>
    public class TopicConfiguration
    {
        /// <summary>
        /// Bucket event for which to send notifications.
        /// </summary>
        public string Event { get; set; }

        // Check to see if Event property is set
        internal bool IsSetEvent()
        {
            return this.Event != null;
        }

        /// <summary>
        /// Amazon SNS topic to which Amazon S3 will publish a message to report the specified events for the bucket.
        /// </summary>
        public string Topic { get; set; }

        // Check to see if Topic property is set
        internal bool IsSetTopic()
        {
            return this.Topic != null;
        }
    }
}
