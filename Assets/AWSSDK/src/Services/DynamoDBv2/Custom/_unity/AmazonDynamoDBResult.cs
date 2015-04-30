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

using Amazon.Runtime;
using System.Threading;
using Amazon.Runtime.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.DynamoDBv2
{
    public delegate void AmazonDynamoDBCallback<T>(AmazonDynamoDBResult<T> result);    

    public delegate void AmazonDynamoDBCallback(AmazonDynamoDBResult result);

    public class AmazonDynamoDBResult<T>
    {
        public T Result { get; internal set; }

        public Exception Exception { get; internal set; }

        public object State { get; internal set; }

        public AmazonDynamoDBResult(T result, Exception exception, object state)
        {
            this.Result = result;
            this.Exception = exception;
            this.State = state;
        }
    }

    public class AmazonDynamoDBResult
    {
        public Exception Exception { get; internal set; }

        public object State { get; internal set; }

        public AmazonDynamoDBResult(object state)
        {
            this.State = state;
        }

        public AmazonDynamoDBResult(Exception exception, object state)
        {
            this.Exception = exception;
            this.State = state;
        }
    }
}
