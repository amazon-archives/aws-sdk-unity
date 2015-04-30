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
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
    public interface ISimplifiedErrorUnmarshaller
    {
        AmazonServiceException UnmarshallException(IWebResponseData response, ErrorResponse errorResponse, Exception innerException);
    }
}
