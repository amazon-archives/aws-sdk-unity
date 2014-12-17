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

namespace Amazon.S3.Model
{
    /// <summary>
    /// A collection of up to 100 cross-origin resource sharing (CORS) rules.
    /// </summary>
    public class CORSConfiguration
    {
        
        private List<CORSRule> rules = new List<CORSRule>();

        /// <summary>
        /// The collection of rules in this configuration.
        /// </summary>
        public List<CORSRule> Rules
        {
            get { return this.rules; }
            set { this.rules = value; }
        }

        // Check to see if Rules property is set
        internal bool IsSetRules()
        {
            return this.rules.Count > 0;
        }
    }
}
