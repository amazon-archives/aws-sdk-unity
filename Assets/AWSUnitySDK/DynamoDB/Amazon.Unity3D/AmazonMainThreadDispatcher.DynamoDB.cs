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

/// <summary>
/// Amazon main thread dispatcher partial for DynamoCallback.
/// </summary>
using System.Collections;
using Amazon.DynamoDBv2;

namespace Amazon.Unity3D
{
    public partial class AmazonMainThreadDispatcher
    {   
        private class AmazonDynamoCallbackState<T> : AmazonCallbackState
        {
            AmazonDynamoCallback<T> _callback;
            AmazonDynamoResult<T> _result;
            
            public AmazonDynamoCallbackState(AmazonDynamoCallback<T> callback, AmazonDynamoResult<T> result)
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
        
        internal static void ExecCallback<T>(AmazonDynamoCallback<T> callback, AmazonDynamoResult<T> result)
        {
            _callbackQueue.Enqueue (new AmazonDynamoCallbackState<T>(callback, result));
        }
    }
}