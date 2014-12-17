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

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Util;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Amazon.DynamoDBv2.DocumentModel
{
    public partial class Table
    {
        #region PutItemAsync
        
        /// <summary>
        /// Initiates the asynchronous execution of the PutItem operation.
        /// Puts a document into DynamoDB.
        /// Returns updated Document in callback
        /// </summary>
        /// <param name="doc">Document to save.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void PutItemAsync(Document doc , AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => PutItemHelper(doc, null, true), "PutItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the PutItem operation.
        /// Puts a document into DynamoDB, using specified configs.
        /// Returns updated Document in callback
        /// </summary>
        /// <param name="doc">Document to save.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void PutItemAsync(Document doc , PutItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => PutItemHelper(doc, config, true), "PutItemAsync", callback, state);
        }
        
        #endregion
        
        #region GetItemAsync
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Gets a document from DynamoDB by hash primary key.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(Primitive hashKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(hashKey, null), null, true), "GetItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(Primitive hashKey, Primitive rangeKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(hashKey, rangeKey), null, true), "GetItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(Primitive hashKey, GetItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(hashKey, null), config, true), "GetItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(Primitive hashKey, Primitive rangeKey, GetItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(hashKey, rangeKey), config, true), "GetItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="key">Key of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(IDictionary<string, DynamoDBEntry> key, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(key), null, true), "GetItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// Returns the Document from DynamoDB in callback
        /// </summary>
        /// <param name="key">Ley of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void GetItemAsync(IDictionary<string, DynamoDBEntry> key, GetItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => GetItemHelper(MakeKey(key), config, true), "GetItemAsync", callback, state);
        }
        
        #endregion
        
        #region UpdateItemAsync
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Document to update.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(doc), null, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , Primitive hashKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(hashKey, null), null, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , Primitive hashKey, Primitive rangeKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(hashKey, rangeKey), null, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="key">Key of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , IDictionary<string, DynamoDBEntry> key, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(key), null, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Document to update.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , UpdateItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(doc), config, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , Primitive hashKey, UpdateItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(hashKey, null), config, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , Primitive hashKey, Primitive rangeKey, UpdateItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(hashKey, rangeKey), config, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="key">Key of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void UpdateItemAsync(Document doc , IDictionary<string, DynamoDBEntry> key, UpdateItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => UpdateHelper(doc, MakeKey(key), config, true), "UpdateItemAsync", callback, state);
        }
        
        /// <summary>
        /// Finishes the asynchronous execution of the GetItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.Table.UpdateItem"/>
        /// </summary>
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginUpdateItem.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        public Document EndUpdateItem(IAsyncResult asyncResult)
        {
            return DynamoDBAsyncExecutor.EndOperation<Document>(asyncResult);
        }
        
        #endregion
        
        #region DeleteItemAsync
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="document">Document to delete.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Document document, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => { DeleteHelper(MakeKey(document), null, true); return null; }, "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Primitive hashKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => { DeleteHelper(MakeKey(hashKey, null), null, true); return null; }, "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Primitive hashKey, Primitive rangeKey, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => { DeleteHelper(MakeKey(hashKey, rangeKey), null, true); return null; }, "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="key">Key of the document.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(IDictionary<string, DynamoDBEntry> key, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => { DeleteHelper(MakeKey(key), null, true); return null; }, "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="document">Document to delete.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Document document, DeleteItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => DeleteHelper(MakeKey(document), config, true), "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Primitive hashKey, DeleteItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => DeleteHelper(MakeKey(hashKey, null), config, true), "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(Primitive hashKey, Primitive rangeKey, DeleteItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => DeleteHelper(MakeKey(hashKey, rangeKey), config, true), "DeleteItemAsync", callback, state);
        }
        
        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// 
        /// </summary>
        /// <param name="key">Key of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <param name="callback">An AmazonDynamoCallback delegate that is invoked when the operation completes.</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        public void DeleteItemAsync(IDictionary<string, DynamoDBEntry> key, DeleteItemOperationConfig config, AmazonDynamoCallback<Document> callback, object state)
        {
            DynamoDBAsyncExecutor.AsyncOperation<Document>(() => DeleteHelper(MakeKey(key), config, true), "DeleteItemAsync", callback, state);
        }
        
        #endregion
        
    }
}
