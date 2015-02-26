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

namespace Amazon.MobileAnalyticsManager.Delivery
{
    public interface IAmazonMADeliveryPolicy
    {
        /// <summary>
        /// Determines whether this policy allows the delivery of the events or not
        /// </summary>
        /// <returns><c>true</c> if this policy allows the delivery of events; otherwise, <c>false</c>.</returns>
        bool IsAllowed();
        
        
        /// <summary>
        /// Call back to policy once the delivery has been completed
        /// </summary>
        /// <param name="isSuccessful">Set to <c>true</c> on successful delivery of events; otherwise <c>false</c>.</param>
        void HandleDeliveryAttempt(bool isSuccessful);
    }
}

