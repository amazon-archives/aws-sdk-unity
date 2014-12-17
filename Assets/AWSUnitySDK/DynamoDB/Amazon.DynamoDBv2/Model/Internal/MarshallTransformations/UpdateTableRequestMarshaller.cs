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
    /// UpdateTable Request Marshaller
    /// </summary>       
    public class UpdateTableRequestMarshaller : IMarshaller<IRequest, UpdateTableRequest> 
    {
        public IRequest Marshall(UpdateTableRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.DynamoDBv2");
            string target = "DynamoDB_20120810.UpdateTable";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";

            string uriResourcePath = "/";
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetGlobalSecondaryIndexUpdates())
                {
                    writer.WritePropertyName("GlobalSecondaryIndexUpdates");
                    writer.WriteArrayStart();
                    foreach(var publicRequestGlobalSecondaryIndexUpdatesListValue in publicRequest.GlobalSecondaryIndexUpdates)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestGlobalSecondaryIndexUpdatesListValue.IsSetUpdate())
                        {
                            writer.WritePropertyName("Update");
                            writer.WriteObjectStart();
                            if(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.IsSetIndexName())
                            {
                                writer.WritePropertyName("IndexName");
                                writer.Write(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.IndexName);
                            }

                            if(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.IsSetProvisionedThroughput())
                            {
                                writer.WritePropertyName("ProvisionedThroughput");
                                writer.WriteObjectStart();
                                if(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.ProvisionedThroughput.IsSetReadCapacityUnits())
                                {
                                    writer.WritePropertyName("ReadCapacityUnits");
                                    writer.Write(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.ProvisionedThroughput.ReadCapacityUnits);
                                }

                                if(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.ProvisionedThroughput.IsSetWriteCapacityUnits())
                                {
                                    writer.WritePropertyName("WriteCapacityUnits");
                                    writer.Write(publicRequestGlobalSecondaryIndexUpdatesListValue.Update.ProvisionedThroughput.WriteCapacityUnits);
                                }

                                writer.WriteObjectEnd();
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