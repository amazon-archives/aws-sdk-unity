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
    /// Scan Request Marshaller
    /// </summary>       
    public class ScanRequestMarshaller : IMarshaller<IRequest, ScanRequest> 
    {
        public IRequest Marshall(ScanRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.Scan";
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

                if(publicRequest.IsSetConditionalOperator())
                {
                    writer.WritePropertyName("ConditionalOperator");
                    writer.Write(publicRequest.ConditionalOperator);
                }

                if(publicRequest.IsSetExclusiveStartKey())
                {
                    writer.WritePropertyName("ExclusiveStartKey");
                    writer.WriteObjectStart();
                    foreach (var publicRequestExclusiveStartKeyKvp in publicRequest.ExclusiveStartKey)
                    {
                        writer.WritePropertyName(publicRequestExclusiveStartKeyKvp.Key);
                        var publicRequestExclusiveStartKeyValue = publicRequestExclusiveStartKeyKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestExclusiveStartKeyValue.IsSetB())
                        {
                            writer.WritePropertyName("B");
                            writer.Write(StringUtils.FromMemoryStream(publicRequestExclusiveStartKeyValue.B));
                        }

                        if(publicRequestExclusiveStartKeyValue.IsSetBS())
                        {
                            writer.WritePropertyName("BS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestExclusiveStartKeyValueBSListValue in publicRequestExclusiveStartKeyValue.BS)
                            {
                                writer.Write(StringUtils.FromMemoryStream(publicRequestExclusiveStartKeyValueBSListValue));
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestExclusiveStartKeyValue.IsSetN())
                        {
                            writer.WritePropertyName("N");
                            writer.Write(publicRequestExclusiveStartKeyValue.N);
                        }

                        if(publicRequestExclusiveStartKeyValue.IsSetNS())
                        {
                            writer.WritePropertyName("NS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestExclusiveStartKeyValueNSListValue in publicRequestExclusiveStartKeyValue.NS)
                            {
                                writer.Write(publicRequestExclusiveStartKeyValueNSListValue);
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestExclusiveStartKeyValue.IsSetS())
                        {
                            writer.WritePropertyName("S");
                            writer.Write(publicRequestExclusiveStartKeyValue.S);
                        }

                        if(publicRequestExclusiveStartKeyValue.IsSetSS())
                        {
                            writer.WritePropertyName("SS");
                            writer.WriteArrayStart();
                            foreach(var publicRequestExclusiveStartKeyValueSSListValue in publicRequestExclusiveStartKeyValue.SS)
                            {
                                writer.Write(publicRequestExclusiveStartKeyValueSSListValue);
                            }
                            writer.WriteArrayEnd();
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteObjectEnd();
                }

                if(publicRequest.IsSetLimit())
                {
                    writer.WritePropertyName("Limit");
                    writer.Write(publicRequest.Limit);
                }

                if(publicRequest.IsSetReturnConsumedCapacity())
                {
                    writer.WritePropertyName("ReturnConsumedCapacity");
                    writer.Write(publicRequest.ReturnConsumedCapacity);
                }

                if(publicRequest.IsSetScanFilter())
                {
                    writer.WritePropertyName("ScanFilter");
                    writer.WriteObjectStart();
                    foreach (var publicRequestScanFilterKvp in publicRequest.ScanFilter)
                    {
                        writer.WritePropertyName(publicRequestScanFilterKvp.Key);
                        var publicRequestScanFilterValue = publicRequestScanFilterKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestScanFilterValue.IsSetAttributeValueList())
                        {
                            writer.WritePropertyName("AttributeValueList");
                            writer.WriteArrayStart();
                            foreach(var publicRequestScanFilterValueAttributeValueListListValue in publicRequestScanFilterValue.AttributeValueList)
                            {
                                writer.WriteObjectStart();
                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetB())
                                {
                                    writer.WritePropertyName("B");
                                    writer.Write(StringUtils.FromMemoryStream(publicRequestScanFilterValueAttributeValueListListValue.B));
                                }

                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetBS())
                                {
                                    writer.WritePropertyName("BS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestScanFilterValueAttributeValueListListValueBSListValue in publicRequestScanFilterValueAttributeValueListListValue.BS)
                                    {
                                        writer.Write(StringUtils.FromMemoryStream(publicRequestScanFilterValueAttributeValueListListValueBSListValue));
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetN())
                                {
                                    writer.WritePropertyName("N");
                                    writer.Write(publicRequestScanFilterValueAttributeValueListListValue.N);
                                }

                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetNS())
                                {
                                    writer.WritePropertyName("NS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestScanFilterValueAttributeValueListListValueNSListValue in publicRequestScanFilterValueAttributeValueListListValue.NS)
                                    {
                                        writer.Write(publicRequestScanFilterValueAttributeValueListListValueNSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetS())
                                {
                                    writer.WritePropertyName("S");
                                    writer.Write(publicRequestScanFilterValueAttributeValueListListValue.S);
                                }

                                if(publicRequestScanFilterValueAttributeValueListListValue.IsSetSS())
                                {
                                    writer.WritePropertyName("SS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestScanFilterValueAttributeValueListListValueSSListValue in publicRequestScanFilterValueAttributeValueListListValue.SS)
                                    {
                                        writer.Write(publicRequestScanFilterValueAttributeValueListListValueSSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                writer.WriteObjectEnd();
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestScanFilterValue.IsSetComparisonOperator())
                        {
                            writer.WritePropertyName("ComparisonOperator");
                            writer.Write(publicRequestScanFilterValue.ComparisonOperator);
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteObjectEnd();
                }

                if(publicRequest.IsSetSegment())
                {
                    writer.WritePropertyName("Segment");
                    writer.Write(publicRequest.Segment);
                }

                if(publicRequest.IsSetSelect())
                {
                    writer.WritePropertyName("Select");
                    writer.Write(publicRequest.Select);
                }

                if(publicRequest.IsSetTableName())
                {
                    writer.WritePropertyName("TableName");
                    writer.Write(publicRequest.TableName);
                }

                if(publicRequest.IsSetTotalSegments())
                {
                    writer.WritePropertyName("TotalSegments");
                    writer.Write(publicRequest.TotalSegments);
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}