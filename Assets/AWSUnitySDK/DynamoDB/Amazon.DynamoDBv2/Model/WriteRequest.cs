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
    /// Represents an operation to perform - either <i>DeleteItem</i> or <i>PutItem</i>. You
    /// can only      specify one of these operations, not both, in a single <i>WriteRequest</i>.
    /// If you do need to      perform both of these operations, you will need to specify
    /// two separate <i>WriteRequest</i>      objects.
    /// </summary>
    public partial class WriteRequest
    {
        private DeleteRequest _deleteRequest;
        private PutRequest _putRequest;


        /// <summary>
        /// Gets and sets the property DeleteRequest. 
        /// <para>
        /// A request to perform a <i>DeleteItem</i> operation.
        /// </para>
        /// </summary>
        public DeleteRequest DeleteRequest
        {
            get { return this._deleteRequest; }
            set { this._deleteRequest = value; }
        }

        // Check to see if DeleteRequest property is set
        internal bool IsSetDeleteRequest()
        {
            return this._deleteRequest != null;
        }


        /// <summary>
        /// Gets and sets the property PutRequest. 
        /// <para>
        /// A request to perform a <i>PutItem</i> operation.
        /// </para>
        /// </summary>
        public PutRequest PutRequest
        {
            get { return this._putRequest; }
            set { this._putRequest = value; }
        }

        // Check to see if PutRequest property is set
        internal bool IsSetPutRequest()
        {
            return this._putRequest != null;
        }

    }
}