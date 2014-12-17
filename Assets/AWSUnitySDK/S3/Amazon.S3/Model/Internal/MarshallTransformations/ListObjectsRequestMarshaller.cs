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

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// List Objects Request Marshaller
    /// </summary>       
    public class ListObjectsRequestMarshaller : IMarshaller<IRequest, ListObjectsRequest>
    {
        public IRequest Marshall(ListObjectsRequest listObjectsRequest)
        {
            IRequest request = new DefaultRequest(listObjectsRequest, "AmazonS3");

            request.HttpMethod = "GET";

            request.ResourcePath = string.Concat("/", S3Transforms.ToStringValue(listObjectsRequest.BucketName));

            if (listObjectsRequest.IsSetDelimiter())
                request.Parameters.Add("delimiter", S3Transforms.ToStringValue(listObjectsRequest.Delimiter));
            if (listObjectsRequest.IsSetMarker())
                request.Parameters.Add("marker", S3Transforms.ToStringValue(listObjectsRequest.Marker));
            if (listObjectsRequest.IsSetMaxKeys())
                request.Parameters.Add("max-keys", S3Transforms.ToStringValue(listObjectsRequest.MaxKeys));
            if (listObjectsRequest.IsSetPrefix())
                request.Parameters.Add("prefix", S3Transforms.ToStringValue(listObjectsRequest.Prefix));
            if (listObjectsRequest.IsSetEncoding())
                request.Parameters.Add("encoding-type", S3Transforms.ToStringValue(listObjectsRequest.Encoding));

            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
