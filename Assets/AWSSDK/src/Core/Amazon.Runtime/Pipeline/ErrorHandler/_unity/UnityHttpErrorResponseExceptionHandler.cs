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

using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Amazon.Runtime.Internal
{
    /// <summary>
    /// The exception handler for UnityHttpErrorResponseException.
    /// </summary>
    public class UnityHttpErrorResponseExceptionHandler<T> : ExceptionHandler<UnityHttpErrorResponseException>
        where T : AmazonServiceException, new()
    {
        
        /// <summary>
        /// The constructor for UnityHttpErrorResponseExceptionHandler.
        /// </summary>
        /// <param name="logger">Instance of ILogger.</param>
        public UnityHttpErrorResponseExceptionHandler(ILogger logger) :
            base(logger)
        {
        }


        /// <summary>
        /// Handles an exception for the given execution context.
        /// </summary>
        /// <param name="executionContext">The execution context, it contains the
        /// request and response context.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <returns>
        /// Returns a boolean value which indicates if the original exception
        /// should be rethrown.
        /// This method can also throw a new exception to replace the original exception.
        /// </returns>
        public override bool HandleException(IExecutionContext executionContext, UnityHttpErrorResponseException exception)
        {
            LogCurlRequest(exception.Request);

            var requestContext = executionContext.RequestContext;
            var httpErrorResponse = exception.Response;

            var errorResponse = new ErrorResponse();
            if (httpErrorResponse.IsHeaderPresent(HeaderKeys.XAmzRequestIdHeader))
            {
                errorResponse.RequestId = httpErrorResponse.GetHeaderValue(HeaderKeys.XAmzRequestIdHeader);
                requestContext.Metrics.AddProperty(Metric.AWSRequestID, httpErrorResponse.GetHeaderValue(HeaderKeys.XAmzRequestIdHeader));
            }

            if (httpErrorResponse.IsHeaderPresent(HeaderKeys.XAmzErrorTypeHeader))
            {
                errorResponse.Code = httpErrorResponse.GetHeaderValue(HeaderKeys.XAmzErrorTypeHeader);
            }

            if (httpErrorResponse.IsHeaderPresent(HeaderKeys.XAmzId2Header))
            {
                requestContext.Metrics.AddProperty(Metric.AmzId2, httpErrorResponse.GetHeaderValue(HeaderKeys.XAmzId2Header));
            }

            requestContext.Metrics.AddProperty(Metric.StatusCode, httpErrorResponse.StatusCode);

            Exception unmarshalledException = null;
            var unmarshaller = requestContext.Unmarshaller as ISimplifiedErrorUnmarshaller;
            if (unmarshaller != null)
            {
                unmarshalledException = unmarshaller.UnmarshallException(httpErrorResponse, errorResponse, exception);
                throw unmarshalledException;
            }
            else
            {
                var baseServiceException = new T();
                baseServiceException.RequestId = errorResponse.RequestId;
                baseServiceException.ErrorCode = errorResponse.Code;
                baseServiceException.StatusCode = httpErrorResponse.StatusCode;
                throw baseServiceException;
            }
        }


        private void LogCurlRequest(UnityWebRequest request)
        {
            string curl = "curl " + (request.Method == "GET" ? "-G " : "-X POST ");
            foreach (string key in request.Headers.Keys)
            {
                curl += " -H \"" + key + ": " + request.Headers[key] + "\" ";
            }
            if (request.RequestContent != null)
                curl += " -d '" + System.Text.Encoding.Default.GetString(request.RequestContent) + "' ";

            curl += " " + request.RequestUri;
            this.Logger.DebugFormat("{0}", curl);
        }

    }
}
