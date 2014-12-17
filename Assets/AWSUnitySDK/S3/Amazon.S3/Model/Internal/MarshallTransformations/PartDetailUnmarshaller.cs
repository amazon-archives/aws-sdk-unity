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
     ///   PartsItem Unmarshaller
     /// </summary>
    internal class PartDetailUnmarshaller : IUnmarshaller<PartDetail, XmlUnmarshallerContext>, IUnmarshaller<PartDetail, JsonUnmarshallerContext> 
    {
        public PartDetail Unmarshall(XmlUnmarshallerContext context) 
        {
            PartDetail partsItem = new PartDetail();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("ETag", targetDepth))
                    {
                        partsItem.ETag = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("LastModified", targetDepth))
                    {
                        partsItem.LastModified = DateTimeUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("PartNumber", targetDepth))
                    {
                        partsItem.PartNumber = IntUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Size", targetDepth))
                    {
                        partsItem.Size = IntUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return partsItem;
                }
            }
                        


            return partsItem;
        }

        public PartDetail Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static PartDetailUnmarshaller instance;

        public static PartDetailUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new PartDetailUnmarshaller();

            return instance;
        }
    }
}
    
