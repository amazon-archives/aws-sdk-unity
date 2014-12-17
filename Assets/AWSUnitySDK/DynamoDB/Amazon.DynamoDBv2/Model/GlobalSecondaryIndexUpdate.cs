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
    /// Represents the new provisioned throughput settings to apply to a global secondary
    /// index.
    /// </summary>
    public partial class GlobalSecondaryIndexUpdate
    {
        private UpdateGlobalSecondaryIndexAction _update;


        /// <summary>
        /// Gets and sets the property Update. 
        /// <para>
        /// The name of a global secondary index, along with the updated provisioned throughput
        /// settings that are to be      applied to that index.
        /// </para>
        /// </summary>
        public UpdateGlobalSecondaryIndexAction Update
        {
            get { return this._update; }
            set { this._update = value; }
        }

        // Check to see if Update property is set
        internal bool IsSetUpdate()
        {
            return this._update != null;
        }

    }
}