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
using System.Xml.Serialization;
using System.Text;

using Amazon.Runtime;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Returns information about the  ListBuckets response and response metadata.
    /// </summary>
    public class ListBucketsResponse : AmazonWebServiceResponse
    {
        private List<S3Bucket> buckets = new List<S3Bucket>();
        private Owner owner;

        /// <summary>
        /// List of buckets.
        /// </summary>
        public List<S3Bucket> Buckets
        {
            get { return this.buckets; }
            set { this.buckets = value; }
        }

        // Check to see if Buckets property is set
        internal bool IsSetBuckets()
        {
            return this.buckets.Count > 0;
        }

        /// <summary>
        /// Owner of the buckets.
        /// </summary>
        public Owner Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        // Check to see if Owner property is set
        internal bool IsSetOwner()
        {
            return this.owner != null;
        }
    }
}
    
