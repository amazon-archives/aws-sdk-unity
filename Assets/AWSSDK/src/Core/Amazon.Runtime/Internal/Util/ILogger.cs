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

namespace Amazon.Runtime.Internal.Util
{
    public interface ILogger
    {
        void InfoFormat(string messageFormat, params object[] args);
        void Debug(Exception exception, string messageFormat, params object[] args);
        void DebugFormat(string messageFormat, params object[] args);
        void Error(Exception exception, string messageFormat, params object[] args);
        void Flush();
    }
}
