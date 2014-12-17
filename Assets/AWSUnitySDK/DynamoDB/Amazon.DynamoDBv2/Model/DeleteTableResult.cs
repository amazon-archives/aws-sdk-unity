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
    /// Represents the output of a <i>DeleteTable</i> operation.
    /// </summary>
    public partial class DeleteTableResult : AmazonWebServiceResponse
    {
        private TableDescription _tableDescription;


        /// <summary>
        /// Gets and sets the property TableDescription.
        /// </summary>
        public TableDescription TableDescription
        {
            get { return this._tableDescription; }
            set { this._tableDescription = value; }
        }

        // Check to see if TableDescription property is set
        internal bool IsSetTableDescription()
        {
            return this._tableDescription != null;
        }

    }
}