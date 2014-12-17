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
     ///   Owner Unmarshaller
     /// </summary>
    internal class OwnerUnmarshaller : IUnmarshaller<Owner, XmlUnmarshallerContext>, IUnmarshaller<Owner, JsonUnmarshallerContext> 
    {
        public Owner Unmarshall(XmlUnmarshallerContext context) 
        {
            Owner owner = new Owner();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("DisplayName", targetDepth))
                    {
                        owner.DisplayName = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("ID", targetDepth))
                    {
                        owner.Id = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return owner;
                }
            }
                        


            return owner;
        }

        public Owner Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static OwnerUnmarshaller instance;

        public static OwnerUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new OwnerUnmarshaller();

            return instance;
        }
    }
}
    
