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
using System.Collections;
using System.Collections.Generic;

using Amazon.MobileAnalyticsManager.Config;
using Amazon.Unity3D;

using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalyticsManager.ClientContext
{
    internal class AmazonMobileAnalyticsClientContext
    {
        //client related keys
        private const string CLIENT_KEY = "client";
        private const string CLIENT_ID_KEY = "client_id";
        private const string CLIENT_APP_TITLE_KEY = "app_title";
        private const string CLIENT_APP_VERSION_NAME_KEY = "app_version_name";
        private const string CLIENT_APP_VERSION_CODE_KEY = "app_version_code";
        private const string CLIENT_APP_PACKAGE_NAME_KEY = "app_package_name";
        
        //custom keys
        private const string CUSTOM_KEY = "custom";
        
        //env related keys
        private const string ENV_KEY = "env";
        private const string ENV_PLATFORM_KEY = "platform";
        private const string ENV_MODEL_KEY = "model";
        private const string ENV_MAKE_KEY = "make";
        private const string ENV_PLATFORM_VERSION_KEY = "platform_version";
        private const string ENV_LOCALE_KEY = "locale";
        
        //servies related keys
        private const string SERVICES_KEY = "services";
        private const string SERVICE_MOBILE_ANALYTICS_KEY = "mobile_analytics";
        private const string SERVICE_MOBILE_ANALYTICS_APP_ID_KEY = "app_id";
        

        private IDictionary<string,string> _client;
        private IDictionary<string,string> _custom;
        private IDictionary<string,string> _env;
        private IDictionary<string,IDictionary> _services;
        
        private IDictionary _clientContext;
        
        private IAmazonMobileAnalyticsClientContextConfig _config;
        
        
        private static object _lock = new object(); 
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.ClientContext.AmazonMobileAnalyticsClientContext"/> class.
        /// </summary>
        /// <param name="config">Config <see cref="Amazon.MobileAnalyticsManager.ClientContext.IAmazonMobileAnalyticsClientContextConfig"/></param>
        public AmazonMobileAnalyticsClientContext (IAmazonMobileAnalyticsClientContextConfig config)
        {
            lock(_lock)
            {
                this.Config = config;
                _custom = new Dictionary<string, string>();
            }

        }
        
        /// <summary>
        /// Gets or sets the config <see cref="Amazon.MobileAnalyticsManager.ClientContext.IAmazonMobileAnalyticsClientContextConfig"/>
        /// </summary>
        /// <value>The config.</value>
        public IAmazonMobileAnalyticsClientContextConfig Config
        {
            set
            {
                lock(_lock)
                {
                    _config = value;
                }
            }
            
            get
            {
                lock(_lock)
                {
                    return _config;
                }
            
            }
        }
        
        /// <summary>
        /// Adds the custom attributes to the Client Context
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void AddCustomAttributes(string key, string value)
        {
            lock(_lock)
            {
                _custom.Add(key,value);
            }
        }
        
        /// <summary>
        /// Gets a Json Representation of the Client Context
        /// </summary>
        /// <returns>Json Representation of Client Context</returns>
        public String ToJsonString()
        {
            lock(_lock)
            {
                _client = new Dictionary<string, string>();
                _env = new Dictionary<string, string>();
                _services = new Dictionary<string, IDictionary>();
                
                // client
                _client.Add(CLIENT_ID_KEY,Config.ClientId);
                _client.Add(CLIENT_APP_TITLE_KEY,Config.AppTitle);
                _client.Add(CLIENT_APP_VERSION_NAME_KEY,Config.AppVersionName);
                _client.Add(CLIENT_APP_VERSION_CODE_KEY,Config.AppVersionCode);
                _client.Add(CLIENT_APP_PACKAGE_NAME_KEY,Config.AppPackageName);
                
                // env
                AmazonHookedPlatformInfo platformInfo = AmazonHookedPlatformInfo.Instance;
                _env.Add(ENV_PLATFORM_KEY,platformInfo.Platform);
                _env.Add(ENV_PLATFORM_VERSION_KEY,platformInfo.PlatformVersion);
                _env.Add(ENV_LOCALE_KEY,platformInfo.Locale);
                _env.Add(ENV_MAKE_KEY,platformInfo.Make);
                _env.Add(ENV_MODEL_KEY,platformInfo.Model);
                
                // services
                IDictionary mobileAnalyticsService = new Dictionary<string,string>();
                mobileAnalyticsService.Add(SERVICE_MOBILE_ANALYTICS_APP_ID_KEY,Config.AppId);
                _services.Add(SERVICE_MOBILE_ANALYTICS_KEY,mobileAnalyticsService);
                
                
                _clientContext = new Dictionary<string, IDictionary>();
                _clientContext.Add(CLIENT_KEY,_client);
                _clientContext.Add(ENV_KEY,_env);
                _clientContext.Add(CUSTOM_KEY,_custom);
                _clientContext.Add(SERVICES_KEY,_services);
                
               return JsonMapper.ToJson(_clientContext);
            
            }
        }
    }
}

