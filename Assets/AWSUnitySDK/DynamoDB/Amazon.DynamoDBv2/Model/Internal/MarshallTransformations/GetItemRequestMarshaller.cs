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
    /// GetItem Request Marshaller
    /// </summary>       
    public class GetItemRequestMarshaller : IMarshaller<IRequest, GetItemRequest> 
    {
        public IRequest Marshall(GetItemRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.GetItem";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";

            string uriResourcePath = "/";
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetAttributesToGet())
                {
                    writer.WritePropertyName("AttributesToGet");
                    writer.WriteArrayStart();
                    foreach(var publicRequestAttributesToGetListValue in publicRequest.AttributesToGet)
                    {
                        writer.Write(publicRequestAttributesToGetListValue);
                    }
                    writer.WriteArrayEnd();
                }

                if(publicRequest.IsSetConsistentRead())
                {
                    writer.WritePropertyName("ConsistentRead");
                    writer.Write(publicRequest.ConsistentRead);
                }

                if(publicRequest.IsSetKey())
                {
                    writer.WritePropertyName("Key");
                    writer.WriteObjectStart();
                    foreach (var publicRequestKeyKvp in publicRequest.Key)
                    {
                        writer.WritePropertyName(publicRequestKeyKvp.Key);
                        var publicRequestKeyValue = publicRequestKeyKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestKeyValue.IsSetB())
                        {
                            writer.WritePropertyName("B");
                            writer.Write(StringUtils.FromMemoryStream(publicRequestKeyValue.B));
                        }

                        if(publicRequestKeyValue.IsSetBS())
                        {
                            writer.WritePropertyName("BS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestKeyValueBSListValue in publicRequestKeyValue.BS)
                            {
                                writer.Write(StringUtils.FromMemoryStream(publicRequestKeyValueBSListValue));
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestKeyValue.IsSetN())
                        {
                            writer.WritePropertyName("N");
                            writer.Write(publicRequestKeyValue.N);
                        }

                        if(publicRequestKeyValue.IsSetNS())
                        {
                            writer.WritePropertyName("NS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestKeyValueNSListValue in publicRequestKeyValue.NS)
                            {
                                writer.Write(publicRequestKeyValueNSListValue);
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestKeyValue.IsSetS())
                        {
                            writer.WritePropertyName("S");
                            writer.Write(publicRequestKeyValue.S);
                        }

                        if(publicRequestKeyValue.IsSetSS())
                        {
                            writer.WritePropertyName("SS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestKeyValueSSListValue in publicRequestKeyValue.SS)
                            {
                                writer.Write(publicRequestKeyValueSSListValue);
                            }
                            writer.WriteArrayEnd();
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteObjectEnd();
                }

                if(publicRequest.IsSetReturnConsumedCapacity())
                {
                    writer.WritePropertyName("ReturnConsumedCapacity");
                    writer.Write(publicRequest.ReturnConsumedCapacity);
                }

                if(publicRequest.IsSetTableName())
                {
                    writer.WritePropertyName("TableName");
                    writer.Write(publicRequest.TableName);
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}