//
// Copyright 2014-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
//
//
// Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
// You may not use this file except in compliance with the License.
// A copy of the License is located in the "license" file accompanying this file.
// See the License for the specific language governing permissions and limitations under the License.
//
//

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace Amazon.S3.Model
{
    /// <summary>Lifecycle Configuration
    /// </summary>
    public class LifecycleConfiguration
    {
        
        private List<LifecycleRule> rules = new List<LifecycleRule>();
        public List<LifecycleRule> Rules
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
