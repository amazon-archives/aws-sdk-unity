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
    /// BatchGetItem Request Marshaller
    /// </summary>       
    public class BatchGetItemRequestMarshaller : IMarshaller<IRequest, BatchGetItemRequest> 
    {
        public IRequest Marshall(BatchGetItemRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.BatchGetItem";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";

            string uriResourcePath = "/";
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetRequestItems())
                {
                    writer.WritePropertyName("RequestItems");
                    writer.WriteObjectStart();
                    foreach (var publicRequestRequestItemsKvp in publicRequest.RequestItems)
                    {
                        writer.WritePropertyName(publicRequestRequestItemsKvp.Key);
                        var publicRequestRequestItemsValue = publicRequestRequestItemsKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestRequestItemsValue.IsSetAttributesToGet())
                        {
                            writer.WritePropertyName("AttributesToGet");
                            writer.WriteArrayStart();
                            foreach(var publicRequestRequestItemsValueAttributesToGetListValue in publicRequestRequestItemsValue.AttributesToGet)
                            {
                                writer.Write(publicRequestRequestItemsValueAttributesToGetListValue);
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestRequestItemsValue.IsSetConsistentRead())
                        {
                            writer.WritePropertyName("ConsistentRead");
                            writer.Write(publicRequestRequestItemsValue.ConsistentRead);
                        }

                        if(publicRequestRequestItemsValue.IsSetKeys())
                        {
                            writer.WritePropertyName("Keys");
                            writer.WriteArrayStart();
                            foreach(var publicRequestRequestItemsValueKeysListValue in publicRequestRequestItemsValue.Keys)
                            {
                                writer.WriteObjectStart();
                                foreach (var publicRequestRequestItemsValueKeysListValueKvp in publicRequestRequestItemsValueKeysListValue)
                                {
                                    writer.WritePropertyName(publicRequestRequestItemsValueKeysListValueKvp.Key);
                                    var publicRequestRequestItemsValueKeysListValueValue = publicRequestRequestItemsValueKeysListValueKvp.Value;

                                    writer.WriteObjectStart();
                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetB())
                                    {
                                        writer.WritePropertyName("B");
                                        writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueKeysListValueValue.B));
                                    }

                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetBS())
                                    {
                                        writer.WritePropertyName("BS");
                                        writer.WriteArrayStart();
                                        foreach(var publicRequestRequestItemsValueKeysListValueValueBSListValue in publicRequestRequestItemsValueKeysListValueValue.BS)
                                        {
                                            writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueKeysListValueValueBSListValue));
                                        }
                                        writer.WriteArrayEnd();
                                    }

                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetN())
                                    {
                                        writer.WritePropertyName("N");
                                        writer.Write(publicRequestRequestItemsValueKeysListValueValue.N);
                                    }

                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetNS())
                                    {
                                        writer.WritePropertyName("NS");
                                        writer.WriteArrayStart();
                                        foreach(var publicRequestRequestItemsValueKeysListValueValueNSListValue in publicRequestRequestItemsValueKeysListValueValue.NS)
                                        {
                                            writer.Write(publicRequestRequestItemsValueKeysListValueValueNSListValue);
                                        }
                                        writer.WriteArrayEnd();
                                    }

                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetS())
                                    {
                                        writer.WritePropertyName("S");
                                        writer.Write(publicRequestRequestItemsValueKeysListValueValue.S);
                                    }

                                    if(publicRequestRequestItemsValueKeysListValueValue.IsSetSS())
                                    {
                                        writer.WritePropertyName("SS");
                                        writer.WriteArrayStart();
                                        foreach(var publicRequestRequestItemsValueKeysListValueValueSSListValue in publicRequestRequestItemsValueKeysListValueValue.SS)
                                        {
                                            writer.Write(publicRequestRequestItemsValueKeysListValueValueSSListValue);
                                        }
                                        writer.WriteArrayEnd();
                                    }

                                    writer.WriteObjectEnd();
                                }
                                writer.WriteObjectEnd();
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

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}