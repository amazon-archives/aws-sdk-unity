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

using System;
using System.Net;
using System.Collections.Generic;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    ///    Response Unmarshaller for GetBucketNotification operation
    /// </summary>
    internal class GetBucketNotificationResponseUnmarshaller : S3ReponseUnmarshaller
    {
        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {   
            GetBucketNotificationResponse response = new GetBucketNotificationResponse();
            response.TopicConfigurations = new List<TopicConfiguration>();

            while (context.Read())
            {
                if (context.IsStartElement)
                {                    
                    UnmarshallResult(context,response);                        
                    continue;
                }
            }
                        
            return response;
        }
        
        private static void UnmarshallResult(XmlUnmarshallerContext context,GetBucketNotificationResponse response)
        {
            
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("TopicConfiguration", targetDepth))
                    {
                        response.TopicConfigurations.Add(TopicConfigurationUnmarshaller.Instance.Unmarshall(context));
                        continue;
                    }
                    if (context.TestExpression("QueueConfiguration", targetDepth))
                    {
                        response.QueueConfigurations.Add(QueueConfigurationUnmarshaller.Instance.Unmarshall(context));
                        continue;
                    }
                    if (context.TestExpression("CloudFunctionConfiguration", targetDepth))
                    {
                        response.CloudFunctionConfigurations.Add(CloudFunctionConfigurationUnmarshaller.Instance.Unmarshall(context));
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return;
                }
            }

            return;
        }

        private static GetBucketNotificationResponseUnmarshaller _instance;

        public static GetBucketNotificationResponseUnmarshaller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GetBucketNotificationResponseUnmarshaller();
                }
                return _instance;
            }
        }
    }
}
    
