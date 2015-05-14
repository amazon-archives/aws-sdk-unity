//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Amazon.S3.Model
{
    /// <summary>
    /// This class contains the mfa codes used authentication
    /// </summary>
    public class MfaCodes
    {
        /// <summary>
        /// Gets and sets the serial number of the authentication device
        /// </summary>
        public string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets the displated value on the authentication device
        /// </summary>
        public string AuthenticationValue
        {
            get;
            set;
        }

        /// <summary>
        /// The formatted string of the mfa codes to be passed to S3.
        /// </summary>
        public string FormattedMfaCodes
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0} {1}", SerialNumber, AuthenticationValue); }
        }
    }
}
