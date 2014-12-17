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
    /// CreateTable Request Marshaller
    /// </summary>       
    public class CreateTableRequestMarshaller : IMarshaller<IRequest, CreateTableRequest> 
    {
        public IRequest Marshall(CreateTableRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.CreateTable";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";

            string uriResourcePath = "/";
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetAttributeDefinitions())
                {
                    writer.WritePropertyName("AttributeDefinitions");
                    writer.WriteArrayStart();
                    foreach(var publicRequestAttributeDefinitionsListValue in publicRequest.AttributeDefinitions)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestAttributeDefinitionsListValue.IsSetAttributeName())
                        {
                            writer.WritePropertyName("AttributeName");
                            writer.Write(publicRequestAttributeDefinitionsListValue.AttributeName);
                        }

                        if(publicRequestAttributeDefinitionsListValue.IsSetAttributeType())
                        {
                            writer.WritePropertyName("AttributeType");
                            writer.Write(publicRequestAttributeDefinitionsListValue.AttributeType);
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteArrayEnd();
                }

                if(publicRequest.IsSetGlobalSecondaryIndexes())
                {
                    writer.WritePropertyName("GlobalSecondaryIndexes");
                    writer.WriteArrayStart();
                    foreach(var publicRequestGlobalSecondaryIndexesListValue in publicRequest.GlobalSecondaryIndexes)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestGlobalSecondaryIndexesListValue.IsSetIndexName())
                        {
                            writer.WritePropertyName("IndexName");
                            writer.Write(publicRequestGlobalSecondaryIndexesListValue.IndexName);
                        }

                        if(publicRequestGlobalSecondaryIndexesListValue.IsSetKeySchema())
                        {
                            writer.WritePropertyName("KeySchema");
                            writer.WriteArrayStart();
                            foreach(var publicRequestGlobalSecondaryIndexesListValueKeySchemaListValue in publicRequestGlobalSecondaryIndexesListValue.KeySchema)
                            {
                                writer.WriteObjectStart();
                                if(publicRequestGlobalSecondaryIndexesListValueKeySchemaListValue.IsSetAttributeName())
                                {
                                    writer.WritePropertyName("AttributeName");
                                    writer.Write(publicRequestGlobalSecondaryIndexesListValueKeySchemaListValue.AttributeName);
                                }

                                if(publicRequestGlobalSecondaryIndexesListValueKeySchemaListValue.IsSetKeyType())
                                {
                                    writer.WritePropertyName("KeyType");
                                    writer.Write(publicRequestGlobalSecondaryIndexesListValueKeySchemaListValue.KeyType);
                                }

                                writer.WriteObjectEnd();
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestGlobalSecondaryIndexesListValue.IsSetProjection())
                        {
                            writer.WritePropertyName("Projection");
                            writer.WriteObjectStart();
                            if(publicRequestGlobalSecondaryIndexesListValue.Projection.IsSetNonKeyAttributes())
                            {
                                writer.WritePropertyName("NonKeyAttributes");
                                writer.WriteArrayStart();
                                foreach(var publicRequestGlobalSecondaryIndexesListValueProjectionNonKeyAttributesListValue in publicRequestGlobalSecondaryIndexesListValue.Projection.NonKeyAttributes)
                                {
                                    writer.Write(publicRequestGlobalSecondaryIndexesListValueProjectionNonKeyAttributesListValue);
                                }
                                writer.WriteArrayEnd();
                            }

                            if(publicRequestGlobalSecondaryIndexesListValue.Projection.IsSetProjectionType())
                            {
                                writer.WritePropertyName("ProjectionType");
                                writer.Write(publicRequestGlobalSecondaryIndexesListValue.Projection.ProjectionType);
                            }

                            writer.WriteObjectEnd();
                        }

                        if(publicRequestGlobalSecondaryIndexesListValue.IsSetProvisionedThroughput())
                        {
                            writer.WritePropertyName("ProvisionedThroughput");
                            writer.WriteObjectStart();
                            if(publicRequestGlobalSecondaryIndexesListValue.ProvisionedThroughput.IsSetReadCapacityUnits())
                            {
                                writer.WritePropertyName("ReadCapacityUnits");
                                writer.Write(publicRequestGlobalSecondaryIndexesListValue.ProvisionedThroughput.ReadCapacityUnits);
                            }

                            if(publicRequestGlobalSecondaryIndexesListValue.ProvisionedThroughput.IsSetWriteCapacityUnits())
                            {
                                writer.WritePropertyName("WriteCapacityUnits");
                                writer.Write(publicRequestGlobalSecondaryIndexesListValue.ProvisionedThroughput.WriteCapacityUnits);
                            }

                            writer.WriteObjectEnd();
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteArrayEnd();
                }

                if(publicRequest.IsSetKeySchema())
                {
                    writer.WritePropertyName("KeySchema");
                    writer.WriteArrayStart();
                    foreach(var publicRequestKeySchemaListValue in publicRequest.KeySchema)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestKeySchemaListValue.IsSetAttributeName())
                        {
                            writer.WritePropertyName("AttributeName");
                            writer.Write(publicRequestKeySchemaListValue.AttributeName);
                        }

                        if(publicRequestKeySchemaListValue.IsSetKeyType())
                        {
                            writer.WritePropertyName("KeyType");
                            writer.Write(publicRequestKeySchemaListValue.KeyType);
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteArrayEnd();
                }

                if(publicRequest.IsSetLocalSecondaryIndexes())
                {
                    writer.WritePropertyName("LocalSecondaryIndexes");
                    writer.WriteArrayStart();
                    foreach(var publicRequestLocalSecondaryIndexesListValue in publicRequest.LocalSecondaryIndexes)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestLocalSecondaryIndexesListValue.IsSetIndexName())
                        {
                            writer.WritePropertyName("IndexName");
                            writer.Write(publicRequestLocalSecondaryIndexesListValue.IndexName);
                        }

                        if(publicRequestLocalSecondaryIndexesListValue.IsSetKeySchema())
                        {
                            writer.WritePropertyName("KeySchema");
                            writer.WriteArrayStart();
                            foreach(var publicRequestLocalSecondaryIndexesListValueKeySchemaListValue in publicRequestLocalSecondaryIndexesListValue.KeySchema)
                            {
                                writer.WriteObjectStart();
                                if(publicRequestLocalSecondaryIndexesListValueKeySchemaListValue.IsSetAttributeName())
                                {
                                    writer.WritePropertyName("AttributeName");
                                    writer.Write(publicRequestLocalSecondaryIndexesListValueKeySchemaListValue.AttributeName);
                                }

                                if(publicRequestLocalSecondaryIndexesListValueKeySchemaListValue.IsSetKeyType())
                                {
                                    writer.WritePropertyName("KeyType");
                                    writer.Write(publicRequestLocalSecondaryIndexesListValueKeySchemaListValue.KeyType);
                                }

                                writer.WriteObjectEnd();
                            }
                            writer.WriteArrayEnd();
                        }

                        if(publicRequestLocalSecondaryIndexesListValue.IsSetProjection())
                        {
                            writer.WritePropertyName("Projection");
                            writer.WriteObjectStart();
                            if(publicRequestLocalSecondaryIndexesListValue.Projection.IsSetNonKeyAttributes())
                            {
                                writer.WritePropertyName("NonKeyAttributes");
                                writer.WriteArrayStart();
                                foreach(var publicRequestLocalSecondaryIndexesListValueProjectionNonKeyAttributesListValue in publicRequestLocalSecondaryIndexesListValue.Projection.NonKeyAttributes)
                                {
                                    writer.Write(publicRequestLocalSecondaryIndexesListValueProjectionNonKeyAttributesListValue);
                                }
                                writer.WriteArrayEnd();
                            }

                            if(publicRequestLocalSecondaryIndexesListValue.Projection.IsSetProjectionType())
                            {
                                writer.WritePropertyName("ProjectionType");
                                writer.Write(publicRequestLocalSecondaryIndexesListValue.Projection.ProjectionType);
                            }

                            writer.WriteObjectEnd();
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteArrayEnd();
                }

                if(publicRequest.IsSetProvisionedThroughput())
                {
                    writer.WritePropertyName("ProvisionedThroughput");
                    writer.WriteObjectStart();
                    if(publicRequest.ProvisionedThroughput.IsSetReadCapacityUnits())
                    {
                        writer.WritePropertyName("ReadCapacityUnits");
                        writer.Write(publicRequest.ProvisionedThroughput.ReadCapacityUnits);
                    }

                    if(publicRequest.ProvisionedThroughput.IsSetWriteCapacityUnits())
                    {
                        writer.WritePropertyName("WriteCapacityUnits");
                        writer.Write(publicRequest.ProvisionedThroughput.WriteCapacityUnits);
                    }

                    writer.WriteObjectEnd();
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