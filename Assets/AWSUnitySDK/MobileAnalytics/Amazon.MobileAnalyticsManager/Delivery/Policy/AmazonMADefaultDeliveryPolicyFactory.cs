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
using Amazon.MobileAnalytics;
using Amazon.MobileAnalyticsManager;

namespace Amazon.MobileAnalyticsManager.Delivery
{
    public class AmazonMADefaultDeliveryPolicyFactory:IAmazonMADeliveryPolicyFactory
    {
        private readonly bool IsDataNetworkAllowed;
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.Delivery.AmazonMADefaultDeliveryPolicyFactory"/> class.
        /// </summary>
        /// <param name="IsDataNetworkAllowed">If set to <c>true</c> connectivity policy will allow delivery on data network.</param>
        public AmazonMADefaultDeliveryPolicyFactory (bool IsDataNetworkAllowed)
        {
            this.IsDataNetworkAllowed = IsDataNetworkAllowed;
        }
        
        /// <summary>
        /// returns a new connectivity policy.
        /// </summary>
        /// <returns>instance of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/>, which checks for network connectivity</returns>
        public IAmazonMADeliveryPolicy NewConnectivityPolicy()
        {
            return new AmazonMAConnectivityPolicy(this.IsDataNetworkAllowed);
        }
        
        
        /// <summary>
        /// returns a new force submission time policy
        /// </summary>
        /// <returns>instance of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/></returns>
        public IAmazonMADeliveryPolicy NewForceSubmissionPolicy()
        {
            return new AmazonMASubmissionTimePolicy(AmazonMobileAnalyticsManager.Config.FORCE_SUBMISSION_WAIT_TIME);
        }
        
        
        /// <summary>
        /// returns a new force submission time policy
        /// </summary>
        /// <returns>instance of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/></returns>
        public IAmazonMADeliveryPolicy NewBackgroundSubmissionPolicy()
        {
            return new AmazonMASubmissionTimePolicy(AmazonMobileAnalyticsManager.Config.BACKGROUND_SUBMISSION_WAIT_TIME);;
        }
    
    }
}

