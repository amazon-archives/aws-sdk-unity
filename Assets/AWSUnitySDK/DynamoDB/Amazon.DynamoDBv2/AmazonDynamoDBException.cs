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
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Amazon.Runtime;

namespace Amazon.DynamoDBv2
{
    public class AmazonDynamoDBException : AmazonServiceException
    {
        public AmazonDynamoDBException(string message)
            : base(message)
        {
        }

        public AmazonDynamoDBException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AmazonDynamoDBException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        public AmazonDynamoDBException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, errorType, errorCode, requestId, statusCode)
        {
        }

        public AmazonDynamoDBException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, innerException, errorType, errorCode, requestId, statusCode)
        {
        }
    }
}