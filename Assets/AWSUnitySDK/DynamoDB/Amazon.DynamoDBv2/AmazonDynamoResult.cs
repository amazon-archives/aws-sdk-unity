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

namespace Amazon.DynamoDBv2
{
    /// <summary>
    /// Container for callback response, contains Response, Exception & state objects
    /// </summary>
    public class AmazonDynamoResult<T>
    {
        public Exception Exception { get; internal set; }
        
        public object State { get; private set; }
        
        public T Response { get; internal set;} 
        
        public AmazonDynamoResult(T response, Exception exception, object state)
        {
            this.Response = response;
            this.Exception = exception;
            this.State = state;
        }
        
        public AmazonDynamoResult(object state)
        {
            this.State = state;
        }
    }
    
    /// <summary>
    /// Serves as a base class for the Dynamo Client Response
    /// </summary>
    public class AmazonDynamoResponse 
    {
        
    }
    
    /// <summary>
    /// Amazon dynamo callback delegate definition
    /// </summary>
    public delegate void AmazonDynamoCallback<T>(AmazonDynamoResult<T> result);
}

