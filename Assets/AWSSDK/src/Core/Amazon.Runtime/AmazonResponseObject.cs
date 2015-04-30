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
using System.Linq;
using System.Text;

namespace Amazon.Runtime
{
    public delegate void AmazonServiceCallback<TRequest, TResponse>(AmazonServiceResult<TRequest, TResponse> responseObject)
        where TRequest : AmazonWebServiceRequest
        where TResponse : AmazonWebServiceResponse;

    public class AmazonServiceResult<TRequest, TResponse>
        where TRequest : AmazonWebServiceRequest
        where TResponse : AmazonWebServiceResponse
    {
        public TRequest Request { get; internal set; }
        public TResponse Response { get; internal set; }
        public Exception Exception { get; internal set; }
        public object state { get; internal set; }

	public AmazonServiceResult(TRequest request, TResponse response, Exception exception, object state)
        {
            this.Request = request;
            this.Response = response;
            this.Exception = exception;
            this.state = state;
        }
    }

}
