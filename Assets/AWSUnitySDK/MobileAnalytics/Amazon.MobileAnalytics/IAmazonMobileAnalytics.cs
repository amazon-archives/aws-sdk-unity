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


using System;

using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;

namespace Amazon.MobileAnalytics
{
    /// <summary>
    /// Implementation for accessing MobileAnalytics
    ///
    /// A service which is used to record Amazon Mobile Analytics events
    /// </summary>
    public partial interface IAmazonMobileAnalytics : IDisposable
    {

        
        #region  PutEvents


        /// <summary>
        /// Initiates the asynchronous execution of the PutEvents operation.
        /// <seealso cref="Amazon.MobileAnalytics.IAmazonMobileAnalytics"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the PutEvents operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void PutEventsAsync(PutEventsRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
    }
}