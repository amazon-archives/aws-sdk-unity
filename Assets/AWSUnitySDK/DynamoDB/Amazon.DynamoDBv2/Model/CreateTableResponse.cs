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

namespace Amazon.DynamoDBv2.Model
{
    /// <summary>
    /// Configuration for accessing Amazon CreateTable service
    /// </summary>
    public partial class CreateTableResponse : CreateTableResult
    {
        /// <summary>
        /// Gets and sets the CreateTableResult property.
        /// Represents the output of a CreateTable operation.
        /// </summary>
        [Obsolete(@"This property has been deprecated. All properties of the CreateTableResult class are now available on the CreateTableResponse class. You should use the properties on CreateTableResponse instead of accessing them through CreateTableResult.")]
        public CreateTableResult CreateTableResult
        {
            get
            {
                return this;
            }
        }
    }
}