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
    /// Response Unmarshaller for ItemCollectionMetrics Object
    /// </summary>  
    public class ItemCollectionMetricsUnmarshaller : IUnmarshaller<ItemCollectionMetrics, XmlUnmarshallerContext>, IUnmarshaller<ItemCollectionMetrics, JsonUnmarshallerContext>
    {
        ItemCollectionMetrics IUnmarshaller<ItemCollectionMetrics, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
            throw new NotImplementedException();
        }

        public ItemCollectionMetrics Unmarshall(JsonUnmarshallerContext context)
        {
            context.Read();
            if (context.CurrentTokenType == JsonToken.Null) 
                return null;

            ItemCollectionMetrics unmarshalledObject = new ItemCollectionMetrics();
        
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("ItemCollectionKey", targetDepth))
                {
                    var unmarshaller = new DictionaryUnmarshaller<string, AttributeValue, StringUnmarshaller, AttributeValueUnmarshaller>(StringUnmarshaller.Instance, AttributeValueUnmarshaller.Instance);
                    unmarshalledObject.ItemCollectionKey = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("SizeEstimateRangeGB", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<double, DoubleUnmarshaller>(DoubleUnmarshaller.Instance);
                    unmarshalledObject.SizeEstimateRangeGB = unmarshaller.Unmarshall(context);
                    continue;
                }
            }
          
            return unmarshalledObject;
        }


        private static ItemCollectionMetricsUnmarshaller _instance = new ItemCollectionMetricsUnmarshaller();        

        public static ItemCollectionMetricsUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}