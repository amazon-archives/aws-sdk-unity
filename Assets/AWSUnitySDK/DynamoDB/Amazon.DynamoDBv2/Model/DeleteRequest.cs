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
    /// Represents a request to perform a <i>DeleteItem</i> operation on an item.
    /// </summary>
    public partial class DeleteRequest
    {
        private Dictionary<string, AttributeValue> _key = new Dictionary<string, AttributeValue>();


        /// <summary>
        /// Gets and sets the property Key. 
        /// <para>
        /// A map of attribute name to attribute values, representing the primary key of the item
        /// to      delete. All of the table's primary key attributes must be specified, and their
        /// data types must      match those of the table's key schema.
        /// </para>
        /// </summary>
        public Dictionary<string, AttributeValue> Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        // Check to see if Key property is set
        internal bool IsSetKey()
        {
            return this._key != null && this._key.Count > 0; 
        }

    }
}