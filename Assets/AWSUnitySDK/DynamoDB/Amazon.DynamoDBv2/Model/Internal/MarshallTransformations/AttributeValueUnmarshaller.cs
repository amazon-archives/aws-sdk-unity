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
    /// Response Unmarshaller for AttributeValue Object
    /// </summary>  
    public class AttributeValueUnmarshaller : IUnmarshaller<AttributeValue, XmlUnmarshallerContext>, IUnmarshaller<AttributeValue, JsonUnmarshallerContext>
    {
        AttributeValue IUnmarshaller<AttributeValue, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
            throw new NotImplementedException();
        }

        public AttributeValue Unmarshall(JsonUnmarshallerContext context)
        {
            context.Read();
            if (context.CurrentTokenType == JsonToken.Null) 
                return null;

            AttributeValue unmarshalledObject = new AttributeValue();
        
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("B", targetDepth))
                {
                    var unmarshaller = MemoryStreamUnmarshaller.Instance;
                    unmarshalledObject.B = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("BS", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<MemoryStream, MemoryStreamUnmarshaller>(MemoryStreamUnmarshaller.Instance);
                    unmarshalledObject.BS = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("N", targetDepth))
                {
                    var unmarshaller = StringUnmarshaller.Instance;
                    unmarshalledObject.N = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("NS", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<string, StringUnmarshaller>(StringUnmarshaller.Instance);
                    unmarshalledObject.NS = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("S", targetDepth))
                {
                    var unmarshaller = StringUnmarshaller.Instance;
                    unmarshalledObject.S = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("SS", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<string, StringUnmarshaller>(StringUnmarshaller.Instance);
                    unmarshalledObject.SS = unmarshaller.Unmarshall(context);
                    continue;
                }
            }
          
            return unmarshalledObject;
        }


        private static AttributeValueUnmarshaller _instance = new AttributeValueUnmarshaller();        

        public static AttributeValueUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}