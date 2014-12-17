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

using System.Linq;
using System.Net;
using Amazon.Util;
using Amazon.Runtime;

namespace Amazon.S3.Util
{
    public class S3PostUploadResponse : AmazonWebServiceResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string RequestId { get; set; }
        public string HostId { get; set; }
		public string ErrorCode { get; set;}
		public string ErrorMsg { get; set;}

        internal static S3PostUploadResponse FromWebResponse(HttpWebResponse response)
        {
            var postResponse = new S3PostUploadResponse{ StatusCode = response.StatusCode };
            if (response.Headers.AllKeys.Contains(HeaderKeys.XAmzRequestIdHeader))
                postResponse.RequestId = response.Headers[HeaderKeys.XAmzRequestIdHeader];
            if (response.Headers.AllKeys.Contains(HeaderKeys.XAmzId2Header))
                postResponse.HostId = response.Headers[HeaderKeys.XAmzId2Header];

            return postResponse;
        }
    }
}