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

using Amazon.CognitoIdentity.Model;
using Amazon;
using Amazon.Runtime;
using Amazon.Unity3D;
using System;

namespace Amazon.CognitoIdentity
{
	public class CachingCognitoAWSCredentials : CognitoAWSCredentials
    {
	
		[Obsolete("This class is deprecated. Please use CognitoAWSCredentials instead.")]
	    public CachingCognitoAWSCredentials() : base("deprecated", Amazon.RegionEndpoint.USEast1) {
			//CognitoAWSCredentials now uses caching by default, so this class is deprecated.
			//Also CognitoAWSCredentials' constructor receives the identity pool id as a parameter, so you
			//can have applications that use more than one identity pool (in the unlikely case you need this).
			throw new AmazonClientException("This class is deprecated. Please use CognitoAWSCredentials instead.");
		}

    }
}
