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
     ///   Grantee Unmarshaller
     /// </summary>
    internal class GranteeUnmarshaller : IUnmarshaller<S3Grantee, XmlUnmarshallerContext>, IUnmarshaller<S3Grantee, JsonUnmarshallerContext> 
    {
        public S3Grantee Unmarshall(XmlUnmarshallerContext context) 
        {
            S3Grantee grantee = new S3Grantee();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("@Type", targetDepth - 1))
                    {
                        continue;
                    }
                    if (context.TestExpression("DisplayName", targetDepth))
                    {
                        grantee.DisplayName = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("EmailAddress", targetDepth))
                    {
                        grantee.EmailAddress = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("ID", targetDepth))
                    {
                        grantee.CanonicalUser = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("URI", targetDepth))
                    {
                        grantee.URI = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return grantee;
                }
            }
                        


            return grantee;
        }

        public S3Grantee Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static GranteeUnmarshaller instance;

        public static GranteeUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new GranteeUnmarshaller();

            return instance;
        }
    }
}
    
