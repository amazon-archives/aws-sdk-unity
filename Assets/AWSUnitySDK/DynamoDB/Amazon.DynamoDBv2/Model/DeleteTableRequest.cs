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
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.DynamoDBv2.Model
{
    /// <summary>
    /// Container for the parameters to the DeleteTable operation.
    /// The <i>DeleteTable</i> operation deletes a table and all of its items. After a   
    ///     <i>DeleteTable</i> request, the specified table is in the <code>DELETING</code>
    /// state until      DynamoDB completes the deletion. If the table is in the <code>ACTIVE</code>
    /// state, you can delete      it. If a table is in <code>CREATING</code> or <code>UPDATING</code>
    /// states, then DynamoDB returns      a <i>ResourceInUseException</i>. If the specified
    /// table does not exist, DynamoDB returns a        <i>ResourceNotFoundException</i>.
    /// If table is already in the <code>DELETING</code> state, no      error is returned.
    /// 
    /// 
    ///     <note>      
    /// <para>
    /// DynamoDB might continue to accept data read and write operations, such as <i>GetItem</i>
    /// and          <i>PutItem</i>, on a table in the <code>DELETING</code> state until the
    /// table deletion is        complete.
    /// </para>
    ///     </note>    
    /// <para>
    /// When you delete a table, any indexes on that table are also deleted.
    /// </para>
    ///     
    /// <para>
    /// Use the <i>DescribeTable</i> API to check the status of the table. 
    /// </para>
    /// </summary>
    public partial class DeleteTableRequest : AmazonDynamoDBRequest
    {
        private string _tableName;


        /// <summary>
        /// Gets and sets the property TableName. 
        /// <para>
        ///  The name of the table to delete.
        /// </para>
        /// </summary>
        public string TableName
        {
            get { return this._tableName; }
            set { this._tableName = value; }
        }

        // Check to see if TableName property is set
        internal bool IsSetTableName()
        {
            return this._tableName != null;
        }

    }
}