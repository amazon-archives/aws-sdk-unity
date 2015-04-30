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

/*
 * Do not modify this file. This file is generated from the cognito-identity-2014-06-30.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.CognitoIdentity
{
    public class AmazonCognitoIdentityException : AmazonServiceException
    {    
        public AmazonCognitoIdentityException() : base(ResponseUnmarshaller.GetDefaultErrorMessage<AmazonCognitoIdentityException>())
        {
        }

        public AmazonCognitoIdentityException(string message)
            : base(message)
        {
        }

        public AmazonCognitoIdentityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AmazonCognitoIdentityException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        public AmazonCognitoIdentityException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, errorType, errorCode, requestId, statusCode)
        {
        }

        public AmazonCognitoIdentityException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, innerException, errorType, errorCode, requestId, statusCode)
        {
        }
    }
}