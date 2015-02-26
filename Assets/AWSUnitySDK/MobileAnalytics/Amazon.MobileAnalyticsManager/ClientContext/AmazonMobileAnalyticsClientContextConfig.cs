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

using Amazon.Unity3D;
using Amazon.Unity3D.Storage;

namespace Amazon.MobileAnalyticsManager.ClientContext
{
    // customer must provide some info for client context header
    public class AmazonMobileAnalyticsClientContextConfig : IAmazonMobileAnalyticsClientContextConfig
    {
        private const string APP_CLIENT_ID_KEY = "mobile_analytics_client_id";
        
        private string _clientId = "";
        private string _appTitle = "";
        private string _appVersionName = "";
        private string _appVersionCode = "";
        private string _appPackageName = "";
        private string _appId = "";
        private KVStore _kvStore;
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.ClientContext.AmazonMobileAnalyticsClientContextConfig"/> class.
        /// </summary>
        /// <param name="appId">App identifier -  AWS Mobile Analytics App ID corresponding to your App</param>
        public AmazonMobileAnalyticsClientContextConfig(string appId):this(AmazonHookedPlatformInfo.Instance.Title,
                                                                           AmazonHookedPlatformInfo.Instance.VersionName,
                                                                           AmazonHookedPlatformInfo.Instance.VersionCode,
                                                                           AmazonHookedPlatformInfo.Instance.PackageName,appId)
        {
            
        }
        
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.Config.AmazonMobileAnalyticsClientContextConfig"/> class.
        /// </summary>
        /// <param name="appTitle">App title -  The title of your app. For example, My App.</param>
        /// <param name="appVersionName">App version name - The version of your app. For example, V2.0.</param>
        /// <param name="appVersionCode">App version code - The version code for your app. For example, 3.</param>
        /// <param name="appPackageName">App package name - The name of your package. For example, com.example.my_app.</param>
        /// <param name="appId">App identifier -  AWS Mobile Analytics App ID corresponding to your App</param>
        public AmazonMobileAnalyticsClientContextConfig(string appTitle, string appVersionName,string appVersionCode, string appPackageName, string appId)
        {
            if(string.IsNullOrEmpty(appTitle))
            {
                throw new ArgumentNullException("appTitle");
            }
            
            if(string.IsNullOrEmpty(appVersionName))
            {
                throw new ArgumentNullException("appVersionName");
            }
            
            if(string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException("appId");
            }
            
            if(string.IsNullOrEmpty(appPackageName))
            {
                throw new ArgumentNullException("appPackageName");
            }
            
            if(string.IsNullOrEmpty(appVersionCode))
            {
                throw new ArgumentNullException("appVersionCode");
            }

            this._appTitle = appTitle;
            this._appVersionName = appVersionName;
            this._appVersionCode = appVersionCode;
            this._appPackageName = appPackageName;
            this._appId = appId;
            _kvStore = new SQLiteKVStore();
        }
        
        /// <summary>
        /// A unique identifier representing this installation instance of your app.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId {
            get
            {
                if(string.IsNullOrEmpty(_clientId))
                {
                    _clientId = _kvStore.Get(APP_CLIENT_ID_KEY);
                    if(string.IsNullOrEmpty(_clientId))
                    {
                        _clientId = Guid.NewGuid().ToString();
                        _kvStore.Put(APP_CLIENT_ID_KEY,_clientId);
                    }
                }
                return _clientId;
            }
        }
        
        /// <summary>
        /// The title of your app. For example, My App.
        /// </summary>
        /// <value>The app title.</value>
        public string AppTitle  {get{return _appTitle;}}
        
        /// <summary>
        /// The version of your app. For example, V2.0.
        /// </summary>
        /// <value>The name of the app version.</value>
        public string AppVersionName {get{return _appVersionName;}}
        
        /// <summary>
        /// The version code for your app. For example, 3.
        /// </summary>
        /// <value>The app version code.</value>
        public string AppVersionCode{ get {return _appVersionCode;}}
        
        /// <summary>
        /// The name of your package. For example, com.example.my_app.
        /// </summary>
        /// <value>The name of the app package.</value>
        public string AppPackageName {get {return _appPackageName;}}
        
        /// <summary>
        /// Gets the app identifier. This is same as the Mobile Analytics App Id when you create the APP on the AWS
        /// Mobile Analytics Console.
        /// </summary>
        /// <value>The app identifier.</value>
        public string AppId {get {return _appId;}}
        
    }
}
