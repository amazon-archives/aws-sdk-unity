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

using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.Util
{
    #region Basic sections

    /// <summary>
    /// Proxy configuration is not implemented in Unity SDK.
    /// </summary>
    public partial class ProxyConfig
    {
        internal void Configure(ProxySection section)
        {
             
        }
    }

    /// <summary>
    /// Settings for logging in the SDK.
    /// </summary>
    public partial class LoggingConfig
    {
        internal void Configure(LoggingSection section)
        {
            LogTo = section.LogTo;
            LogResponses = section.LogResponses;
            LogMetrics = section.LogMetrics.GetValueOrDefault(false);
            LogMetricsFormat = section.LogMetricsFormat;
            if (section.LogMetricsCustomFormatter != null
                && typeof(IMetricsFormatter).IsAssignableFrom(section.LogMetricsCustomFormatter))
            {
                LogMetricsCustomFormatter = Activator.CreateInstance(section.LogMetricsCustomFormatter) as IMetricsFormatter;
            }
        }
    }
    
    #endregion
}
