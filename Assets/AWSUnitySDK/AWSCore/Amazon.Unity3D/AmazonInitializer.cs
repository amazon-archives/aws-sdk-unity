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
using System.Threading;

using UnityEngine;
#if UNITY_EDITOR  
using UnityEditor;
#endif

namespace Amazon.Unity3D
{
    public class AmazonInitializer : MonoBehaviour
    {
        
        private static AmazonInitializer _instance = null;
        private static bool _initialized = false;

        #region Inspector variables
        public int MaxConnectionPoolSize = 10;
        #endregion
        


        /// <summary>
        /// Determines if its initialized & running.
        /// </summary>
        /// <returns><c>true</c> if is running; otherwise, <c>false</c>.</returns>
        internal static bool IsInitialized
        {
            get
            {
                return _initialized;
            }
        }
        
        
        
        
#if UNITY_EDITOR        
        internal static bool IsEditorPlaying
        {
            get;set;
        }
        
        internal static bool IsEditorPaused
        {
            get;set;
        }
        
        private void HandleEditorPlayModeChange()
        {
            IsEditorPlaying = EditorApplication.isPlaying;
            IsEditorPaused = EditorApplication.isPaused;
        }
#endif
        
        public void Awake ()
        {
            if (_instance == null)
            {
                // singleton instance
                _instance = this;
                
                // preventing the instance from getting destroyed between scenes
                DontDestroyOnLoad (this);
                
                // load service endpoints from config file
                Amazon.RegionEndpoint.LoadEndpointDefinitions ();
                
                // add other scripts
                _instance.gameObject.AddComponent<AmazonMainThreadDispatcher>();
                _instance.gameObject.AddComponent<AmazonNetworkStatusInfo>();
                
                // add callback for Editor Mode change
                #if UNITY_EDITOR
                IsEditorPlaying = EditorApplication.isPlaying;
                EditorApplication.playmodeStateChanged += this.HandleEditorPlayModeChange;
                #endif
                
                // init done 
                _initialized = true;
            }
            else
            {
                if (this != _instance)
                {
                    #if UNITY_EDITOR
                        DestroyImmediate(this.gameObject);
                    #else
                        Destroy (this.gameObject);
                    #endif
                }
            }
        }
              
        private AmazonInitializer ()
        {
        }
    }
}

