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
    /// Represents attributes that are copied (projected) from the table into an index. These
    /// are in      addition to the primary key attributes and index key attributes, which
    /// are automatically      projected.
    /// </summary>
    public partial class Projection
    {
        private List<string> _nonKeyAttributes = new List<string>();
        private ProjectionType _projectionType;


        /// <summary>
        /// Gets and sets the property NonKeyAttributes. 
        /// <para>
        /// Represents the non-key attribute names which will be projected into the index.
        /// </para>
        ///     
        /// <para>
        /// For local secondary indexes, the total count of <i>NonKeyAttributes</i> summed across
        /// all of the local secondary indexes,      must not exceed 20. If you project the same
        /// attribute into two      different indexes, this counts as two distinct attributes
        /// when determining the total.
        /// </para>
        /// </summary>
        public List<string> NonKeyAttributes
        {
            get { return this._nonKeyAttributes; }
            set { this._nonKeyAttributes = value; }
        }

        // Check to see if NonKeyAttributes property is set
        internal bool IsSetNonKeyAttributes()
        {
            return this._nonKeyAttributes != null && this._nonKeyAttributes.Count > 0; 
        }


        /// <summary>
        /// Gets and sets the property ProjectionType. 
        /// <para>
        /// The set of attributes that are projected into the index:
        /// </para>
        ///     <ul>      <li>        
        /// <para>
        /// <code>KEYS_ONLY</code> - Only the index and primary keys are projected into the  
        ///        index.
        /// </para>
        ///       </li>      <li>        
        /// <para>
        /// <code>INCLUDE</code> - Only the specified table attributes are projected into the
        /// index.          The list of projected attributes are in <i>NonKeyAttributes</i>.
        /// </para>
        ///       </li>      <li>        
        /// <para>
        /// <code>ALL</code> - All of the table attributes are projected into the index.
        /// </para>
        ///       </li>    </ul>
        /// </summary>
        public ProjectionType ProjectionType
        {
            get { return this._projectionType; }
            set { this._projectionType = value; }
        }

        // Check to see if ProjectionType property is set
        internal bool IsSetProjectionType()
        {
            return this._projectionType != null;
        }

    }
}