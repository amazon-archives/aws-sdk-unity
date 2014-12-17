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
using System.Collections.Generic;

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace Amazon.DynamoDBv2.DocumentModel
{
    /// <summary>
    /// Search response object
    /// </summary>
    public partial class Search
    {

        #region Async public 

        /// <summary>
        /// Initiates the asynchronous execution of the GetNextSet operation.
        /// Retrieves the next set (page) of results
        /// Returns Next set of Documents matching the search parameters in callback
        /// </summary>
        /// <param name="callback">An AmazonDynamoCallback delegate with that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetNextSetAsync(AmazonDynamoCallback<List<Document>> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<List<Document>>(() => GetNextSetHelper(true), "GetNextSetAsync", callback, state);
        }

        /// <summary>
        /// Initiates the asynchronous execution of the GetRemaining operation.
        /// Retrieves all the remaining results
        /// Returns List of Documents matching the search parameters in callback
        /// </summary>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetRemainingAsync(AmazonDynamoCallback<List<Document>> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<List<Document>>(() => GetRemainingHelper(true), "GetRemainingAsync", callback, state);
        }

        #endregion
    }
}
