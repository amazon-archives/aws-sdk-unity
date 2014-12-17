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
        #region Public methods

        /// <summary>
        /// Retrieves the next set (page) of results
        /// </summary>
        /// <returns>Next set of Documents matching the search parameters</returns>
        internal List<Document> GetNextSet()
        {
            DynamoDBAsyncExecutor.IsMainThread("GetNextSetAsync");
            return GetNextSetHelper(false);
        }

        /// <summary>
        /// Retrieves all the remaining results
        /// </summary>
        /// <returns>List of Documents matching the search parameters</returns>
        internal List<Document> GetRemaining()
        {
            DynamoDBAsyncExecutor.IsMainThread("GetRemaining");
            return GetRemainingHelper(false);
        }

        #endregion

    }

}
