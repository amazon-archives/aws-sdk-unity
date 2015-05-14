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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Internal.Transform;

using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Class for unmarshalling S3 service responses
    /// </summary>
    public abstract class S3ReponseUnmarshaller : XmlResponseUnmarshaller
    {
        private static string AMZ_ID_2 = "x-amz-id-2";

        public override UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics)
        {
            if (response.IsHeaderPresent(AMZ_ID_2))
                metrics.AddProperty(Metric.AmzId2, response.GetHeaderValue(AMZ_ID_2));
            return base.CreateContext(response, readEntireResponse, stream, metrics);
        }

        public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
        {
            // Unmarshall response
            var response = base.Unmarshall(input);

            // Make sure ResponseMetadata is set
            if (response.ResponseMetadata == null)
                response.ResponseMetadata = new ResponseMetadata();

            // Populate AmazonId2
            response.ResponseMetadata.Metadata.Add(AMZ_ID_2, input.ResponseData.GetHeaderValue(AMZ_ID_2));
            return response;
        }

        protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response)
        {
            return new S3UnmarshallerContext(responseStream, maintainResponseBody, response);
        }

        public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            var errorResponse = Amazon.S3.Model.Internal.MarshallTransformations.S3ErrorResponseUnmarshaller.Instance.Unmarshall(context);
            var s3Exception = new Amazon.S3.AmazonS3Exception(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode, errorResponse.Id2);

            if (errorResponse.ParsingException != null)
            {
                var body = context.ResponseBody;
                if (!string.IsNullOrEmpty(body))
                {
                    s3Exception.ResponseBody = body;
                }
            }

            return s3Exception;
        }
    }
}
