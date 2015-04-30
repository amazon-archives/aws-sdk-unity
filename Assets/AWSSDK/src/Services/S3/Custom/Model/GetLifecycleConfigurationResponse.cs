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

using Amazon.Runtime;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Returns information about the  GetLifecycleConfiguration response and response metadata.
    /// </summary>
    public class GetLifecycleConfigurationResponse : AmazonWebServiceResponse
    {

        private LifecycleConfiguration configuration;

        /// <summary>
        /// Gets and Sets the property that governs whether
        /// the response includes successful deletes as well as errors
        /// following the DeleteObjects call against S3.
        /// 
        /// By default this property is false and successful deletes
        /// are returned in the response.
        /// </summary>
        public LifecycleConfiguration Configuration
        {
            get 
            {
                if (this.configuration == null)
                    this.configuration = new LifecycleConfiguration();

                return this.configuration; 
            }
            set { this.configuration = value; }
        }
    }
}
    
