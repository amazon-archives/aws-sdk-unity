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

        #region Save/serialize

        /// <summary>
        /// Saves an object to DynamoDB.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to save as.</typeparam>
        /// <param name="value">Object to save.</param>
        internal void Save<T>(T value)
        {
            DynamoDBAsyncExecutor.IsMainThread("SaveAsync");
            Save(value, null);
        }

        /// <summary>
        /// Saves an object to DynamoDB using passed-in configs.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to save as.</typeparam>
        /// <param name="value">Object to save.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        internal void Save<T>(T value, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("SaveAsync");
            SaveHelper<T>(value, operationConfig, false);
        }

        #endregion

        #region Load/deserialize

        /// <summary>
        /// Loads an object from DynamoDB for the given hash primary key.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(object hashKey)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return Load<T>(hashKey, null, null);
        }

        /// <summary>
        /// Loads an object from DynamoDB for the given hash primary key and using the given config.
        /// 
        /// Passed-in config overrides DynamoDBContextConfig on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(object hashKey, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return Load<T>(hashKey, null, operationConfig);
        }

        /// <summary>
        /// Loads an object from DynamoDB for the given hash-and-range primary key.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type to populate.</typeparam>
        /// <param name="hashKey">Hash key element of the target item.</param>
        /// <param name="rangeKey">Range key element of the target item.</param>
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(object hashKey, object rangeKey)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return Load<T>(hashKey, rangeKey, null);
        }

        /// <summary>
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
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return LoadHelper<T>(hashKey, rangeKey, operationConfig, false);
        }

        /// <summary>
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
        /// <param name="keyObject">Key object defining the the target item.</param>
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(T keyObject)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return Load<T>(keyObject, null);
        }

        /// <summary>
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
        /// <param name="keyObject">Key object defining the the target item.</param>
        /// <param name="operationConfig">Overriding configuration.</param>
        /// <returns>
        /// Object of type T, populated with properties of item loaded from DynamoDB.
        /// </returns>
        internal T Load<T>(T keyObject, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("LoadAsync");
            return LoadHelper<T>(keyObject, operationConfig, false);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes an item in DynamoDB corresponding to given object.
        /// 
        /// Uses DynamoDBContextConfig configured on the context.
        /// If SkipVersionCheck=false, will check version of object before deleting.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to delete.</param>
        internal void Delete<T>(T value)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            Delete<T>(value, null);
        }

        /// <summary>
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
        internal void Delete<T>(T value, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            DeleteHelper<T>(value, operationConfig, false);
        }

        /// <summary>
        /// Deletes an item in DynamoDB corresponding to a given hash primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        internal void Delete<T>(object hashKey)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            Delete<T>(hashKey, null);
        }

        /// <summary>
        /// Deletes an item in DynamoDB corresponding to a given hash primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        internal void Delete<T>(object hashKey, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            Delete<T>(hashKey, null, operationConfig);
        }

        /// <summary>
        /// Deletes an item in DynamoDB corresponding to a given hash-and-range primary key.
        /// 
        /// No version check is done prior to delete.
        /// Type must be marked up with DynamoDBTableAttribute and at least
        /// one public field/property with DynamoDBHashKeyAttribute.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKey">Hash key element of the object to delete.</param>
        /// <param name="rangeKey">Range key element of the object to delete.</param>
        internal void Delete<T>(object hashKey, object rangeKey)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            Delete<T>(hashKey, rangeKey, null);
        }

        /// <summary>
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
        internal void Delete<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("DeleteAsync");
            DeleteHelper<T>(hashKey, rangeKey, operationConfig, false);
        }

        #endregion

        #region BatchGet

        /// <summary>
        /// Creates a strongly-typed BatchGet object, allowing
        /// a batch-get operation against DynamoDB.
        /// </summary>
        /// <typeparam name="T">Type of objects to get</typeparam>
        /// <returns>Empty strongly-typed BatchGet object</returns>
        public BatchGet<T> CreateBatchGet<T>()
        {
            return CreateBatchGet<T>(null);
        }

        /// <summary>
        /// Creates a strongly-typed BatchGet object, allowing
        /// a batch-get operation against DynamoDB.
        /// </summary>
        /// <typeparam name="T">Type of objects to get</typeparam>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <returns>Empty strongly-typed BatchGet object</returns>
        public BatchGet<T> CreateBatchGet<T>(DynamoDBOperationConfig operationConfig)
        {
            DynamoDBFlatConfig config = new DynamoDBFlatConfig(operationConfig, this.Config);
            return new BatchGet<T>(this, config);
        }

        /// <summary>
        /// Creates a MultiTableBatchGet object, composed of multiple
        /// individual BatchGet objects.
        /// </summary>
        /// <param name="batches">Individual BatchGet objects</param>
        /// <returns>Composite MultiTableBatchGet object</returns>
        public MultiTableBatchGet CreateMultiTableBatchGet(params BatchGet[] batches)
        {
            return new MultiTableBatchGet(batches);
        }

        /// <summary>
        /// Issues a batch-get request with multiple batches.
        /// 
        /// Results are stored in the individual batches.
        /// </summary>
        /// <param name="batches">
        /// Configured BatchGet objects
        /// </param>
        internal void ExecuteBatchGet(params BatchGet[] batches)
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteBatchGetAsync");
            MultiTableBatchGet superBatch = new MultiTableBatchGet(batches);
            superBatch.Execute();
        }

        #endregion

        #region Batch Write

        /// <summary>
        /// Creates a strongly-typed BatchWrite object, allowing
        /// a batch-write operation against DynamoDB.
        /// </summary>
        /// <typeparam name="T">Type of objects to write</typeparam>
        /// <returns>Empty strongly-typed BatchWrite object</returns>
        public BatchWrite<T> CreateBatchWrite<T>()
        {
            return CreateBatchWrite<T>(null);
        }

        /// <summary>
        /// Creates a strongly-typed BatchWrite object, allowing
        /// a batch-write operation against DynamoDB.
        /// </summary>
        /// <typeparam name="T">Type of objects to write</typeparam>
        /// <param name="operationConfig">Config object which can be used to override that table used.</param>
        /// <returns>Empty strongly-typed BatchWrite object</returns>
        public BatchWrite<T> CreateBatchWrite<T>(DynamoDBOperationConfig operationConfig)
        {
            DynamoDBFlatConfig config = new DynamoDBFlatConfig(operationConfig, this.Config);
            return new BatchWrite<T>(this, config);
        }

        /// <summary>
        /// Creates a MultiTableBatchWrite object, composed of multiple
        /// individual BatchWrite objects.
        /// </summary>
        /// <param name="batches">Individual BatchWrite objects</param>
        /// <returns>Composite MultiTableBatchWrite object</returns>
        public MultiTableBatchWrite CreateMultiTableBatchWrite(params BatchWrite[] batches)
        {
            return new MultiTableBatchWrite(batches);
        }

        /// <summary>
        /// Issues a batch-write request with multiple batches.
        /// </summary>
        /// <param name="batches">
        /// Configured BatchWrite objects
        /// </param>
        internal void ExecuteBatchWrite(params BatchWrite[] batches)
        {
            DynamoDBAsyncExecutor.IsMainThread("ExecuteBatchWriteAsync");
            MultiTableBatchWrite superBatch = new MultiTableBatchWrite(batches);
            superBatch.Execute();
        }

        #endregion

        #region Scan

        /// <summary>
        /// Executes a Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="conditions">
        /// Conditions that the results should meet.
        /// </param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Scan<T>(params ScanCondition[] conditions)
        {
            DynamoDBAsyncExecutor.IsMainThread("ScanAsync");
            if (conditions == null)
                throw new ArgumentNullException("conditions");

            return Scan<T>(conditions, null);
        }

        /// <summary>
        /// Executes a Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="conditions">
        /// Conditions that the results should meet.
        /// </param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Scan<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("ScanAsync");
            if (conditions == null)
                throw new ArgumentNullException("conditions");

            var scan = ConvertScan<T>(conditions, operationConfig);
            return FromSearch<T>(scan);
        }

        /// <summary>
        /// Executes a Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> FromScan<T>(ScanOperationConfig scanConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("FromScanAsync");
            return FromScan<T>(scanConfig, null);
        }

        /// <summary>
        /// Executes a Scan operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="scanConfig">Scan request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> FromScan<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("FromScanAsync");
            if (scanConfig == null) throw new ArgumentNullException("scanConfig");

            var scan = ConvertFromScan<T>(scanConfig, operationConfig);
            return FromSearch<T>(scan);
        }

        #endregion

        #region Query

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Query<T>(object hashKeyValue)
        {
            DynamoDBAsyncExecutor.IsMainThread("QueryAsync");
            var query = ConvertQueryByValue<T>(hashKeyValue, null, null);
            return FromSearch<T>(query);
        }

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
        /// that match the specified hash primary key.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="hashKeyValue">Hash key of the items to query.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Query<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("QueryAsync");
            var query = ConvertQueryByValue<T>(hashKeyValue, null, operationConfig);
            return FromSearch<T>(query);
        }

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
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
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Query<T>(object hashKeyValue, QueryOperator op, params object[] values)
        {
            DynamoDBAsyncExecutor.IsMainThread("QueryAsync");
            if (values == null || values.Length == 0)
                throw new ArgumentOutOfRangeException("values");

            return Query<T>(hashKeyValue, op, values, null);
        }

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
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
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> Query<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("QueryAsync");
            if (values == null)
                throw new ArgumentNullException("values");

            var query = ConvertQueryByValue<T>(hashKeyValue, op, values, operationConfig);
            return FromSearch<T>(query);
        }

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> FromQuery<T>(QueryOperationConfig queryConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("FromQueryAsync");
            return FromQuery<T>(queryConfig, null);
        }

        /// <summary>
        /// Executes a Query operation against DynamoDB, finding items
        /// that match the specified conditions.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="queryConfig">Query request object.</param>
        /// <param name="operationConfig">Config object which can be used to override the table used.</param>
        /// <returns>Lazy-loaded collection of results.</returns>
        internal IEnumerable<T> FromQuery<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig)
        {
            DynamoDBAsyncExecutor.IsMainThread("FromQueryAsync");
            if (queryConfig == null) throw new ArgumentNullException("queryConfig");

            var search = ConvertFromQuery<T>(queryConfig, operationConfig);
            return FromSearch<T>(search);
        }

        #endregion

        #region Table methods

        /// <summary>
        /// Retrieves the target table for the specified type
        /// </summary>
        /// <typeparam name="T">Type to retrieve table for</typeparam>
        /// <returns>Table object</returns>
        public Table GetTargetTable<T>()
        {
            return GetTargetTable<T>(null);
        }

        /// <summary>
        /// Retrieves the target table for the specified type
        /// </summary>
        /// <typeparam name="T">Type to retrieve table for</typeparam>
        /// <returns>Table object</returns>
        public Table GetTargetTable<T>(DynamoDBOperationConfig operationConfig)
        {
            return GetTargetTableInternal<T>(operationConfig);
        }

        #endregion
    }
}
