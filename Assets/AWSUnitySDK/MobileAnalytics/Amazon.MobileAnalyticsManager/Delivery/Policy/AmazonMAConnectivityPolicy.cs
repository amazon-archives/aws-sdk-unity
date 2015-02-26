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
using System.Net;

using UnityEngine;

using Amazon.MobileAnalytics;
using Amazon.Unity3D;

namespace Amazon.MobileAnalyticsManager.Delivery
{
    public class AmazonMAConnectivityPolicy:IAmazonMADeliveryPolicy
    {
        private readonly bool IsDataAllowed;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.Delivery.AmazonMAConnectivityPolicy"/> class.
        /// </summary>
        /// <param name="IsDataAllowed">If set to <c>true</c> polciy will allow the delivery on data network.</param>
        public AmazonMAConnectivityPolicy (bool IsDataAllowed)
        {
            this.IsDataAllowed = IsDataAllowed;
        }

        /// <summary>
        /// Determines whether this policy allows the delivery of the events or not
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        public bool IsAllowed ()
        {
            return this.HasNetworkConnectivity ();
        }
        
        /// <summary>
        /// Call back to policy once the delivery has been completed
        /// </summary>
        /// <param name="isSuccessful">If set to <c>true</c> successful.</param>
        public void HandleDeliveryAttempt (bool isSuccessful)
        {
            //do nothing
        }
        
        /// <summary>
        /// Determines whether this instance has network connectivity.
        /// </summary>
        /// <returns><c>true</c> if this instance has network connectivity; otherwise, <c>false</c>.</returns>
        private bool HasNetworkConnectivity ()
        {
            NetworkReachability networkReachability = AmazonNetworkStatusInfo.Reachability;
            bool networkFlag = false;
            switch (networkReachability) {
                case NetworkReachability.NotReachable:
                    networkFlag = false;
                    break;
                case NetworkReachability.ReachableViaLocalAreaNetwork:
                    networkFlag = true;
                    break;
                case NetworkReachability.ReachableViaCarrierDataNetwork:
                    networkFlag = IsDataAllowed;
                    break;
            }
            return networkFlag;
        }
        
        }
}