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

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Container for the parameters to the PutLifecycleConfiguration operation.
    /// <para>Sets lifecycle configuration for your bucket. If a lifecycle configuration exists, it replaces it.</para>
    /// </summary>
    public partial class PutLifecycleConfigurationRequest : AmazonWebServiceRequest
    {
        private string bucketName;
        private LifecycleConfiguration lifecycleConfiguration;

        /// <summary>
        /// The name of the bucket to have the lifecycle configuration applied.
        /// </summary>
        public string BucketName
        {
            get { return this.bucketName; }
            set { this.bucketName = value; }
        }

        // Check to see if BucketName property is set
        internal bool IsSetBucketName()
        {
            return this.bucketName != null;
        }

        /// <summary>
        /// The lifecycle configuration to be applied.
        /// </summary>
        public LifecycleConfiguration Configuration
        {
            get { return this.lifecycleConfiguration; }
            set { this.lifecycleConfiguration = value; }
        }

        // Check to see if Configuration property is set
        internal bool IsSetConfiguration()
        {
            return this.lifecycleConfiguration != null;
        }

    }
}
    
