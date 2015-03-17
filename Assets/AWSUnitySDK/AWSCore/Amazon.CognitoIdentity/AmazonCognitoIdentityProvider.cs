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
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Amazon;
using Amazon.Unity3D;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.CognitoIdentity.Model;

namespace Amazon.CognitoIdentity
{
    public class AmazonCognitoIdentityProvider : AbstractCognitoIdentityProvider
    {
        private AnonymousAWSCredentials anonymousAWSCredentials;
        private RegionEndpoint region;

        public AmazonCognitoIdentityProvider(string accountId, string identityPoolId, RegionEndpoint region)
            : base(accountId, identityPoolId, region)
        {
        }

        public override string getProviderName()
        {
            return "Cognito";
        }

        public override void RefreshAsync(AmazonServiceCallback callback, object state)
        {
			//_token = null;
            AmazonServiceResult voidResult = new AmazonServiceResult(null, state);
            if (!IsIdentitySet)
            {
                var getIdRequest = new GetIdRequest
                {
                    AccountId = AccountId,
                    IdentityPoolId = IdentityPoolId,
                    Logins = Logins
                };
                cib.GetIdAsync(getIdRequest, delegate(AmazonServiceResult result)
                                {
                                    if (result.Exception != null)
                                    {
                                        voidResult.Exception = result.Exception;
										AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                                        return;
                                    }
                                    var getIdResponse = result.Response as GetIdResponse;
                                    UpdateIdentity(getIdResponse.IdentityId);

                                    GetOpenIdMethod(voidResult, callback);

                                }, null);
            } else {
	            GetOpenIdMethod(voidResult, callback);
			}


        }

        // This method is to avoid having redundant code based on IsIdentitySet check
        private void GetOpenIdMethod(AmazonServiceResult voidResult, AmazonServiceCallback callback)
        {
            var getTokenRequest = new GetOpenIdTokenRequest
            {
                IdentityId = GetCurrentIdentityId(),
                Logins = this.Logins
            };

            cib.GetOpenIdTokenAsync(getTokenRequest, delegate(AmazonServiceResult getOpenIdTokenResult)
                                    {
                                        if (getOpenIdTokenResult.Exception != null)
                                        {
                                            if (callback != null)
                                            {
                                                voidResult.Exception = getOpenIdTokenResult.Exception;
												AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                                            }
                                            return;
                                        }
                                        var getOpenIdTokenResponse = getOpenIdTokenResult.Response as GetOpenIdTokenResponse;
                                        _token = getOpenIdTokenResponse.Token;

                                        this.UpdateIdentity(getOpenIdTokenResponse.IdentityId);

                                        AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);

                                    }, null);
        }

    }

}
