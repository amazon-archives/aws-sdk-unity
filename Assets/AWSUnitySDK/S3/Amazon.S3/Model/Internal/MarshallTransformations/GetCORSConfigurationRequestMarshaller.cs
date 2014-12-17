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
    /// Get Bucket Cors Request Marshaller
    /// </summary>       
    public class GetCORSConfigurationRequestMarshaller : IMarshaller<IRequest, GetCORSConfigurationRequest>
    {
        public IRequest Marshall(GetCORSConfigurationRequest getCORSConfigurationRequest)
        {
            IRequest request = new DefaultRequest(getCORSConfigurationRequest, "AmazonS3");

            request.Suppress404Exceptions = true;
            request.HttpMethod = "GET";

            request.ResourcePath = string.Concat("/", S3Transforms.ToStringValue(getCORSConfigurationRequest.BucketName));
            request.AddSubResource("cors");
            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
