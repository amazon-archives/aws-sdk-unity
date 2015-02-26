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
using System.Threading;

using UnityEngine;

using Amazon.Unity3D;
using Amazon.Runtime.Internal;
using Amazon.Runtime;

namespace Amazon.Unity3D
{

    /// <summary>
    /// A Unity Script class which should to added to a GameObject before using any AWS Clients
    /// It starts the CallNetworkCodeCoroutine which runs in an infinite while loop 
    /// </summary>
    public partial class AmazonMainThreadDispatcher : MonoBehaviour
    {
        private static AmazonMainThreadDispatcher _instance = null;
        private static Thread _mainThread = null;
        internal static int MaxConnectionPoolSize = 10;
        private static ConcurrentQueue<AsyncResult> _requestQueue;
        private static ConcurrentQueue<AmazonCallbackState> _callbackQueue;
        private static ConcurrentQueue<Action> _execOnMainThreadQueue;
        private static ConcurrentQueue<IEnumerator> _coroutineQueue;
        
        private int _requestPending = 0;
        
        
        
        public void Awake ()
        {
            if (_instance == null)
            {
                // singleton instance
                _instance = this;
                
                // preventing the instance from getting destroyed between scenes
                DontDestroyOnLoad (this);
                
                _requestQueue = new ConcurrentQueue<AsyncResult> ();
                _callbackQueue = new ConcurrentQueue<AmazonCallbackState> ();
                _execOnMainThreadQueue = new ConcurrentQueue<Action> ();
                _coroutineQueue = new ConcurrentQueue<IEnumerator>();
                _mainThread = Thread.CurrentThread;
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
        

        private abstract class AmazonCallbackState
        {
            public abstract IEnumerator FireCallbackOnCoRoutine();
        }

        private class AmazonServiceCallbackState : AmazonCallbackState
        {
                
            AmazonServiceCallback _callback;
            AmazonServiceResult _result;
            
            public AmazonServiceCallbackState(AmazonServiceCallback callback, AmazonServiceResult result)
            {
                this._callback = callback;
                this._result = result;
            }
            
            public override IEnumerator FireCallbackOnCoRoutine()
            {
                if (_callback != null)
                {
                    _callback(_result);
                }
                yield break;
            }
        }

        private int RequestPending
        {
            get 
            { 
                return _requestPending;
            }
            set 
            {
                _requestPending = value;
            }
        }
        

        private AmazonMainThreadDispatcher ()
        {
        }

        /// <summary>
        /// Using Frame Update loop to check and fire WWW requests from the main thread 
        /// </summary>
        public void Update ()
        {
            // checks if any network request is pending
            while (_requestQueue.Count > 0 
                   && RequestPending < MaxConnectionPoolSize)
            {
                AsyncResult result = _requestQueue.Dequeue ();
                RequestPending++;
                StartCoroutine(FireNetworkRequestCoroutine(result));
            }

            if (_execOnMainThreadQueue.Count > 0)
            {
                while (_execOnMainThreadQueue.Count > 0)
                {
                    Action action = _execOnMainThreadQueue.Dequeue ();
                    action ();
                }
            }

            while (_callbackQueue.Count > 0)
            {
                _instance.StartCoroutine(_callbackQueue.Dequeue().FireCallbackOnCoRoutine());
            }

            while (_coroutineQueue.Count > 0)
            {
                _instance.StartCoroutine(_coroutineQueue.Dequeue());
            }
        }
        
        private IEnumerator FireNetworkRequestCoroutine(AsyncResult result)
        {
            // this check is probably not needed since Dequeue operation is supposed to invoked only from the Unity MainThread
            if (result != null)
            {
                AmazonLogging.LogInfo (result.Request.ServiceName,"Making WWW request");
                
                // making WWW request call
                yield return result.RequestData.FireRequest ();
                
                AmazonLogging.LogInfo (result.Request.ServiceName,"Completing WWW request");
                result.ResponseData = result.RequestData.GetResponseData ();
                // switching to background thread
                ThreadPool.QueueUserWorkItem (result.WaitCallback, (object)result);
            }
            RequestPending--;
            yield break;
        }

        internal static void QueueAWSRequest (AsyncResult asyncResult)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new NotSupportedException("AWSPrefab is not added to the scene");
            AmazonMainThreadDispatcher._requestQueue.Enqueue (asyncResult);
        }

        internal static void ExecOnMainThread (Action action)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new NotSupportedException("AWSPrefab is not added to the scene");
            AmazonMainThreadDispatcher._execOnMainThreadQueue.Enqueue (action);
        }
        
        /// <summary>
        /// Execs the callback on mainthread
        /// </summary>
        /// <param name="callback">Callback to exec</param>
        /// <param name="result">Result to be passed to the callback method</param>
        public static void ExecCallback (AmazonServiceCallback callback, AmazonServiceResult result)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new NotSupportedException("AWSPrefab is not added to the scene");
            AmazonMainThreadDispatcher._callbackQueue.Enqueue (new AmazonServiceCallbackState(callback, result));
        }
        
        internal static bool IsMainThread
        {
            get
            {
                return !Thread.CurrentThread.IsThreadPoolThread && _mainThread.Equals(Thread.CurrentThread);
            }
        }
        
        /// <summary>
        /// Starts the coroutine.
        /// </summary>
        /// <param name="coroutine">Coroutine to run</param>
        public static void ExecCoroutine(IEnumerator coroutine)
        {
            if (!AmazonInitializer.IsInitialized)
                throw new NotSupportedException("AWSPrefab is not added to the scene");
            if (coroutine == null)
                throw new ArgumentNullException("coroutine");

            AmazonMainThreadDispatcher._coroutineQueue.Enqueue(coroutine);
        }
    }
}
