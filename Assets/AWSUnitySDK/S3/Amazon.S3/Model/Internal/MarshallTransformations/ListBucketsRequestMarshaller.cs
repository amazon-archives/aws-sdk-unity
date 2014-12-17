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
    /// List Buckets Request Marshaller
    /// </summary>       
    public class ListBucketsRequestMarshaller : IMarshaller<IRequest, ListBucketsRequest>
    {
        public IRequest Marshall(ListBucketsRequest listBucketsRequest)
        {
            IRequest request = new DefaultRequest(listBucketsRequest, "AmazonS3");

            request.HttpMethod = "GET";

            request.ResourcePath = "/";
            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
