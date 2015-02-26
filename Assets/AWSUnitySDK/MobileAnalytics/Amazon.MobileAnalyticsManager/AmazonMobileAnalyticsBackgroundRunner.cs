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
using System.Collections.Generic;
using System.Threading;
using System;
using Amazon.Unity3D;

namespace Amazon.MobileAnalyticsManager
{
    /// <summary>
    /// Amazon mobile analytics background runner.
    /// background runner periodically send events to server.
    /// </summary>
    public class AmazonMobileAnalyticsBackgroundRunner
    {
        private static System.Threading.Thread _thread = null;
        private static string TAG = "AmazonMobileAnalyticsBackgroundRunner";
        
        /// <summary>
        /// Determines if is alive.
        /// </summary>
        /// <returns><c>true</c> if is alive; otherwise, <c>false</c>.</returns>
        public static bool IsAlive()
        {
            return _thread != null && _thread.ThreadState != ThreadState.Stopped 
                                  && _thread.ThreadState != ThreadState.Aborted
                                  && _thread.ThreadState != ThreadState.AbortRequested;
                                  
        }
        
        /// <summary>
        /// Starts the background thread.
        /// </summary>
        public static void StartWork()
        {
            _thread = new System.Threading.Thread(DoWork);
            _thread.Start();
        }
        
        
        private static void DoWork()
        {
            while (true)
            {
#if UNITY_EDITOR
                if(AmazonInitializer.IsEditorPlaying && !AmazonInitializer.IsEditorPaused)
                {
#endif
                    try
                    {
                        AmazonLogging.LogInfo(TAG,"Attempting Delivery in Background Thread");
                        IDictionary<string,AmazonMobileAnalyticsManager> instanceDictionary = AmazonMobileAnalyticsManager.InstanceDictionary;
                        foreach(string appId in instanceDictionary.Keys)
                        {
                            try 
                            {
                                AmazonMobileAnalyticsManager manager = AmazonMobileAnalyticsManager.GetInstance(appId);
                                manager.DeliveryClient.AttemptDelivery();      
                            }
                            catch(System.Exception e)
                            {
                                AmazonLogging.LogException(TAG,e);
                            }
                        }
                        Thread.Sleep(Convert.ToInt32(AmazonMobileAnalyticsManager.Config.BACKGROUND_SUBMISSION_WAIT_TIME)*1000);
                    }
                    catch(System.Exception e)
                    {
                        AmazonLogging.LogException(TAG,e);
                    }
#if UNITY_EDITOR
                }
                
                else if(! AmazonInitializer.IsEditorPlaying)
                {
                    _thread.Abort();
                }
#endif
            }
        }
        
        
        
    }
}

