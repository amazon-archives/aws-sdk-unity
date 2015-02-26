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

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Util;
using System.Threading;
using Amazon.Unity3D;

namespace Amazon.DynamoDBv2
{
    internal delegate object AsyncCall();

    internal class DynamoDBAsyncResult : IAsyncResult, IDisposable
    {
        private ManualResetEvent _waitHandle;
        private bool _disposed = false;

        public DynamoDBAsyncResult(AsyncCallback callback, object state)
        {
            this.Callback = callback;
            this.AsyncState = state;
            this._waitHandle = new ManualResetEvent(false);
        }

        #region IAsyncResult methods

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted { get; private set; }

        public object AsyncState { get; private set; }

        public WaitHandle AsyncWaitHandle
        {
            get { return this._waitHandle; }
        }

        #endregion

        public void SignalWaitHandle()
        {
            this.IsCompleted = true;
            this._waitHandle.Set();
        }

        public AsyncCallback Callback { get; private set; }

        public Exception LastException { get; set; }

        public object Return { get; set; }

        #region Dispose Pattern Implementation

        /// <summary>
        /// Implements the Dispose pattern
        /// </summary>
        /// <param name="disposing">Whether this object is being disposed via a call to Dispose
        /// or garbage collected.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing && _waitHandle != null)
                {
#if WIN_RT
                    _waitHandle.Dispose();
#else
                    _waitHandle.Close();
#endif
                    _waitHandle = null;
                }
                this._disposed = true;
            }
        }

        /// <summary>
        /// Disposes of all managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    internal static class DynamoDBAsyncExecutor
    {
        private class DynamoDBAsyncState<T>
        {
            public AmazonDynamoCallback<T> Callback { get; set; }

            public object State { get; set; }

            public object Return { get; set; }

            public string Operation { get; set; }

            public DynamoDBAsyncState(string operation, AmazonDynamoCallback<T> callback, object state)
            {
                this.Operation = operation;
                this.Callback = callback;
                this.State = state;
            }
        }

        public static void Execute(AsyncCall call, DynamoDBAsyncResult result)
        {
            try
            {
                result.Return = call();
            }
            catch (Exception e)
            {
                result.LastException = e;
                result.Return = null;
            }
            finally
            {
                result.SignalWaitHandle();
                if (result.Callback != null)
                {
                    result.Callback(result);
                }
            }
        }

        public static void IsMainThread(string asyncMethod)
        {
            if (AmazonMainThreadDispatcher.IsMainThread)
                throw new NotSupportedException("Use " + asyncMethod + " method instead");
        }

        private static void Execute<T>(AsyncCall call, DynamoDBAsyncState<T> result)
        {
            try
            {
                result.Return = call();
                AmazonMainThreadDispatcher.ExecCallback<T>(result.Callback, new AmazonDynamoResult<T>((T)result.Return, null, result.State));
                return;
            }
            catch (Exception ex)
            {
                AmazonLogging.LogException("DynamoDB " + result.Operation, ex);
                AmazonMainThreadDispatcher.ExecCallback<T>(result.Callback, new AmazonDynamoResult<T>(default(T), ex, result.State));
                return;
            }
        }

        public static void AsyncOperation<T>(AsyncCall call, string operation, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncState<T> result = new DynamoDBAsyncState<T>(operation, callback, state);
            ThreadPool.QueueUserWorkItem(s => Execute(call, result));
            return;
        }

        public static IAsyncResult BeginOperation(AsyncCall call, AsyncCallback callback, object state)
        {
            DynamoDBAsyncResult result = new DynamoDBAsyncResult(callback, state);
#if (WIN_RT || WINDOWS_PHONE)
            System.Threading.Tasks.Task.Run((Action)(() => Execute(call, result)));
#else
            ThreadPool.QueueUserWorkItem(s => Execute(call, result));
#endif
            return result;
        }

        public static void EndOperation(IAsyncResult result)
        {
            EndOperation<object>(result);
        }

        public static T EndOperation<T>(IAsyncResult result)
        {
            DynamoDBAsyncResult asyncResult = result as DynamoDBAsyncResult;
            if (asyncResult == null)
                return default(T);

            using (asyncResult)
            {
                if (!asyncResult.CompletedSynchronously)
                {
                    WaitHandle.WaitAll(new WaitHandle[] { asyncResult.AsyncWaitHandle });
                }

                if (asyncResult.LastException != null)
                {
                    AWSSDKUtils.PreserveStackTrace(asyncResult.LastException);
                    throw asyncResult.LastException;
                }

                return (T)asyncResult.Return;
            }
        }
    }
}
