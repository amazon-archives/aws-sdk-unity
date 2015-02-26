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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Amazon.MobileAnalyticsManager.Event;
using Amazon.MobileAnalyticsManager.Config;
using Amazon.MobileAnalyticsManager.Session;
using Amazon.MobileAnalyticsManager.ClientContext;
using Amazon.MobileAnalyticsManager.Delivery;
using Amazon.Runtime;
using Amazon.Util;
using Amazon.Unity3D;

namespace Amazon.MobileAnalyticsManager
{
    
    /// <summary>
    /// MobileAnalyticsManager in the entry point to recording analytic events for your application
    /// </summary>
    public class AmazonMobileAnalyticsManager
    {
        
        private static volatile AmazonMobileAnalyticsManager _instance;
        
        #region instance variables
        private string _appId;
        #endregion
        
        #region static variables
        private static object _lock = new object();
        private static IDictionary<string,AmazonMobileAnalyticsManager> _instanceDictionary = new Dictionary<string, AmazonMobileAnalyticsManager>();
        #endregion
        
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Amazon.MobileAnalyticsManager.AmazonMobileAnalyticsManager"/> class.
        /// </summary>
        /// <param name="clientContextConfig">Client context config.</param>
        /// <param name="regionEndpoint">Region endpoint.</param>
        /// <param name="credentials">Credentials.</param>
        private AmazonMobileAnalyticsManager(IAmazonMobileAnalyticsClientContextConfig clientContextConfig,RegionEndpoint regionEndpoint,AWSCredentials credentials)
        {
            if(Config == null)
                Config = new AmazonMobileAnalyticsManagerFileConfig();
            
            if(clientContextConfig == null)
                throw new ArgumentNullException("clientContextConfig");
            ClientContext = new AmazonMobileAnalyticsClientContext(clientContextConfig);
            
            if(string.IsNullOrEmpty(clientContextConfig.AppId))
                throw new ArgumentNullException("application id");
            _appId = clientContextConfig.AppId;
            
            if(credentials == null)
                throw new ArgumentNullException("credentials");
            
            DeliveryClient = AmazonMADefaultDeliveryClient.newInstance(Config.ALLOW_USE_DATA_NETWORK,ClientContext,credentials,regionEndpoint);
            
            Session = new AmazonMobileAnalyticsSession(_appId);
        }
        
        
        /// <summary>
        /// Gets the or create instance.
        /// </summary>
        /// <returns>The or create instance.</returns>
        /// <param name="credentials">Credentials.</param>
        /// <param name="regionEndpoint">Region endpoint.</param>
        /// <param name="appId">App identifier.</param>
        public static AmazonMobileAnalyticsManager GetOrCreateInstance(AWSCredentials credential,
                                                                         RegionEndpoint regionEndpoint,
                                                                         string appId
                                                                         )
        {
            IAmazonMobileAnalyticsClientContextConfig config = new AmazonMobileAnalyticsClientContextConfig(appId);
            return AmazonMobileAnalyticsManager.GetOrCreateInstance(credential,regionEndpoint,config);
        }
        
        
        /// <summary>
        /// Gets the or create instance.
        /// </summary>
        /// <returns>The or create instance.</returns>
        /// <param name="clientContextConfig">Client context config.</param>
        /// <param name="regionEndpoint">Region endpoint.</param>
        /// <param name="credentials">Credentials.</param>
        private static AmazonMobileAnalyticsManager GetOrCreateInstance(AWSCredentials credential,
                                                                       RegionEndpoint regionEndpoint,
                                                                       IAmazonMobileAnalyticsClientContextConfig clientContextConfig
                                                                       )
        {
            string appId = clientContextConfig.AppId;
            AmazonMobileAnalyticsManager managerInstance =null;
            bool newInstance = false;
            lock(_lock)
            {
                if(_instanceDictionary.ContainsKey(appId)){
                    managerInstance = _instanceDictionary[appId];
                }else{
                    managerInstance = new AmazonMobileAnalyticsManager(clientContextConfig,regionEndpoint,credential);
                    _instanceDictionary[appId] = managerInstance;
                    newInstance = true;
                }
            }
            
            if(newInstance)
                managerInstance.Session.Start();
            
            if(!AmazonMobileAnalyticsBackgroundRunner.IsAlive() && !IntegrationTestEnable){
                AmazonMobileAnalyticsBackgroundRunner.StartWork();
            }
            
            return managerInstance;
        }
        
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <param name="appId">App identifier.</param>
        public static AmazonMobileAnalyticsManager GetInstance(string appId)
        {
            lock(_lock)
            {
                return _instanceDictionary[appId];
            }
        }
        
        #endregion
        
