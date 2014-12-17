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
using System.Reflection;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;

namespace Amazon.DynamoDBv2.DataModel
{
    /// <summary>
    /// Represents a non-generic object for writing/deleting a batch of items
    /// in a single DynamoDB table
    /// </summary>
    public abstract partial class BatchWrite
    {
        #region Public methods

        /// <summary>
        /// Executes a server call to batch-write/delete the items requested.
        /// 
        /// If more than 25 put/delete operations are specified, calls of up to 25
        /// put/delete items will be made until all items are processed.
        /// Initiates the asynchronous execution of the Execute operation.
        /// </summary>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// 
        /// <returns>void</returns>
        public void ExecuteAsync(AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => 
               { ExecuteHelper(true); return new VoidResponse(); }, 
                "BatchGet-ExecuteAsync", callback, state);
        }

        #endregion
    }

    /// <summary>
    /// Class for writing/deleting a batch of items in multiple DynamoDB tables,
    /// using multiple strongly-typed BatchWrite objects
    /// </summary>
    public partial class MultiTableBatchWrite
    {
        #region Public methods

        /// <summary>
        /// Executes a multi-table batch request against all configured batches.
        /// 
        /// If more than 25 put/delete operations are specified, calls of up to 25
        /// put/delete items will be made until all items are processed.
        /// Initiates the asynchronous execution of the Execute operation.
        /// </summary>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// 
        /// <returns>void</returns>
        public void ExecuteAsync(AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => 
                { ExecuteHelper(true); return new VoidResponse(); }, 
                "BatchGet-ExecuteAsync", callback, state);
        }

        #endregion
    }
}
