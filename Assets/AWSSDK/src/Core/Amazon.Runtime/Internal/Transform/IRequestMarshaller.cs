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
using System.Xml;
using ThirdParty.Json.LitJson;

namespace Amazon.Runtime.Internal.Transform
{
    public interface IRequestMarshaller<R, T>
        where T : MarshallerContext
    {
        void Marshall(R requestObject, T context);
    }

    public abstract class MarshallerContext
    {
        public IRequest Request { get; private set; }

        protected MarshallerContext(IRequest request)
        {
            Request = request;
        }
    }

    public class XmlMarshallerContext : MarshallerContext
    {
        public XmlWriter Writer { get; private set; }

        public XmlMarshallerContext(IRequest request, XmlWriter writer)
            : base(request)
        {
            Writer = writer;
        }
    }

    public class JsonMarshallerContext : MarshallerContext
    {
        public JsonWriter Writer { get; private set; }

        public JsonMarshallerContext(IRequest request, JsonWriter writer)
            : base(request)
        {
            Writer = writer;
        }
    }
}
