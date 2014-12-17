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
    /// <summary>Routing Rule
    /// </summary>
    public class RoutingRule
    {

        private RoutingRuleCondition condition;
        private RoutingRuleRedirect redirect;

        /// <summary>
        /// A container for describing a condition that must be met for the specified redirect to apply. For example, 1. If request is for pages in the
        /// /docs folder, redirect to the /documents folder. 2. If request results in HTTP error 4xx, redirect request to another host where you might
        /// process the error.
        ///  
        /// </summary>
        public RoutingRuleCondition Condition
        {
            get { return this.condition; }
            set { this.condition = value; }
        }

        // Check to see if Condition property is set
        internal bool IsSetCondition()
        {
            return this.condition != null;
        }

        /// <summary>
        /// Container for redirect information. You can redirect requests to another host, to another page, or with another protocol. In the event of an
        /// error, you can can specify a different error code to return.
        ///  
        /// </summary>
        public RoutingRuleRedirect Redirect
        {
            get { return this.redirect; }
            set { this.redirect = value; }
        }

        // Check to see if Redirect property is set
        internal bool IsSetRedirect()
        {
            return this.redirect != null;
        }
    }
}
