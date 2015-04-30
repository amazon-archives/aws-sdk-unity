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

using System.Collections.Generic;

using Amazon.S3.Model;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
     /// <summary>
     ///   ErrorsItem Unmarshaller
     /// </summary>
    internal class ErrorsItemUnmarshaller : IUnmarshaller<DeleteError, XmlUnmarshallerContext>, IUnmarshaller<DeleteError, JsonUnmarshallerContext> 
    {
        public DeleteError Unmarshall(XmlUnmarshallerContext context) 
        {
            DeleteError errorsItem = new DeleteError();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("Code", targetDepth))
                    {
                        errorsItem.Code = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Key", targetDepth))
                    {
                        errorsItem.Key = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Message", targetDepth))
                    {
                        errorsItem.Message = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("VersionId", targetDepth))
                    {
                        errorsItem.VersionId = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return errorsItem;
                }
            }
                        


            return errorsItem;
        }

        public DeleteError Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static ErrorsItemUnmarshaller _instance;

        public static ErrorsItemUnmarshaller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorsItemUnmarshaller();
                }
                return _instance;
            }
        }
    }
}
    
