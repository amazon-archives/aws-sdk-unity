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

using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// PutEvents Request Marshaller
    /// </summary>       
    public class PutEventsRequestMarshaller : IMarshaller<IRequest, PutEventsRequest> 
    {
        public IRequest Marshall(PutEventsRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.MobileAnalytics");
            string target = "AmazonMobileAnalytics.PutEvents";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.1";
            request.HttpMethod = "POST";

            string uriResourcePath = "/2014-06-05/events";
        
            if(publicRequest.IsSetClientContext()){
                request.Headers["x-amz-Client-Context"] = publicRequest.ClientContext;
            }
            
            if(publicRequest.IsSetClientContextEncoding()){
                request.Headers["x-amz-Client-Context-Encoding"] = publicRequest.ClientContextEncoding;
            }
            
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetEvents())
                {
                    writer.WritePropertyName("events");
                    writer.WriteArrayStart();
                    foreach(var publicRequestEventsListValue in publicRequest.Events)
                    {
                        writer.WriteObjectStart();
                        if(publicRequestEventsListValue.IsSetAttributes())
                        {
                            writer.WritePropertyName("attributes");
                            writer.WriteObjectStart();
                            foreach (var publicRequestEventsListValueAttributesKvp in publicRequestEventsListValue.Attributes)
                            {
                                writer.WritePropertyName(publicRequestEventsListValueAttributesKvp.Key);
                                var publicRequestEventsListValueAttributesValue = publicRequestEventsListValueAttributesKvp.Value;

                                writer.Write(publicRequestEventsListValueAttributesValue);
                            }
                            writer.WriteObjectEnd();
                        }

                        if(publicRequestEventsListValue.IsSetEventType())
                        {
                            writer.WritePropertyName("eventType");
                            writer.Write(publicRequestEventsListValue.EventType);
                        }

                        if(publicRequestEventsListValue.IsSetMetrics())
                        {
                            writer.WritePropertyName("metrics");
                            writer.WriteObjectStart();
                            foreach (var publicRequestEventsListValueMetricsKvp in publicRequestEventsListValue.Metrics)
                            {
                                writer.WritePropertyName(publicRequestEventsListValueMetricsKvp.Key);
                                var publicRequestEventsListValueMetricsValue = publicRequestEventsListValueMetricsKvp.Value;

                                writer.Write(publicRequestEventsListValueMetricsValue);
                            }
                            writer.WriteObjectEnd();
                        }

                        if(publicRequestEventsListValue.IsSetSession())
                        {
                            writer.WritePropertyName("session");
                            writer.WriteObjectStart();
                            if(publicRequestEventsListValue.Session.IsSetDuration())
                            {
                                writer.WritePropertyName("duration");
                                writer.Write(publicRequestEventsListValue.Session.Duration);
                            }

                            if(publicRequestEventsListValue.Session.IsSetId())
                            {
                                writer.WritePropertyName("id");
                                writer.Write(publicRequestEventsListValue.Session.Id);
                            }

                            if(publicRequestEventsListValue.Session.IsSetStartTimestamp())
                            {
                                writer.WritePropertyName("startTimestamp");
                                writer.Write(publicRequestEventsListValue.Session.StartTimestamp);
                            }

                            if(publicRequestEventsListValue.Session.IsSetStopTimestamp())
                            {
                                writer.WritePropertyName("stopTimestamp");
                                writer.Write(publicRequestEventsListValue.Session.StopTimestamp);
                            }

                            writer.WriteObjectEnd();
                        }

                        if(publicRequestEventsListValue.IsSetTimestamp())
                        {
                            writer.WritePropertyName("timestamp");
                            writer.Write(publicRequestEventsListValue.Timestamp);
                        }

                        if(publicRequestEventsListValue.IsSetVersion())
                        {
                            writer.WritePropertyName("version");
                            writer.Write(publicRequestEventsListValue.Version);
                        }

                        writer.WriteObjectEnd();
                    }
                    writer.WriteArrayEnd();
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}