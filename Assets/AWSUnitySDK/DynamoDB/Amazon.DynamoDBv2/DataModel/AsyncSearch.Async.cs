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
using System.Linq;
using Amazon.DynamoDBv2;
using Amazon.Unity3D;
using System.Threading;
using Amazon.DynamoDBv2.Model;

namespace Amazon.DynamoDBv2.DataModel
{
    /// <summary>
    /// A strongly-typed object for retrieving search results (Query or Scan)
    /// from DynamoDB.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class AsyncSearch<T>
    {
        #region Async public

        /// <summary>
        /// Initiates the asynchronous execution to get the next set of results from DynamoDB.
        /// List<T> is returned in the result.Response
        /// </summary>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// 
        /// <returns>void</returns>
        public void GetNextSetAsync(AmazonDynamoCallback<List<T>> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation(() =>
            {
                var documents = DocumentSearch.GetNextSetHelper(true);
                List<T> items = SourceContext.FromDocumentsHelper<T>(documents, Config).ToList();
                return items;
            }, "GetNextSetAsync", callback, state);
        }

        /// <summary>
        /// Initiates the asynchronous execution to get all the remaining results from DynamoDB.
        /// </summary>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// 
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndGetRemaining
        ///         operation.</returns>
        public void GetRemainingAsync(AmazonDynamoCallback<List<T>> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation(() =>
            {
                var documents = DocumentSearch.GetRemainingHelper(true);
                List<T> items = SourceContext.FromDocumentsHelper<T>(documents, Config).ToList();
                return items;
            }, "GetRemainingAsync", callback, state);
        }

        #endregion
    }
}
