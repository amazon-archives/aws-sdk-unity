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
using System.Text;
using Amazon.Runtime.Internal;

namespace Amazon.Runtime
{
    public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);

    public class ExceptionEventArgs : EventArgs
    {
        #region Constructor

        protected ExceptionEventArgs() { }

        #endregion
    }

    public class WebServiceExceptionEventArgs : ExceptionEventArgs
    {
        #region Constructor

        protected WebServiceExceptionEventArgs() { }

        #endregion

        #region Properties

        public IDictionary<string, string> Headers { get; protected set; }
        public IDictionary<string, string> Parameters { get; protected set; }
        public string ServiceName { get; protected set; }
        public Uri Endpoint { get; protected set; }
        public AmazonWebServiceRequest Request { get; protected set; }
        public Exception Exception { get; protected set; }

        #endregion

        #region Creator method

        internal static WebServiceExceptionEventArgs Create(Exception exception, IRequest request)
        {
            WebServiceExceptionEventArgs args;
            if (request == null)
                args = new WebServiceExceptionEventArgs
                {
                    Exception = exception
                };
            else
                args = new WebServiceExceptionEventArgs
                {
                    Headers = request.Headers,
                    Parameters = request.Parameters,
                    ServiceName = request.ServiceName,
                    Request = request.OriginalRequest,
                    Endpoint = request.Endpoint,
                    Exception = exception
                };

            return args;
        }

        #endregion
    }
}
