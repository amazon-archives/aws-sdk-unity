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

using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace Amazon.DynamoDBv2.DataModel
{
    /// <summary>
    /// Context interface for using the DataModel mode of DynamoDB.
    /// Used to interact with the service, save/load objects, etc.
    /// </summary>
    partial interface IDynamoDBContext
    {
        
        #region Save async
        
        /// <summary>
        /// Initiates the asynchronous execution of the Save operation.
        /// Saves an object to DynamoDB.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to save as.</typeparam>
        /// <param name="value">Object to save.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void SaveAsync<T>(T value, AmazonDynamoCallback<VoidResponse> callback, object state);
        
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
        void SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state);
        
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
        /// <returns>void.</returns>
        void LoadAsync<T>(object hashKey, AmazonDynamoCallback<T> callback, object state);
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given hash-and-range primary key.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="rangeKey">Range key element of the target item.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void.</returns>
        void LoadAsync<T>(object hashKey, object rangeKey, AmazonDynamoCallback<T> callback, object state);
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given hash primary key and using the given config.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void.</returns>
        void LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state);
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given hash-and-range primary key and using the given config.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="rangeKey">Range key element of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void.</returns>
        void LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state);
        
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given key.
        /// The keyObject is a partially-specified instance, where the
        /// hash/range properties are equal to the key of the item you
        /// want to load.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="keyObject">Key of the target item.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void.</returns>
        void LoadAsync<T>(T keyObject, AmazonDynamoCallback<T> callback, object state);
        /// <summary>
        /// Initiates the asynchronous execution of the Load operation.
        /// Loads an object from DynamoDB for the given key and using the given config.
        /// The keyObject is a partially-specified instance, where the
        /// hash/range properties are equal to the key of the item you
        /// want to load.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="keyObject">Key of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void.</returns>
        void LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<T> callback, object state);
        
        #endregion
        
        #region Delete async
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// Deletes an item in DynamoDB corresponding to given object.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// If SkipVersionCheck=false, will check version of object before deleting.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(T value, AmazonDynamoCallback<VoidResponse> callback, object state);
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// Deletes an item in DynamoDB corresponding to given object.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// If SkipVersionCheck=false, will check version of object before deleting.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to delete.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state);
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// Deletes an item in DynamoDB corresponding to a given hash primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(object hashKey, AmazonDynamoCallback<VoidResponse> callback, object state);
        
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
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state);
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation.
        /// Deletes an item in DynamoDB corresponding to a given hash primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="rangeKey">Range key element of the object to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(object hashKey, object rangeKey, AmazonDynamoCallback<VoidResponse> callback, object state);
        
        /// <summary>
        /// Initiates the asynchronous execution of the Delete operation
        /// Deletes an item in DynamoDB corresponding to a given hash-and-range primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="rangeKey">Range key element of the object to delete.</param>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, AmazonDynamoCallback<VoidResponse> callback, object state);
        
        #endregion
        
        #region BatchGet async
        
        /// <summary>
        /// Initiates the asynchronous execution of the ExecuteBatchGet operation.
        /// Issues a batch-get request with multiple batches.
        /// 
        /// Results are stored in the individual batches.
        /// </summary>
        /// <param name="batches">Configured BatchGet objects</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndExecuteBatchGet
        ///         operation.</returns>
        void ExecuteBatchGetAsync(BatchGet[] batches, AmazonDynamoCallback<VoidResponse> callback, object state);
        
        #endregion
        
        #region BatchWrite async
        
        /// <summary>
        /// Initiates the asynchronous execution of the ExecuteBatchWrite operation.
        /// Issues a batch-write request with multiple batches.
        /// </summary>
        /// <param name="batches">Configured BatchWrite objects</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndDelete
        ///         operation.</returns>
        void ExecuteBatchWriteAsync(BatchWrite[] batches, AmazonDynamoCallback<VoidResponse> callback, object state);
        
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
        AsyncSearch<T> ScanAsync<T>(params ScanCondition[] conditions);

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
        AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig);

        /// <summary>
        ///  Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig);

        /// <summary>
        ///  Configures an async Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig);

        #endregion

        #region Query async

        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> QueryAsync<T>(object hashKeyValue);

        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig);

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
        AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, params object[] values);

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
        AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig);

        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig);

        /// <summary>
        /// Configures an async Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>AsyncSearch which can be used to retrieve DynamoDB data.</returns>
        AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig);

        #endregion
    }
}
