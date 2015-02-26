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

namespace Amazon.MobileAnalytics.Model
{
    /// <summary>
    /// Container for the parameters to the PutEvents operation.
    /// Record a batch of events
    /// </summary>
    public partial class PutEventsRequest : AmazonMobileAnalyticsRequest
    {
        private string _clientContext;
        private string _clientContextEncoding;
        private List<Event> _events = new List<Event>();


        /// <summary>
        /// Gets and sets the property ClientContext.
        /// </summary>
        public string ClientContext
        {
            get { return this._clientContext; }
            set { this._clientContext = value; }
        }

        // Check to see if ClientContext property is set
        internal bool IsSetClientContext()
        {
            return this._clientContext != null;
        }

        public string ClientContextEncoding
        {
            get {return this._clientContextEncoding;}
            set {this._clientContextEncoding = value;}
        }

        internal bool IsSetClientContextEncoding()
        {
            return this._clientContextEncoding != null;
        }

        /// <summary>
        /// Gets and sets the property Events.
        /// </summary>
        public List<Event> Events
        {
            get { return this._events; }
            set { this._events = value; }
        }

        // Check to see if Events property is set
        internal bool IsSetEvents()
        {
            return this._events != null && this._events.Count > 0; 
        }

    }
}