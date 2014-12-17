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
    /// Represents a non-generic object for retrieving a batch of items
    /// from a single DynamoDB table
    /// </summary>
    public abstract partial class BatchGet
    {
        #region internal methods

        /// <summary>
        /// Executes a server call to batch-get the items requested.
        /// </summary>
        internal void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion
    }

    /// <summary>
    /// Class for retrieving a batch of items from multiple DynamoDB tables,
    /// using multiple strongly-typed BatchGet objects
    /// </summary>
    public partial class MultiTableBatchGet
    {
        #region Internal methods

        /// <summary>
        /// Executes a multi-table batch request against all configured batches.
        /// Results are stored in the respective BatchGet objects.
        /// </summary>
        internal void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion
    }

}
