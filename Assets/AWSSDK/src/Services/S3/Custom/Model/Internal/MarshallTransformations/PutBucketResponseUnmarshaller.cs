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
    ///    Response Unmarshaller for PutBucket operation
    /// </summary>
    internal class PutBucketResponseUnmarshaller : S3ReponseUnmarshaller
    {
        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {   
            PutBucketResponse response = new PutBucketResponse();
            
            UnmarshallResult(context,response);

            return response;
        }
        
        private static void UnmarshallResult(XmlUnmarshallerContext context,PutBucketResponse response)
        {
            return;
        }

        private static PutBucketResponseUnmarshaller _instance;

        public static PutBucketResponseUnmarshaller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PutBucketResponseUnmarshaller();
                }
                return _instance;
            }
        }
    
    }
}
    
