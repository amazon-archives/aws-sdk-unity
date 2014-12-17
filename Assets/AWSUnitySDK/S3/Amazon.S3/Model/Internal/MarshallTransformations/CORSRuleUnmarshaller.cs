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
     ///   CORSRule Unmarshaller
     /// </summary>
    internal class CORSRuleUnmarshaller : IUnmarshaller<CORSRule, XmlUnmarshallerContext>, IUnmarshaller<CORSRule, JsonUnmarshallerContext> 
    {
        public CORSRule Unmarshall(XmlUnmarshallerContext context) 
        {
            CORSRule cORSRule = new CORSRule();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("AllowedMethod", targetDepth))
                    {
                        cORSRule.AllowedMethods.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
                            
                        continue;
                    }
                    if (context.TestExpression("AllowedOrigin", targetDepth))
                    {
                        cORSRule.AllowedOrigins.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
                            
                        continue;
                    }
                    if (context.TestExpression("ExposeHeader", targetDepth))
                    {
                        cORSRule.ExposeHeaders.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
                            
                        continue;
                    }
                    if (context.TestExpression("AllowedHeader", targetDepth))
                    {
                        cORSRule.AllowedHeaders.Add(StringUnmarshaller.GetInstance().Unmarshall(context));

                        continue;
                    }

                    if (context.TestExpression("MaxAgeSeconds", targetDepth))
                    {
                        cORSRule.MaxAgeSeconds = IntUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("ID", targetDepth))
                    {
                        cORSRule.Id = StringUnmarshaller.GetInstance().Unmarshall(context);

                        continue;
                    }

                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return cORSRule;
                }
            }
                        


            return cORSRule;
        }

        public CORSRule Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static CORSRuleUnmarshaller instance;

        public static CORSRuleUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new CORSRuleUnmarshaller();

            return instance;
        }
    }
}
    
