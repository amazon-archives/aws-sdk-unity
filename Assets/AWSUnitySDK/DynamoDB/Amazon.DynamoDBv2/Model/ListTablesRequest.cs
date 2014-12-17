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
    /// Container for the parameters to the ListTables operation.
    /// Returns an array of table names associated with the current account and endpoint.
    /// The output      from <i>ListTables</i> is paginated, with each page returning a maximum
    /// of 100 table      names.
    /// </summary>
    public partial class ListTablesRequest : AmazonDynamoDBRequest
    {
        private string _exclusiveStartTableName;
        private int? _limit;


        /// <summary>
        /// Gets and sets the property ExclusiveStartTableName. 
        /// <para>
        /// The first table name that this operation will evaluate. Use the value that was returned
        /// for        <i>LastEvaluatedTableName</i> in a previous operation, so that you can
        /// obtain the next page      of results.
        /// </para>
        /// </summary>
        public string ExclusiveStartTableName
        {
            get { return this._exclusiveStartTableName; }
            set { this._exclusiveStartTableName = value; }
        }

        // Check to see if ExclusiveStartTableName property is set
        internal bool IsSetExclusiveStartTableName()
        {
            return this._exclusiveStartTableName != null;
        }


        /// <summary>
        /// Gets and sets the property Limit. 
        /// <para>
        ///  A maximum number of table names to return. If this parameter is not specified, the
        /// limit is      100.
        /// </para>
        /// </summary>
        public int Limit
        {
            get { return this._limit.GetValueOrDefault(); }
            set { this._limit = value; }
        }

        // Check to see if Limit property is set
        internal bool IsSetLimit()
        {
            return this._limit.HasValue; 
        }

    }
}