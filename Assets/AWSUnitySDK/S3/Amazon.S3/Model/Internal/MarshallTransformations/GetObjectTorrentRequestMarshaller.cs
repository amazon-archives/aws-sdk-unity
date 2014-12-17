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

using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using System.Globalization;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Get Object Torrent Request Marshaller
    /// </summary>       
    public class GetObjectTorrentRequestMarshaller : IMarshaller<IRequest, GetObjectTorrentRequest>
    {
        public IRequest Marshall(GetObjectTorrentRequest getObjectTorrentRequest)
        {
            IRequest request = new DefaultRequest(getObjectTorrentRequest, "AmazonS3");

            request.HttpMethod = "GET";

            request.ResourcePath = string.Format(CultureInfo.InvariantCulture, "/{0}/{1}",
                                                 S3Transforms.ToStringValue(getObjectTorrentRequest.BucketName),
                                                 S3Transforms.ToStringValue(getObjectTorrentRequest.Key));

            request.AddSubResource("torrent");
            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
