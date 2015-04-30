//
// Copyright 2014-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
//
//
// Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
// You may not use this file except in compliance with the License.
// A copy of the License is located in the "license" file accompanying this file.
// See the License for the specific language governing permissions and limitations under the License.
//
//

/*
 * Do not modify this file. This file is generated from the mobileanalytics-2014-06-05.normal.json service model.
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
    /// Session Marshaller
    /// </summary>       
    public class SessionMarshaller : IRequestMarshaller<Session, JsonMarshallerContext> 
    {
        public void Marshall(Session requestObject, JsonMarshallerContext context)
        {
            if(requestObject.IsSetDuration())
            {
                context.Writer.WritePropertyName("duration");
                context.Writer.Write(requestObject.Duration);
            }

            if(requestObject.IsSetId())
            {
                context.Writer.WritePropertyName("id");
                context.Writer.Write(requestObject.Id);
            }

            if(requestObject.IsSetStartTimestamp())
            {
                context.Writer.WritePropertyName("startTimestamp");
                context.Writer.Write(requestObject.StartTimestamp);
            }

            if(requestObject.IsSetStopTimestamp())
            {
                context.Writer.WritePropertyName("stopTimestamp");
                context.Writer.Write(requestObject.StopTimestamp);
            }

        }

        public readonly static SessionMarshaller Instance = new SessionMarshaller();

    }
}