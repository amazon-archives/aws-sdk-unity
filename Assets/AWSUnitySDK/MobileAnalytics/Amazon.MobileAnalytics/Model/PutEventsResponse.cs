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

namespace Amazon.MobileAnalytics.Model
{
    /// <summary>
    /// Configuration for accessing Amazon PutEvents service
    /// </summary>
    public partial class PutEventsResponse : PutEventsResult
    {
        /// <summary>
        /// Gets and sets the PutEventsResult property.
        /// Represents the output of a PutEvents operation.
        /// </summary>
        [Obsolete(@"This property has been deprecated. All properties of the PutEventsResult class are now available on the PutEventsResponse class. You should use the properties on PutEventsResponse instead of accessing them through PutEventsResult.")]
        public PutEventsResult PutEventsResult
        {
            get
            {
                return this;
            }
        }
    }
}