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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

using UnityEngine;

namespace Amazon.Runtime.Internal.Transform
{
    /// <summary>
    /// A container for response data
    /// </summary>
    internal class WWWResponseData : IWebResponseData
    {
        private byte[] _bytes;
        private Stream _response = null;

        public Dictionary<string, string> ResponseHeaders {get;set;}
        public string Error { get; set; }
        
        public WWWResponseData(WWW request)
        {
            if (!Amazon.Unity3D.AmazonMainThreadDispatcher.IsMainThread)
                throw new InvalidOperationException("Supported only on main(game) thread");

            this.ResponseHeaders = request.responseHeaders;

            this.Error = request.error;
                
            if (request.error == null)
            {
                this._bytes = request.bytes;
            }
        }

        public string ContentType
        {
            get { return this.ResponseHeaders.ContainsKey("CONTENT-TYPE") ? this.ResponseHeaders["CONTENT-TYPE"] : null; }
        }

        public byte[] GetBytes()
        {
            return this._bytes;
        }

        public Stream OpenResponse()
        {
            if (null == _response)
            {
                _response = new MemoryStream(this._bytes);
            }

            return _response;
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode),
                                         ResponseHeaders["STATUS"].Substring(13).Replace(" ", ""));

            }
        }

        public HttpStatusCode ErrorStatusCode
        {
            get
            {
                int statusCode = 0;
                // Error is of the form : "400 Bad Request" or "403: Forbidden"
                if (string.IsNullOrEmpty(this.Error))
                    throw new Exception("WWW error is null, cannot parse error code");
                else if (Int32.TryParse(this.Error.Substring(0,3), out statusCode))
                    return (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode),
                                                  this.Error.Substring(3).Replace(" ", "").Replace(":","").Trim(),true);//ignored case
                else
                    return 0;

            }
        }

        public bool IsHeaderPresent(string headerName)
        {

            return ResponseHeaders.ContainsKey(headerName);
        }

        public string[] GetHeaderNames()
        {
            return ResponseHeaders.Keys.ToArray();
        }

        public string GetHeaderValue(string name)
        {
            if (this.ResponseHeaders.ContainsKey(name))
                return this.ResponseHeaders[name];
            else
                return null;
        }
    }
}