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
    /// Unity specific implementation of the ErrorHandler class.
    /// </summary>
    /// <typeparam name="T">The default exception type to be thrown.</typeparam>
    public class ErrorHandler<T> : ErrorHandler where T : AmazonServiceException, new()
    {
        /// <summary>
        /// Constructor for ErrorHandler.
        /// </summary>
        /// <param name="logger">an ILogger instance.</param>
        public ErrorHandler(ILogger logger) : base (logger)
        {
            this.Logger = logger;

            this.ExceptionHandlers = new Dictionary<Type, IExceptionHandler>
            {                
                {typeof(UnityHttpErrorResponseException), new UnityHttpErrorResponseExceptionHandler<T>(this.Logger)}
            };
        }
    }
}