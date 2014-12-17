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

using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace Amazon.DynamoDBv2.DataModel
{
    /// <summary>
    /// Context object for using the DataModel mode of DynamoDB.
    /// Used to interact with the service, save/load objects, etc.
    /// </summary>
    public partial class DynamoDBContext : IDynamoDBContext
    {
        #region Save async
        
        /// <summary>
        /// Initiates the asynchronous execution of the Save operation.
        /// Saves an object to DynamoDB using passed-in configs.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to save as.</typeparam>
        /// <param name="value">Object to save.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void SaveAsync<T>(T value, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { SaveHelper<T>(value, null, true); return new VoidResponse(); }, "SaveAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Save operation.
        /// Saves an object to DynamoDB using passed-in configs.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to save as.</typeparam>
        /// <param name="value">Object to save.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { SaveHelper<T>(value, operationConfig, true); return new VoidResponse(); }, "SaveAsync", callback, state);
        }
        
        #endregion
        
        #region Load async
        
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given hash primary key.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(object hashKey, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(hashKey, null, null, true), "LoadAsync", callback, state);
        }
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Load"/>
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="rangeKey">Range key element of the target item.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(object hashKey, object rangeKey, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(hashKey, rangeKey, null, true), "LoadAsync", callback, state);
        }
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Load"/>
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(hashKey, null, operationConfig, true), "LoadAsync", callback, state);
        }
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Load"/>
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="rangeKey">Range key element of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(hashKey, rangeKey, operationConfig, true), "LoadAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Load"/>
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="keyObject">Key of the target item.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(T keyObject, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(keyObject, null, true), "LoadAsync", callback, state);
        }
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Load"/>
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="keyObject">Key of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<T>(() => LoadHelper<T>(keyObject, operationConfig, true), "LoadAsync", callback, state);
        }

        #endregion
        
        #region Delete async
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(T value, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(value, null, true); return new VoidResponse(); }, "LoadAsync", callback, state);
        }
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to delete.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(value, operationConfig, true); return new VoidResponse(); }, "DeleteAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(object hashKey, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(hashKey, null, null, true); return new VoidResponse(); }, "DeleteAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(hashKey, null, operationConfig, true); return new VoidResponse(); }, "DeleteAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="rangeKey">Range key element of the object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(object hashKey, object rangeKey, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(hashKey, rangeKey, null, true); return new VoidResponse(); }, "DeleteAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.Delete"/>
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="rangeKey">Range key element of the object to delete.</param>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => { DeleteHelper<T>(hashKey, rangeKey, operationConfig, true); return new VoidResponse(); }, "DeleteAsync", callback, state);
        }

        #endregion
        
        #region BatchGet async
        
        /// <summary>
        /// Initiates the asynchronous execution of the ExecuteBatchGet operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.ExecuteBatchGet"/>
        /// </summary>
        /// <param name="batches">Configured BatchGet objects</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void ExecuteBatchGetAsync(BatchGet[] batches, AmazonDynamoCallback<VoidResponse> callback, object state)
        {

            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => 
            { 
                MultiTableBatchGet superBatch = new MultiTableBatchGet(batches);
                superBatch.ExecuteHelper(true); 
                return new VoidResponse(); 
            }, "ExecuteBatchGetAsync", callback, state);
        }

        #endregion
        
        #region BatchWrite async
        
        /// <summary>
        /// Initiates the asynchronous execution of the ExecuteBatchWrite operation.
        /// <seealso cref="Amazon.DynamoDBv2.DataModel.DynamoDBContext.ExecuteBatchWrite"/>
        /// </summary>
        /// <param name="batches">Configured BatchWrite objects</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void ExecuteBatchWriteAsync(BatchWrite[] batches, AmazonDynamoCallback<VoidResponse> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<VoidResponse>(() => 
            { 
                MultiTableBatchWrite superBatch = new MultiTableBatchWrite(batches);
                superBatch.ExecuteHelper(true); 
                return new VoidResponse(); 
            }, "ExecuteBatchWriteAsync", callback, state);
        }

        #endregion
        
        #region Scan async
        
        /// <summary>
        /// Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="conditions">
        /// Conditions that the results should meet.
        /// </param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> ScanAsync<T>(params ScanCondition[] conditions)
        {
            if (conditions == null)
                throw new ArgumentNullException("conditions");
            
            return ScanAsync<T>(conditions, null);
        }
        
        /// <summary>
        ///  Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="conditions">
        /// Conditions that the results should meet.
        /// </param>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig)
        {
            if (conditions == null)
                throw new ArgumentNullException("conditions");
            
            var scan = ConvertScan<T>(conditions, operationConfig);
            return FromSearchAsync<T>(scan);
        }
        
        /// <summary>
        ///  Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig)
        {
            return FromScanAsync<T>(scanConfig, null);
        }
        
        /// <summary>
        ///  Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig)
        {
            if (scanConfig == null) throw new ArgumentNullException("scanConfig");
            
            var scan = ConvertFromScan<T>(scanConfig, operationConfig);
            return FromSearchAsync<T>(scan);
        }
        
        #endregion
        
        #region Query async
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> QueryAsync<T>(object hashKeyValue)
        {
            var query = ConvertQueryByValue<T>(hashKeyValue, null, null);
            return FromSearchAsync<T>(query);
        }
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig)
        {
            ContextSearch query = ConvertQueryByValue<T>(hashKeyValue, null, operationConfig);
            return FromSearchAsync<T>(query);
        }
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified range element condition for a hash-and-range primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <param name="op">Operation of the condition.</param>
        /// <param name="values">
        /// Value(s) of the condition.
        /// For all operations except QueryOperator.Between, values should be one value.
        /// For QueryOperator.Between, values should be two values.
        /// </param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, params object[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentOutOfRangeException("values");
            
            return QueryAsync<T>(hashKeyValue, op, values, null);
        }
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified range element condition for a hash-and-range primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <param name="op">Operation of the condition.</param>
        /// <param name="values">
        /// Value(s) of the condition.
        /// For all operations except QueryOperator.Between, values should be one value.
        /// For QueryOperator.Between, values should be two values.
        /// </param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            
            ContextSearch query = ConvertQueryByValue<T>(hashKeyValue, op, values, operationConfig);
            return FromSearchAsync<T>(query);
        }
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig)
        {
            return FromQueryAsync<T>(queryConfig, null);
        }
        
        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        public AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig)
        {
            if (queryConfig == null) throw new ArgumentNullException("queryConfig");
            
            var query = ConvertFromQuery<T>(queryConfig, operationConfig);
            return FromSearchAsync<T>(query);
        }
        
        #endregion
    }
}
