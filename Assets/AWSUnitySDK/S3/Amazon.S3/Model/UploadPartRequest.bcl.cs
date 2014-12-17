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

namespace Amazon.S3.Model
{
    /// <summary>
    /// The parameters to request upload of a part in a multipart upload operation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If PartSize is not specified then the rest of the content from the file
    /// or stream will be sent to Amazon S3.
    /// </para>
    /// <para>
    /// You must set either the FilePath or InputStream.  If FilePath is set then the FilePosition
    /// property must be set.
    /// </para>
    /// </remarks>
    public partial class UploadPartRequest : AmazonWebServiceRequest
    {
        internal void SetupForFilePath()
        {
            var fileStream = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            fileStream.Position = this.FilePosition;
            this.InputStream = fileStream;
        }
    }
}
