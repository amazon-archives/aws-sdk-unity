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

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace Amazon.DynamoDBv2.DocumentModel
{

    /// <summary>
    /// Class for retrieving a batch of Documents from a single DynamoDB table.
    /// </summary>
    public partial class DocumentBatchGet
    {

        #region Public methods

        /// <summary>
        /// Executes a server call to batch-get the documents requested.
        /// Populates Results with the retrieved items.
        /// </summary>
        internal void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion

    }

    /// <summary>
    /// Class for retrieving a batch of Documents from multiple DynamoDB tables.
    /// </summary>
    public partial class MultiTableDocumentBatchGet
    {
        #region Public methods
        
        /// <summary>
        /// Executes a multi-table batch request against all configured batches.
        /// Results are stored in the respective DocumentBatchGet objects.
        /// </summary>
        public void Execute()
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteAsync");
            ExecuteHelper(false);
        }

        #endregion
    }

}
