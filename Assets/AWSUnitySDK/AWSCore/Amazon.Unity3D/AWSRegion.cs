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
using UnityEngine;
using System.Collections;
using System;


namespace Amazon.Unity3D
{
    public enum AWSRegion
    {
        /// <summary>
        /// The US East (Virginia) endpoint.
        /// </summary>
        USEast1 = 0,

        /// <summary>
        /// The US West (N. California) endpoint.
        /// </summary>
        USWest1 = 1,

        /// <summary>
        /// The US West (Oregon) endpoint.
        /// </summary>
        USWest2 = 2,

        /// <summary>
        /// The EU West (Ireland) endpoint.
        /// </summary>
        EUWest1 = 3,

        /// <summary>
        /// The Asia Pacific (Tokyo) endpoint.
        /// </summary>
        APNortheast1 = 4,

        /// <summary>
        /// The Asia Pacific (Singapore) endpoint.
        /// </summary>
        APSoutheast1 = 5,

        /// <summary>
        /// The Asia Pacific (Sydney) endpoint.
        /// </summary>
        APSoutheast2 = 6,

        /// <summary>
        /// The South America (Sao Paulo) endpoint.
        /// </summary>
        SAEast1 = 7,

        /// <summary>
        /// The US GovCloud West (Oregon) endpoint.
        /// </summary>
        USGovCloudWest1 = 8,

        /// <summary>
        /// The China (Beijing) endpoint.
        /// </summary>
        CNNorth1 = 9,
    }

    public static class AWSRegionExtension 
    {
        public static Amazon.RegionEndpoint GetRegionEndpoint(this AWSRegion region)
        {
            Amazon.RegionEndpoint ret;
            switch(region)
            {
                case AWSRegion.USEast1:
                    ret = Amazon.RegionEndpoint.USEast1;
                    break;
                    
                case AWSRegion.USWest1:
                    ret = Amazon.RegionEndpoint.USWest1;
                    break;
                    
                case AWSRegion.USWest2:
                    ret = Amazon.RegionEndpoint.USWest2;
                    break;
                    
                case AWSRegion.EUWest1:
                    ret = Amazon.RegionEndpoint.EUWest1;
                    break;
                    
                case AWSRegion.APNortheast1:
                    ret = Amazon.RegionEndpoint.APNortheast1;
                    break;
                    
                case AWSRegion.APSoutheast1:
                    ret = Amazon.RegionEndpoint.APSoutheast1;
                    break;
                    
                case AWSRegion.APSoutheast2:
                    ret = Amazon.RegionEndpoint.APSoutheast2;
                    break;
                    
                case AWSRegion.SAEast1:
                    ret = Amazon.RegionEndpoint.SAEast1;
                    break;
                    
                case AWSRegion.USGovCloudWest1:
                    ret = Amazon.RegionEndpoint.USGovCloudWest1;
                    break;
                    
                case AWSRegion.CNNorth1:
                    ret = Amazon.RegionEndpoint.CNNorth1;
                    break;
                    
                default:
                    throw new Exception("no corresponding AWS region is found when convert AWSRegion to Amazon.RegionEndpoint !");
                    
            }
            return ret;
        }
    }
}