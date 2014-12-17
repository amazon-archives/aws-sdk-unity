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
     ///   Bucket Unmarshaller
     /// </summary>
    internal class BucketUnmarshaller : IUnmarshaller<S3Bucket, XmlUnmarshallerContext>, IUnmarshaller<S3Bucket, JsonUnmarshallerContext> 
    {
        public S3Bucket Unmarshall(XmlUnmarshallerContext context) 
        {
            S3Bucket bucket = new S3Bucket();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("CreationDate", targetDepth))
                    {
                        bucket.CreationDate = DateTimeUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Name", targetDepth))
                    {
                        bucket.BucketName = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return bucket;
                }
            }
                        


            return bucket;
        }

        public S3Bucket Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static BucketUnmarshaller instance;

        public static BucketUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new BucketUnmarshaller();

            return instance;
        }
    }
}
    
