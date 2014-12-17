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
using System.IO;
using System.Net;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace Amazon.DynamoDBv2.DocumentModel
{

    /// <summary>
    /// Class for putting and/or deleting a batch of items in a single DynamoDB table.
    /// </summary>
    public partial class DocumentBatchWrite
    {
        #region Public methods

        /// <summary>
        /// Executes a server call to batch-put/delete the item specified.
        /// 
        /// If more than 25 put/delete operations are specified, calls of up to 25
        /// put/delete items will be made until all items are processed.
        /// </summary>
        internal void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion
    }

    /// <summary>
    /// Class for putting and/or deleting a batch of items in multiple DynamoDB tables.
    /// </summary>
    public partial class MultiTableDocumentBatchWrite
    {
        #region Public methods

        /// <summary>
        /// Executes a multi-table batch put/delete against all configured batches.
        /// 
        /// If more than 25 put/delete operations are specified, calls of up to 25
        /// put/delete items will be made until all items are processed.
        /// </summary>
        internal void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion
    }

}
