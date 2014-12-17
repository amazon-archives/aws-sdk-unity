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
using System.Threading;

using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;


namespace Amazon.DynamoDBv2
{
    /// <summary>
    /// Implementation for accessing AmazonDynamoDBv2.
    ///  
    /// Amazon DynamoDB <b>Overview</b> <para>This is the Amazon DynamoDB API Reference. This guide provides descriptions and samples of the Amazon
    /// DynamoDB API. </para>
    /// </summary>
    public partial class AmazonDynamoDBClient : AmazonWebServiceClient, IAmazonDynamoDB
    {

        /// <summary>
        /// Override the pausing function so retries would happen more frequent then the default operation.
        /// </summary>
        /// <param name="retries">Current number of retries.</param>
        protected override void pauseExponentially(int retries)
        {
            int delay = (retries == 0) ? 0 : 50 * (int)Math.Pow(2, retries - 1);
            delay = Math.Min(delay, MAX_BACKOFF_IN_MILLISECONDS);
            Amazon.Util.AWSSDKUtils.Sleep(delay);
        }
    }
}
