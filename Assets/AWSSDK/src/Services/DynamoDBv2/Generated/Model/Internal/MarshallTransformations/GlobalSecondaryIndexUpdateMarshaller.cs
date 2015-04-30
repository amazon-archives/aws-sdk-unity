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
 * Do not modify this file. This file is generated from the dynamodb-2012-08-10.normal.json service model.
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
    /// GlobalSecondaryIndexUpdate Marshaller
    /// </summary>       
    public class GlobalSecondaryIndexUpdateMarshaller : IRequestMarshaller<GlobalSecondaryIndexUpdate, JsonMarshallerContext> 
    {
        public void Marshall(GlobalSecondaryIndexUpdate requestObject, JsonMarshallerContext context)
        {
            if(requestObject.IsSetCreate())
            {
                context.Writer.WritePropertyName("Create");
                context.Writer.WriteObjectStart();

                var marshaller = CreateGlobalSecondaryIndexActionMarshaller.Instance;
                marshaller.Marshall(requestObject.Create, context);

                context.Writer.WriteObjectEnd();
            }

            if(requestObject.IsSetDelete())
            {
                context.Writer.WritePropertyName("Delete");
                context.Writer.WriteObjectStart();

                var marshaller = DeleteGlobalSecondaryIndexActionMarshaller.Instance;
                marshaller.Marshall(requestObject.Delete, context);

                context.Writer.WriteObjectEnd();
            }

            if(requestObject.IsSetUpdate())
            {
                context.Writer.WritePropertyName("Update");
                context.Writer.WriteObjectStart();

                var marshaller = UpdateGlobalSecondaryIndexActionMarshaller.Instance;
                marshaller.Marshall(requestObject.Update, context);

                context.Writer.WriteObjectEnd();
            }

        }

        public readonly static GlobalSecondaryIndexUpdateMarshaller Instance = new GlobalSecondaryIndexUpdateMarshaller();

    }
}