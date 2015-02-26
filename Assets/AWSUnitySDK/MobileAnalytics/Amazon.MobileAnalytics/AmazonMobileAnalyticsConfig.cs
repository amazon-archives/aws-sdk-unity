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

using Amazon.Runtime;


namespace Amazon.MobileAnalytics
{
    /// <summary>
    /// Configuration for accessing Amazon MobileAnalytics service
    /// </summary>
    public partial class AmazonMobileAnalyticsConfig : ClientConfig
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AmazonMobileAnalyticsConfig()
        {
            this.AuthenticationServiceName = "mobileanalytics";
            if (this.RegionEndpoint == null)
                this.RegionEndpoint = RegionEndpoint.USEast1;
        }

        /// <summary>
        /// The constant used to lookup in the region hash the endpoint.
        /// </summary>
        internal override string RegionEndpointServiceName
        {
            get
            {
                return "mobileanalytics";
            }
        }

        /// <summary>
        /// Gets the ServiceVersion property.
        /// </summary>
        public override string ServiceVersion
        {
            get
            {
                return "2014-06-30";
            }
        }
    }
}