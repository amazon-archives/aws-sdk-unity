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
    /// BatchWriteItem Request Marshaller
    /// </summary>       
    public class BatchWriteItemRequestMarshaller : IMarshaller<IRequest, BatchWriteItemRequest> 
    {
        public IRequest Marshall(BatchWriteItemRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.BatchWriteItem";
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

                        writer.WriteArrayStart();
                        foreach(var publicRequestRequestItemsValueListValue in publicRequestRequestItemsValue)
                        {
                            writer.WriteObjectStart();
                            if(publicRequestRequestItemsValueListValue.IsSetDeleteRequest())
                            {
                                writer.WritePropertyName("DeleteRequest");
                                writer.WriteObjectStart();
                                if(publicRequestRequestItemsValueListValue.DeleteRequest.IsSetKey())
                                {
                                    writer.WritePropertyName("Key");
                                    writer.WriteObjectStart();
                                    foreach (var publicRequestRequestItemsValueListValueDeleteRequestKeyKvp in publicRequestRequestItemsValueListValue.DeleteRequest.Key)
                                    {
                                        writer.WritePropertyName(publicRequestRequestItemsValueListValueDeleteRequestKeyKvp.Key);
                                        var publicRequestRequestItemsValueListValueDeleteRequestKeyValue = publicRequestRequestItemsValueListValueDeleteRequestKeyKvp.Value;

                                        writer.WriteObjectStart();
                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetB())
                                        {
                                            writer.WritePropertyName("B");
                                            writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.B));
                                        }

                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetBS())
                                        {
                                            writer.WritePropertyName("BS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValueDeleteRequestKeyValueBSListValue in publicRequestRequestItemsValueListValueDeleteRequestKeyValue.BS)
                                            {
                                                writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueListValueDeleteRequestKeyValueBSListValue));
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetN())
                                        {
                                            writer.WritePropertyName("N");
                                            writer.Write(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.N);
                                        }

                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetNS())
                                        {
                                            writer.WritePropertyName("NS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValueDeleteRequestKeyValueNSListValue in publicRequestRequestItemsValueListValueDeleteRequestKeyValue.NS)
                                            {
                                                writer.Write(publicRequestRequestItemsValueListValueDeleteRequestKeyValueNSListValue);
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetS())
                                        {
                                            writer.WritePropertyName("S");
                                            writer.Write(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.S);
                                        }

                                        if(publicRequestRequestItemsValueListValueDeleteRequestKeyValue.IsSetSS())
                                        {
                                            writer.WritePropertyName("SS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValueDeleteRequestKeyValueSSListValue in publicRequestRequestItemsValueListValueDeleteRequestKeyValue.SS)
                                            {
                                                writer.Write(publicRequestRequestItemsValueListValueDeleteRequestKeyValueSSListValue);
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        writer.WriteObjectEnd();
                                    }
                                    writer.WriteObjectEnd();
                                }

                                writer.WriteObjectEnd();
                            }

                            if(publicRequestRequestItemsValueListValue.IsSetPutRequest())
                            {
                                writer.WritePropertyName("PutRequest");
                                writer.WriteObjectStart();
                                if(publicRequestRequestItemsValueListValue.PutRequest.IsSetItem())
                                {
                                    writer.WritePropertyName("Item");
                                    writer.WriteObjectStart();
                                    foreach (var publicRequestRequestItemsValueListValuePutRequestItemKvp in publicRequestRequestItemsValueListValue.PutRequest.Item)
                                    {
                                        writer.WritePropertyName(publicRequestRequestItemsValueListValuePutRequestItemKvp.Key);
                                        var publicRequestRequestItemsValueListValuePutRequestItemValue = publicRequestRequestItemsValueListValuePutRequestItemKvp.Value;

                                        writer.WriteObjectStart();
                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetB())
                                        {
                                            writer.WritePropertyName("B");
                                            writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueListValuePutRequestItemValue.B));
                                        }

                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetBS())
                                        {
                                            writer.WritePropertyName("BS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValuePutRequestItemValueBSListValue in publicRequestRequestItemsValueListValuePutRequestItemValue.BS)
                                            {
                                                writer.Write(StringUtils.FromMemoryStream(publicRequestRequestItemsValueListValuePutRequestItemValueBSListValue));
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetN())
                                        {
                                            writer.WritePropertyName("N");
                                            writer.Write(publicRequestRequestItemsValueListValuePutRequestItemValue.N);
                                        }

                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetNS())
                                        {
                                            writer.WritePropertyName("NS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValuePutRequestItemValueNSListValue in publicRequestRequestItemsValueListValuePutRequestItemValue.NS)
                                            {
                                                writer.Write(publicRequestRequestItemsValueListValuePutRequestItemValueNSListValue);
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetS())
                                        {
                                            writer.WritePropertyName("S");
                                            writer.Write(publicRequestRequestItemsValueListValuePutRequestItemValue.S);
                                        }

                                        if(publicRequestRequestItemsValueListValuePutRequestItemValue.IsSetSS())
                                        {
                                            writer.WritePropertyName("SS");
                                            writer.WriteArrayStart();
                                            foreach(var publicRequestRequestItemsValueListValuePutRequestItemValueSSListValue in publicRequestRequestItemsValueListValuePutRequestItemValue.SS)
                                            {
                                                writer.Write(publicRequestRequestItemsValueListValuePutRequestItemValueSSListValue);
                                            }
                                            writer.WriteArrayEnd();
                                        }

                                        writer.WriteObjectEnd();
                                    }
                                    writer.WriteObjectEnd();
                                }

                                writer.WriteObjectEnd();
                            }

                            writer.WriteObjectEnd();
                        }
                        writer.WriteArrayEnd();
                    }
                    writer.WriteObjectEnd();
                }

                if(publicRequest.IsSetReturnConsumedCapacity())
                {
                    writer.WritePropertyName("ReturnConsumedCapacity");
                    writer.Write(publicRequest.ReturnConsumedCapacity);
                }

                if(publicRequest.IsSetReturnItemCollectionMetrics())
                {
                    writer.WritePropertyName("ReturnItemCollectionMetrics");
                    writer.Write(publicRequest.ReturnItemCollectionMetrics);
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}