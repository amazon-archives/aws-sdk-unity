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
    /// Request Payment Configuration
    /// </summary>
    public class RequestPaymentConfiguration
    {
        
        private string payer;

        /// <summary>
        /// Specifies who pays for the download and request fees.
        /// </summary>
        public string Payer
        {
            get { return this.payer; }
            set { this.payer = value; }
        }

        // Check to see if Payer property is set
        internal bool IsSetPayer()
        {
            return this.payer != null;
        }
    }
}
