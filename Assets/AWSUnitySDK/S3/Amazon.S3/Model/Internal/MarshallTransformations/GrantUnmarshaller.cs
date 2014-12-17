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
     ///   Grant Unmarshaller
     /// </summary>
    internal class GrantUnmarshaller : IUnmarshaller<S3Grant, XmlUnmarshallerContext>, IUnmarshaller<S3Grant, JsonUnmarshallerContext> 
    {
        public S3Grant Unmarshall(XmlUnmarshallerContext context) 
        {
            S3Grant grant = new S3Grant();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("Grantee", targetDepth))
                    {
                        grant.Grantee = GranteeUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Permission", targetDepth))
                    {
                        grant.Permission = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return grant;
                }
            }
                        


            return grant;
        }

        public S3Grant Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static GrantUnmarshaller instance;

        public static GrantUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new GrantUnmarshaller();

            return instance;
        }
    }
}
    
