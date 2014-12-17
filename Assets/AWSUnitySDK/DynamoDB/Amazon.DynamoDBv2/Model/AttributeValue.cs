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
    /// Represents the data for an attribute. You can set one, and only one, of the elements.
    /// </summary>
    public partial class AttributeValue
    {
        private MemoryStream _b;
        private List<MemoryStream> _bS = new List<MemoryStream>();
        private string _n;
        private List<string> _nS = new List<string>();
        private string _s;
        private List<string> _sS = new List<string>();


        /// <summary>
        /// Gets and sets the property B. 
        /// <para>
        /// A Binary data type
        /// </para>
        /// </summary>
        public MemoryStream B
        {
            get { return this._b; }
            set { this._b = value; }
        }

        // Check to see if B property is set
        internal bool IsSetB()
        {
            return this._b != null;
        }


        /// <summary>
        /// Gets and sets the property BS. 
        /// <para>
        /// A Binary set data type
        /// </para>
        /// </summary>
        public List<MemoryStream> BS
        {
            get { return this._bS; }
            set { this._bS = value; }
        }

        // Check to see if BS property is set
        internal bool IsSetBS()
        {
            return this._bS != null && this._bS.Count > 0; 
        }


        /// <summary>
        /// Gets and sets the property N. 
        /// <para>
        /// A Number data type
        /// </para>
        /// </summary>
        public string N
        {
            get { return this._n; }
            set { this._n = value; }
        }

        // Check to see if N property is set
        internal bool IsSetN()
        {
            return this._n != null;
        }


        /// <summary>
        /// Gets and sets the property NS. 
        /// <para>
        ///  Number set data type
        /// </para>
        /// </summary>
        public List<string> NS
        {
            get { return this._nS; }
            set { this._nS = value; }
        }

        // Check to see if NS property is set
        internal bool IsSetNS()
        {
            return this._nS != null && this._nS.Count > 0; 
        }


        /// <summary>
        /// Gets and sets the property S. 
        /// <para>
        /// A String data type
        /// </para>
        /// </summary>
        public string S
        {
            get { return this._s; }
            set { this._s = value; }
        }

        // Check to see if S property is set
        internal bool IsSetS()
        {
            return this._s != null;
        }


        /// <summary>
        /// Gets and sets the property SS. 
        /// <para>
        /// A String set data type
        /// </para>
        /// </summary>
        public List<string> SS
        {
            get { return this._sS; }
            set { this._sS = value; }
        }

        // Check to see if SS property is set
        internal bool IsSetSS()
        {
            return this._sS != null && this._sS.Count > 0; 
        }

    }
}