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
    /// Response Unmarshaller for WriteRequest Object
    /// </summary>  
    public class WriteRequestUnmarshaller : IUnmarshaller<WriteRequest, XmlUnmarshallerContext>, IUnmarshaller<WriteRequest, JsonUnmarshallerContext>
    {
        WriteRequest IUnmarshaller<WriteRequest, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
            throw new NotImplementedException();
        }

        public WriteRequest Unmarshall(JsonUnmarshallerContext context)
        {
            context.Read();
            if (context.CurrentTokenType == JsonToken.Null) 
                return null;

            WriteRequest unmarshalledObject = new WriteRequest();
        
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("DeleteRequest", targetDepth))
                {
                    var unmarshaller = DeleteRequestUnmarshaller.Instance;
                    unmarshalledObject.DeleteRequest = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("PutRequest", targetDepth))
                {
                    var unmarshaller = PutRequestUnmarshaller.Instance;
                    unmarshalledObject.PutRequest = unmarshaller.Unmarshall(context);
                    continue;
                }
            }
          
            return unmarshalledObject;
        }


        private static WriteRequestUnmarshaller _instance = new WriteRequestUnmarshaller();        

        public static WriteRequestUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}