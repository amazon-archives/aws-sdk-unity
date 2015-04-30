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

using Amazon.Runtime;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;

namespace Amazon.S3
{
    public partial interface IAmazonS3
    {
        #region PostObjects
        /// <summary>
        /// Upload data to Amazon S3 using HTTP POST.
        /// </summary>
        /// <remarks>
        /// For more information, <see href="http://docs.aws.amazon.com/AmazonS3/latest/dev/UsingHTTPPOST.html"/>
        /// </remarks>
        /// <param name="request">Request object which describes the data to POST</param>
        void PostObjectAsync(PostObjectRequest request,AmazonServiceCallback<PostObjectRequest,PostObjectResponse> callback,  AsyncOptions options = null);
        
        #endregion
    }
}
                                                                                                                                                                                  