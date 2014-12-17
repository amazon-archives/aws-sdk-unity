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
    /// Query Request Marshaller
    /// </summary>       
    public class QueryRequestMarshaller : IMarshaller<IRequest, QueryRequest> 
    {
        public IRequest Marshall(QueryRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.Query";
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

                if(publicRequest.IsSetConsistentRead())
                {
                    writer.WritePropertyName("ConsistentRead");
                    writer.Write(publicRequest.ConsistentRead);
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

                if(publicRequest.IsSetIndexName())
                {
                    writer.WritePropertyName("IndexName");
                    writer.Write(publicRequest.IndexName);
                }

                if(publicRequest.IsSetKeyConditions())
                {
                    writer.WritePropertyName("KeyConditions");
                    writer.WriteObjectStart();
                    foreach (var publicRequestKeyConditionsKvp in publicRequest.KeyConditions)
                    {
                        writer.WritePropertyName(publicRequestKeyConditionsKvp.Key);
                        var publicRequestKeyConditionsValue = publicRequestKeyConditionsKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestKeyConditionsValue.IsSetAttributeValueList())
                        {
                            writer.WritePropertyName("AttributeValueList");
                            writer.WriteArrayStart();
                            foreach(var publicRequestKeyConditionsValueAttributeValueListListValue in publicRequestKeyConditionsValue.AttributeValueList)
                            {
                                writer.WriteObjectStart();
                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetB())
                                {
                                    writer.WritePropertyName("B");
                                    writer.Write(StringUtils.FromMemoryStream(publicRequestKeyConditionsValueAttributeValueListListValue.B));
                                }

                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetBS())
                                {
                                    writer.WritePropertyName("BS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestKeyConditionsValueAttributeValueListListValueBSListValue in publicRequestKeyConditionsValueAttributeValueListListValue.BS)
                                    {
                                        writer.Write(StringUtils.FromMemoryStream(publicRequestKeyConditionsValueAttributeValueListListValueBSListValue));
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetN())
                                {
                                    writer.WritePropertyName("N");
                                    writer.Write(publicRequestKeyConditionsValueAttributeValueListListValue.N);
                                }

                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetNS())
                                {
                                    writer.WritePropertyName("NS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestKeyConditionsValueAttributeValueListListValueNSListValue in publicRequestKeyConditionsValueAttributeValueListListValue.NS)
                                    {
                                        writer.Write(publicRequestKeyConditionsValueAttributeValueListListValueNSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetS())
                                {
                                    writer.WritePropertyName("S");
                                    writer.Write(publicRequestKeyConditionsValueAttributeValueListListValue.S);
                                }

                                if(publicRequestKeyConditionsValueAttributeValueListListValue.IsSetSS())
                                {
                                    writer.WritePropertyName("SS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestKeyConditionsValueAttributeValueListListValueSSListValue in publicRequestKeyConditionsValueAttributeValueListListValue.SS)
                                    {
                                        writer.Write(publicRequestKeyConditionsValueAttributeValueListListValueSSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                writer.WriteObjectEnd();
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestKeyConditionsValue.IsSetComparisonOperator())
                        {
                            writer.WritePropertyName("ComparisonOperator");
                            writer.Write(publicRequestKeyConditionsValue.ComparisonOperator);
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

                if(publicRequest.IsSetQueryFilter())
                {
                    writer.WritePropertyName("QueryFilter");
                    writer.WriteObjectStart();
                    foreach (var publicRequestQueryFilterKvp in publicRequest.QueryFilter)
                    {
                        writer.WritePropertyName(publicRequestQueryFilterKvp.Key);
                        var publicRequestQueryFilterValue = publicRequestQueryFilterKvp.Value;

                        writer.WriteObjectStart();
                        if(publicRequestQueryFilterValue.IsSetAttributeValueList())
                        {
                            writer.WritePropertyName("AttributeValueList");
                            writer.WriteArrayStart();
                            foreach(var publicRequestQueryFilterValueAttributeValueListListValue in publicRequestQueryFilterValue.AttributeValueList)
                            {
                                writer.WriteObjectStart();
                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetB())
                                {
                                    writer.WritePropertyName("B");
                                    writer.Write(StringUtils.FromMemoryStream(publicRequestQueryFilterValueAttributeValueListListValue.B));
                                }

                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetBS())
                                {
                                    writer.WritePropertyName("BS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestQueryFilterValueAttributeValueListListValueBSListValue in publicRequestQueryFilterValueAttributeValueListListValue.BS)
                                    {
                                        writer.Write(StringUtils.FromMemoryStream(publicRequestQueryFilterValueAttributeValueListListValueBSListValue));
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetN())
                                {
                                    writer.WritePropertyName("N");
                                    writer.Write(publicRequestQueryFilterValueAttributeValueListListValue.N);
                                }

                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetNS())
                                {
                                    writer.WritePropertyName("NS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestQueryFilterValueAttributeValueListListValueNSListValue in publicRequestQueryFilterValueAttributeValueListListValue.NS)
                                    {
                                        writer.Write(publicRequestQueryFilterValueAttributeValueListListValueNSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetS())
                                {
                                    writer.WritePropertyName("S");
                                    writer.Write(publicRequestQueryFilterValueAttributeValueListListValue.S);
                                }

                                if(publicRequestQueryFilterValueAttributeValueListListValue.IsSetSS())
                                {
                                    writer.WritePropertyName("SS");
                                    writer.WriteArrayStart();
                                    foreach(var publicRequestQueryFilterValueAttributeValueListListValueSSListValue in publicRequestQueryFilterValueAttributeValueListListValue.SS)
                                    {
                                        writer.Write(publicRequestQueryFilterValueAttributeValueListListValueSSListValue);
                                    }
                                    writer.WriteArrayEnd();
                                }

                                writer.WriteObjectEnd();
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestQueryFilterValue.IsSetComparisonOperator())
                        {
                            writer.WritePropertyName("ComparisonOperator");
                            writer.Write(publicRequestQueryFilterValue.ComparisonOperator);
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

                if(publicRequest.IsSetScanIndexForward())
                {
                    writer.WritePropertyName("ScanIndexForward");
                    writer.Write(publicRequest.ScanIndexForward);
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

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}