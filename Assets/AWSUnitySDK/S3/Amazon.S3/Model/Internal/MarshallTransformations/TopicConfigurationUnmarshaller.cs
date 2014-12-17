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
using System.Collections.Generic;

using Amazon.S3.Model;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
     /// <summary>
     ///   TopicConfiguration Unmarshaller
     /// </summary>
    internal class TopicConfigurationUnmarshaller : IUnmarshaller<TopicConfiguration, XmlUnmarshallerContext>, IUnmarshaller<TopicConfiguration, JsonUnmarshallerContext> 
    {
        public TopicConfiguration Unmarshall(XmlUnmarshallerContext context) 
        {
            TopicConfiguration topicConfiguration = new TopicConfiguration();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("Event", targetDepth))
                    {
                        topicConfiguration.Event = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Topic", targetDepth))
                    {
                        topicConfiguration.Topic = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return topicConfiguration;
                }
            }
                        


            return topicConfiguration;
        }

        public TopicConfiguration Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static TopicConfigurationUnmarshaller instance;

        public static TopicConfigurationUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new TopicConfigurationUnmarshaller();

            return instance;
        }
    }
}
    
