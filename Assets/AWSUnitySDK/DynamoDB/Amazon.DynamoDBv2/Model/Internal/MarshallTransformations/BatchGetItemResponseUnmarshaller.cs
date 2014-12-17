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
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.DynamoDBv2.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for BatchGetItem operation
    /// </summary>  
    public class BatchGetItemResponseUnmarshaller : JsonResponseUnmarshaller
    {
        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
            BatchGetItemResponse response = new BatchGetItemResponse();

            context.Read();
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("ConsumedCapacity", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<ConsumedCapacity, ConsumedCapacityUnmarshaller>(ConsumedCapacityUnmarshaller.Instance);
                    response.ConsumedCapacity = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("Responses", targetDepth))
                {
                    var unmarshaller = new DictionaryUnmarshaller<string, List<Dictionary<string, AttributeValue>>, StringUnmarshaller, ListUnmarshaller<Dictionary<string, AttributeValue>, DictionaryUnmarshaller<string, AttributeValue, StringUnmarshaller, AttributeValueUnmarshaller>>>(StringUnmarshaller.Instance, new ListUnmarshaller<Dictionary<string, AttributeValue>, DictionaryUnmarshaller<string, AttributeValue, StringUnmarshaller, AttributeValueUnmarshaller>>(new DictionaryUnmarshaller<string, AttributeValue, StringUnmarshaller, AttributeValueUnmarshaller>(StringUnmarshaller.Instance, AttributeValueUnmarshaller.Instance)));
                    response.Responses = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("UnprocessedKeys", targetDepth))
                {
                    var unmarshaller = new DictionaryUnmarshaller<string, KeysAndAttributes, StringUnmarshaller, KeysAndAttributesUnmarshaller>(StringUnmarshaller.Instance, KeysAndAttributesUnmarshaller.Instance);
                    response.UnprocessedKeys = unmarshaller.Unmarshall(context);
                    continue;
                }
            }
 

            return response;
        }

        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals("InternalServerError"))
            {
                return new InternalServerErrorException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals("ProvisionedThroughputExceededException"))
            {
                return new ProvisionedThroughputExceededException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals("ResourceNotFoundException"))
            {
                return new ResourceNotFoundException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            return new AmazonDynamoDBException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
        }

        private static BatchGetItemResponseUnmarshaller _instance = new BatchGetItemResponseUnmarshaller();        

        internal static BatchGetItemResponseUnmarshaller GetInstance()
        {
            return _instance;
        }
        public static BatchGetItemResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}