        #region public
        /// <summary>
        /// Pauses the current session.
        /// PauseSession() is the entry point into the Amazon Mobile Analytics SDK where sessions can be paused. Session is created and started
        /// immediately after instantiating the AmazonMobileAnalyticsManager object. The session remains active until it is paused. When in a paused 
        /// state, the session time will not accumulate. 
        /// When resuming a session, if enough time has elapsed from when the session is paused to when it's resumed, the session is ended and a new session
        /// is created and started. Otherwise, the paused session is resumed and the session time continues to accumulate.  Default delta is 5 seconds.
        /// 
        /// In order for MobileAnalyticsManager to track sessions, you must call the pauseSession() and resumeSession() in each scene of your Unity app
        /// and you must call them from main thread.
        /// <example>
        /// The example below shows how to pause and resume session
        /// <code>
        /// void OnApplicationFocus(bool focus) 
        /// {
        ///     if(started){
        ///         if(focus)
        ///         {
        ///             AmazonMobileAnalyticsManager.Instance.ResumeSession();
        ///         }
        ///         else
        ///         {
        ///             AmazonMobileAnalyticsManager.Instance.PauseSession();
        ///         }
        ///     }
        /// }
        /// </code> 
        /// </eaxmple> 
        /// </summary>
        public void PauseSession()
        {
            if(! AmazonMainThreadDispatcher.IsMainThread)
            {
                throw new Exception("You must call PauseSession() from main thread. ");
            }
            Session.Pause();
        }
        
        /// <summary>
        /// Resume the current session.
        /// ResumeSession() is the entry point into the Amazon Mobile Analytics SDK where sessions can be resumed. Session is created and started
        /// immediately after instantiating the AmazonMobileAnalyticsManager object. The session remains active until it is paused. When in a paused 
        /// state, the session time will not accumulate. 
        /// When resuming a session, if enough time has elapsed from when the session is paused to when it's resumed, the session is ended and a new session
        /// is created and started. Otherwise, the paused session is resumed and the session time continues to accumulate.  Default delta is 5 seconds.
        /// 
        /// In order for MobileAnalyticsManager to track sessions, you must call the pauseSession() and resumeSession() in each scene of your Unity app
        /// and you must call them from main thread.
        /// <example>
        /// The example below shows how to pause and resume session
        /// <code>
        /// void OnApplicationFocus(bool focus) 
        /// {
        ///     if(started){
        ///         if(focus)
        ///         {
        ///             AmazonMobileAnalyticsManager.Instance.ResumeSession();
        ///         }
        ///         else
        ///         {
        ///             AmazonMobileAnalyticsManager.Instance.PauseSession();
        ///         }
        ///     }
        /// }
        /// </code> 
        /// </eaxmple> 
        /// </summary>
        public void ResumeSession()
        {
            if(! AmazonMainThreadDispatcher.IsMainThread)
            {
                throw new Exception("You must call ResumeSession() from main thread. ");
            }
            Session.Resume();
        }
        
        /// <summary>
        /// Record the specified event to the local filestore. The event will be delivery in background thread.
        /// </summary>
        /// <param name="theEvent">The event.</param>
        public void RecordEvent(IAmazonMobileAnalyticsEvent theEvent)
        {
            theEvent.Timestamp = DateTime.UtcNow.ToString(AWSSDKUtils.ISO8601DateFormat);

            Amazon.MobileAnalytics.Model.Event modelEvent = theEvent.ConvertToMobileAnalyticsModelEvent(this.Session);
            DeliveryClient.EnqueueEventsForDelivery(modelEvent);
        }

        /// <summary>
        /// Adds the client context custom attribute.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void AddClientContextCustomAttribute(string key,string value)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            
            if(string.IsNullOrEmpty("value"))
            {
                throw new ArgumentNullException("value");
            }

            ClientContext.AddCustomAttributes(key,value);
        }
        

        #endregion


        #region internal
        internal static bool IntegrationTestEnable = false;
        
        internal static IAmazonMobileAnalyticsManagerConfig Config {get;private set;}
        
        internal AmazonMobileAnalyticsSession Session {get;private set;}
        
        internal AmazonMobileAnalyticsClientContext ClientContext {get;private set;}
        
        internal IAmazonMADeliveryClient DeliveryClient{get;private set;}
        
        internal static IDictionary<string,AmazonMobileAnalyticsManager> InstanceDictionary
        {
            get
            {
                lock(_lock){
                    return new Dictionary<string, AmazonMobileAnalyticsManager>(_instanceDictionary);
                }
            }
        }
        
        internal void ForceAttempt()
        {
            DeliveryClient.AttemptDelivery();
        }

        #endregion
        
    }
}