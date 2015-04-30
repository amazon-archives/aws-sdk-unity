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
using System.Linq;
using System.Text;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal   
{
    /// <summary>
    /// Exception thrown by the SDK for errors that occur within the Mobile Analytics event store.
    /// </summary>
    internal class EventStoreException : Exception
    {
        public EventStoreException(string message) : base(message) { }

        public EventStoreException(string message, Exception innerException) : base(message, innerException) { }
    }
} 
