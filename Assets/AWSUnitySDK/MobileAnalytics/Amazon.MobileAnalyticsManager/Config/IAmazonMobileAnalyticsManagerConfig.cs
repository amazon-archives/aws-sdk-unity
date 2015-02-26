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



namespace Amazon.MobileAnalyticsManager.Config
{
    
    internal interface IAmazonMobileAnalyticsManagerConfig 
    {
        /// <summary>
        /// If the app stays in background for a time greater than the SESSION_DELTA then Mobile Analytics client stops old session and 
        /// creates a new session once app comes back to foreground.
        /// We recommend using values ranging from 5 to 10, 
        /// </summary>
        /// <value>default 5 seconds</value>
        long SESSION_DELTA {get;}


        // delivery config
        /// <summary>
        /// Gets the max size of the database used for local storage of events. Event Storage will ignore new 
        /// events if the size of database exceed this size. Value is in Bytes.
        /// We recommend using values ranging from 1MB to 10MB
        /// </summary>
        /// <value>default 5MB</value>
        long MAX_DB_SIZE {get;}
        
        /// <summary>
        /// The Warning threshold. The values range between 0 - 1. If the values exceed beyond the threshold then the
        /// Warning logs will be generated.
        /// </summary>
        /// <value>default 0.9</value>
        double DB_WARNING_THRESHOLD {get;}
        
        /// <summary>
        /// Submission wait time before the next event can be submitted. Value is in Seconds.
        /// For example, you cannot send events twice in the "submission wait time" window.
        /// </summary>
        /// <value>default 60 seconds</value>
        long FORCE_SUBMISSION_WAIT_TIME {get;}
        
        /// <summary>
        /// Background thread wait time. Thread will sleep for the interval mention. Value is in Seconds.
        /// </summary>
        /// <value>default 60 seconds</value>
        long BACKGROUND_SUBMISSION_WAIT_TIME {get;}
        
        /// <summary>
        /// The maximum size of the requests that can be submitted in every service call. Value can range between
        /// 1-512KB (expressed in long). Value is in Bytes. Attention: Do not use value larger than 512KB. May cause
        /// service to reject your Http request.
        /// </summary>
        /// <value>default 100KB</value>
        long MAX_REQUEST_SIZE {get;}
        
        /// <summary>
        /// A value indicating whether service call is allowed over data network
        /// Turn on this by caution. This may increase customer's data usage.
        /// </summary>
        /// <value>default false</value>
        bool ALLOW_USE_DATA_NETWORK {get;}
    }

}

