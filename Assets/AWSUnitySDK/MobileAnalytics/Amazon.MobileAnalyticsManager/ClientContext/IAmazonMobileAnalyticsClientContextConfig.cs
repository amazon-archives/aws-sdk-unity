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

namespace Amazon.MobileAnalyticsManager.ClientContext
{
    // customer must provide some info for client context header
    public interface IAmazonMobileAnalyticsClientContextConfig
    {
        /// <summary>
        /// A unique identifier representing this installation instance of your app.
        /// </summary>
        /// <value>The client identifier.</value>
        string ClientId {get;}
        
        /// <summary>
        /// The title of your app. For example, My App.
        /// </summary>
        /// <value>The app title.</value>
        string AppTitle  {get;}
        
        /// <summary>
        /// The version of your app. For example, V2.0.
        /// </summary>
        /// <value>The name of the app version.</value>
        string AppVersionName {get;}
        
        /// <summary>
        /// The version code for your app. For example, 3.
        /// </summary>
        /// <value>The app version code.</value>
        string AppVersionCode {get;}
        
        
        /// <summary>
        /// The name of your package. For example, com.example.my_app.
        /// </summary>
        /// <value>The name of the app package.</value>
        string AppPackageName {get;}
        
        /// <summary>
        /// Gets the app identifier. This is same as the Mobile Analytics App Id when you create the APP on the AWS Mobile Analytics Console.
        /// </summary>
        /// <value>The app identifier.</value>
        string AppId {get;}
    }
}
