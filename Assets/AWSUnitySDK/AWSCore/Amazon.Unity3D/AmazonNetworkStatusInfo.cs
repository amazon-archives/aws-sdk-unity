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

namespace Amazon.Unity3D
{
    public class AmazonNetworkStatusInfo : MonoBehaviour 
    {
        
        private static NetworkReachability _networkReachability;
        private AmazonNetworkStatusInfo _instance = null;
				
		public class NetworkStatusRefreshed : EventArgs
		{
			public NetworkReachability NetworkReachability;

			public NetworkStatusRefreshed(NetworkReachability reachability) {
				NetworkReachability = reachability;
			}

		}
		public static event EventHandler<NetworkStatusRefreshed> OnRefresh;

        void Start () 
        {
            StartCoroutine(TestNetworkConnection());
        }
        
        public void Awake ()
        {
            if (_instance == null)
            {
                // singleton instance
                _instance = this;
                
                // preventing the instance from getting destroyed between scenes
                DontDestroyOnLoad (this);
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
        
        private IEnumerator TestNetworkConnection()
        {
			if(!AmazonMainThreadDispatcher.IsMainThread)
				throw new InvalidOperationException("Supported only on main(game) thread");

            while(true)
            {
                _networkReachability = Application.internetReachability;
				if (OnRefresh != null) {
					OnRefresh(this, new NetworkStatusRefreshed(_networkReachability));
				}
                yield return new WaitForSeconds(10);
            }
        }
        
        internal static NetworkReachability Reachability
        {
            get
            {
                return _networkReachability;
            }
        }
        
        
    }
}
