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
    /// Container for the parameters to the DeleteObjects operation.
    /// <para>This operation enables you to delete multiple objects from a bucket using a single HTTP request. You may specify up to 1000
    /// keys.</para>
    /// </summary>
    public partial class DeleteObjectsRequest : AmazonWebServiceRequest
    {

        /// <summary>
        /// Add a key to the set of keys of objects to be deleted.
        /// </summary>
        /// <param name="key">Object key</param>
        public void AddKey(string key)
        {
            AddKey(new KeyVersion { Key = key });
        }

        /// <summary>
        /// Add a key and a version to be deleted.
        /// </summary>
        /// <param name="key">Key of the object to be deleted.</param>
        /// <param name="version">Version of the object to be deleted.</param>
        public void AddKey(string key, string version)
        {
            AddKey(new KeyVersion { Key = key, VersionId = version });
        }

        /// <summary>
        /// Add a KeyVersion object representing the S3 object to be deleted.
        /// </summary>
        /// <param name="keyVersion">KeyVersion representation of object to be deleted.</param>
        private void AddKey(KeyVersion keyVersion)
        {
            if (this.Objects == null)
            {
                this.Objects = new List<KeyVersion>();
            }
            this.Objects.Add(keyVersion);
        }
    }
}
