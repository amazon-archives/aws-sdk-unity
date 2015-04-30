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

using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Get Bucket Versioning Request Marshaller
    /// </summary>       
    public class GetBucketVersioningRequestMarshaller : IMarshaller<IRequest, GetBucketVersioningRequest> ,IMarshaller<IRequest,Amazon.Runtime.AmazonWebServiceRequest>
	{
		public IRequest Marshall(Amazon.Runtime.AmazonWebServiceRequest input)
		{
			return this.Marshall((GetBucketVersioningRequest)input);
		}

        public IRequest Marshall(GetBucketVersioningRequest getBucketVersioningRequest)
        {
            IRequest request = new DefaultRequest(getBucketVersioningRequest, "AmazonS3");

            request.HttpMethod = "GET";

            request.ResourcePath = string.Concat("/", S3Transforms.ToStringValue(getBucketVersioningRequest.BucketName));
            request.AddSubResource("versioning");
            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
