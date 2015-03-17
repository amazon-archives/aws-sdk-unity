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
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;

using Amazon.CognitoIdentity.Model;
using Amazon;
using Amazon.Runtime;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.Unity3D;
using Amazon.Unity3D.Storage;

using UnityEngine;

namespace Amazon.CognitoIdentity
{
    /// <summary>
    /// Temporary, short-lived session credentials that are automatically retrieved from
    /// Amazon Cognito Identity Service and AWS Security Token Service.
    /// Depending on configured Logins, credentials may be authenticated or unauthenticated.
    /// </summary>
    public class CognitoAWSCredentials : RefreshingAWSCredentials
    {
        private static int DefaultDurationSeconds = (int)TimeSpan.FromHours(1).TotalSeconds;
        private IAmazonSecurityTokenService sts;
        private AbstractCognitoIdentityProvider _identityProvider;

        /// <summary>
        /// The ARN of the IAM Role that will be assumed when unauthenticated
        /// </summary>
        public string UnAuthRoleArn { get; protected set; }
        
        /// <summary>
        /// The ARN of the IAM Role that will be assumed when authenticated
        /// </summary>
        public string AuthRoleArn { get; protected set; }
        
        public AbstractCognitoIdentityProvider IdentityProvider { get { return this._identityProvider; } protected set { this._identityProvider = value; } }

        private static readonly String ID_KEY = "identityId";
        private static readonly String AK_KEY = "accessKey";
        private static readonly String SK_KEY = "secretKey";
        private static readonly String ST_KEY = "sessionToken";
        private static readonly String EXP_KEY = "expirationDate";
        private string namespacedKey(string key) {
            return IdentityProvider.IdentityPoolId + key;
        }
        private KVStore _persistentStore;

        /// <summary>
        /// Constructs a new CognitoAWSCredentials instance, which will use the
        /// specified Amazon Cognito identity pool to make a requests to the
        /// AWS Security Token Service (STS) to request short lived session credentials.
        /// </summary>
        /// <param name="accountId">The AWS accountId for the account with Amazon Cognito</param>
        /// <param name="identityPoolId">The Amazon Cogntio identity pool to use</param>
        /// <param name="unAuthRoleArn">The ARN of the IAM Role that will be assumed when unauthenticated</param>
        /// <param name="authRoleArn">The ARN of the IAM Role that will be assumed when authenticated</param>
        /// <param name="region">Region to use when accessing Amazon Cognito and AWS Security Token Service.</param>
        public CognitoAWSCredentials(
            string accountId, string identityPoolId,
            string unAuthRoleArn, string authRoleArn,
            RegionEndpoint region)
            : this(unAuthRoleArn,
                   authRoleArn,
                   new AmazonCognitoIdentityProvider(accountId, identityPoolId, region),
                   new AmazonSecurityTokenServiceClient(new AnonymousAWSCredentials(), region)
                  )
        {
        }

        /// <summary>
        /// Constructs a new CognitoAWSCredentials instance, which will get credentials
        /// from Cognito Identity using the AmazonCognitoEnhancedIdentityProvider.
        /// </summary>
        /// <param name="accountId">The AWS accountId for the account with Amazon Cognito</param>
        /// <param name="identityPoolId">The Amazon Cogntio identity pool to use</param>
        /// <param name="unAuthRoleArn">The ARN of the IAM Role that will be assumed when unauthenticated</param>
        /// <param name="authRoleArn">The ARN of the IAM Role that will be assumed when authenticated</param>
        /// <param name="region">Region to use when accessing Amazon Cognito and AWS Security Token Service.</param>
        public CognitoAWSCredentials(string identityPoolId, RegionEndpoint region)
            : this(null,
                   null,
                   new AmazonCognitoEnhancedIdentityProvider(identityPoolId, region),
                   null
                  )
        {
        }

        /// Constructs a new CognitoAWSCredentials instance, which will use the
        /// specified Amazon Cognito identity pool to make a requests throught the
        /// AbstractCognitoIdentityProvider to get short lived session credentials.
        /// <param name="identityPoolId">The Amazon Cogntio identity pool to use</param>
        /// <param name="cibClient">Preconfigured Cognito Identity client to make requests with</param>
        public CognitoAWSCredentials(AbstractCognitoIdentityProvider cibClient)
            : this(null, null, cibClient, null)
        {
        }

        /// <summary>
        /// Constructs a new CognitoAWSCredentials instance, which will use the
        /// specified Amazon Cognito identity pool to make a requests throught the
        /// AbstractCognitoIdentityProvider to get short lived session credentials.
        /// </summary>
        /// <param name="accountId">The AWS accountId for the account with Amazon Cognito</param>
        /// <param name="identityPoolId">The Amazon Cogntio identity pool to use</param>
        /// <param name="unAuthRoleArn">The ARN of the IAM Role that will be assumed when unauthenticated</param>
        /// <param name="authRoleArn">The ARN of the IAM Role that will be assumed when authenticated</param>
        /// <param name="cibClient">Preconfigured Cognito Identity client to make requests with</param>
        /// <param name="stsClient">Preconfigured STS client to make requests with</param>
        public CognitoAWSCredentials(string unAuthRoleArn, string authRoleArn,
            AbstractCognitoIdentityProvider cibClient, IAmazonSecurityTokenService stsClient)
        {
            if (cibClient == null)
                throw new ArgumentNullException("cibClient");

            UnAuthRoleArn = unAuthRoleArn;
            AuthRoleArn = authRoleArn;
            IdentityProvider = cibClient;
            sts = stsClient;
            
            #if UNITY_WEBPLAYER
            _persistentStore = new InMemoryKVStore();
            #else
            _persistentStore = new SQLiteKVStore();
            #endif

            //Load cached credentials
            string cachedIdentity = _persistentStore.Get(namespacedKey(ID_KEY));
            if (string.IsNullOrEmpty(cachedIdentity)) {
                //Try to recover unamespaced identities stored by old versions of the SDK
                cachedIdentity = _persistentStore.Get(ID_KEY);
            }
            if (!string.IsNullOrEmpty(cachedIdentity)) {
                IdentityProvider.UpdateIdentity(cachedIdentity);
                loadCachedCredentials();
            }
            
            //Register Identity Changed Listener to update the cache
            IdentityProvider.IdentityChangedEvent += delegate(object sender, IdentityChangedArgs e)
            {
                saveCredentials();
                AmazonLogging.LogInfo("CognitoAWSCredentials", "Saved identityID to LocalStorage");
            };

        }

        private void loadCachedCredentials()
        {
            String AK = _persistentStore.Get(namespacedKey(AK_KEY));
            String SK = _persistentStore.Get(namespacedKey(SK_KEY));
            String ST = _persistentStore.Get(namespacedKey(ST_KEY));
            String EXP = _persistentStore.Get(namespacedKey(EXP_KEY));
            
            // make sure we have valid data in prefs
            if (AK == null || SK == null || ST == null)
            {
                AmazonLogging.LogInfo("CognitoAWSCredentials", "No valid credentials found in LocalStorage");
                _sessionCredentials = null;
                return;
            }

            long ticks = EXP != null ? long.Parse(EXP) : 0;

            _sessionCredentials = new CredentialsRefreshState
            {
                Credentials = new ImmutableCredentials(AK, SK, ST),
                Expiration = new DateTime(ticks)
            };
            AmazonLogging.LogInfo("CognitoAWSCredentials", "Loaded credentials from LocalStorage");
        }

        private void saveCredentials()
        {
            if (_sessionCredentials != null)
            {
                _persistentStore.Put(namespacedKey(AK_KEY), _sessionCredentials.Credentials.AccessKey);
                _persistentStore.Put(namespacedKey(SK_KEY), _sessionCredentials.Credentials.SecretKey);
                _persistentStore.Put(namespacedKey(ST_KEY), _sessionCredentials.Credentials.Token);
                _persistentStore.Put(namespacedKey(EXP_KEY), _sessionCredentials.Expiration.Ticks.ToString());
                _persistentStore.Put(namespacedKey(ID_KEY), IdentityProvider.GetCurrentIdentityId());
                AmazonLogging.LogInfo("CognitoAWSCredentials", "Saved credentials to LocalStorage");
            }
        }

        public override ImmutableCredentials GetCredentials()
        {
            //TODO: This should also check expiration, etc., like GetCredentialsAsync does
            if (this._sessionCredentials == null || _sessionCredentials.Credentials == null)
                loadCachedCredentials();
            return _sessionCredentials.Credentials;
        }

        // fetching/persisting new credentials in LocalStorage 
        public void GetCredentialsAsync(AmazonServiceCallback callback, object state)
        {
            if (this._sessionCredentials == null || _sessionCredentials.Credentials == null)
                loadCachedCredentials();

            // If credentials are expired, update
            if (ShouldUpdate)
            {
                GenerateNewCredentialsAsync(delegate(AmazonServiceResult voidResult)
                {
                    if (voidResult.Exception != null)
                    {
                        AmazonLogging.LogError("Cognito", "Error occured during GetCredentialsAsync");
                        AmazonMainThreadDispatcher.ExecCallback(callback, new AmazonServiceResult(null, null, voidResult.Exception, state));
                        return;
                    }

                    // Check if the new credentials are already expired
                    if (ShouldUpdate)
                    {
                        voidResult.Exception = new AmazonServiceException("The retrieved credentials have already expired");
                        AmazonMainThreadDispatcher.ExecCallback(callback, new AmazonServiceResult(null, null, voidResult.Exception, state));
                        return;
                    }

                    // Offset the Expiration by PreemptExpiryTime
                    _sessionCredentials.Expiration -= PreemptExpiryTime;

                    if (ShouldUpdate)
                    {
                        // This could happen if the default value of PreemptExpiryTime is
                        // overriden and set too high such that ShouldUpdate returns true.

                        voidResult.Exception = new AmazonClientException(String.Format(
                            "The preempt expiry time is set too high: Current time = {0}, Credentials expiry time = {1}, Preempt expiry time = {2}.",
                            DateTime.Now, _sessionCredentials.Expiration, PreemptExpiryTime));
                        AmazonMainThreadDispatcher.ExecCallback(callback, new AmazonServiceResult(null, null, voidResult.Exception, state));
                        return;
                    }

                    saveCredentials();
                    AmazonMainThreadDispatcher.ExecCallback(callback, new AmazonServiceResult(null, null, null, state));
                });
            } else {
                AmazonMainThreadDispatcher.ExecCallback(callback, new AmazonServiceResult(null, null, null, state));
            }
        }

        public void ClearCredentialsAndIdentity()
        {
            IdentityProvider.Clear();
            _persistentStore.Clear(namespacedKey(ID_KEY));
            ClearCredentials();
        }

        internal void ClearCredentials() {
            _sessionCredentials = null;
            _persistentStore.Clear(namespacedKey(AK_KEY));
            _persistentStore.Clear(namespacedKey(SK_KEY));
            _persistentStore.Clear(namespacedKey(ST_KEY));
            _persistentStore.Clear(namespacedKey(EXP_KEY));
            AmazonLogging.LogInfo("CognitoAWSCredentials", "Clear Credentials");
        }

        protected void GenerateNewCredentialsAsync(AmazonServiceCallback callback)
        {
            AmazonServiceResult voidResult = new AmazonServiceResult(null, null);

            AmazonServiceCallback refreshCallback;
            refreshCallback = delegate(AmazonServiceResult refreshResult)
            {
                if (refreshResult.Exception != null)
                {
                    if (refreshResult.Exception is ResourceNotFoundException) {
                        //Try again
                        IdentityProvider.UpdateIdentity(null);
                        IdentityProvider.RefreshAsync(refreshCallback, null);
                    } else if (refreshResult.Exception is AmazonServiceException && (refreshResult.Exception as AmazonServiceException).ErrorCode == "ValidationException") {
                        IdentityProvider.UpdateIdentity(null);
                        IdentityProvider.RefreshAsync(refreshCallback, null);
                    } else {
                        Debug.LogError("RefreshAsync failed");
                        voidResult.Exception = refreshResult.Exception;
                        AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                        return;
                    }
                }

                if (sts != null) {
                    PopulateCredentialsWithSTS(callback);
                } else {
                    PopulateCredentialsWithCognito(callback);
                }

            };
            
            IdentityProvider.RefreshAsync(refreshCallback, null);
            
        }

        private void PopulateCredentialsWithCognito(AmazonServiceCallback callback) 
        {
            AmazonServiceResult voidResult = new AmazonServiceResult(null, null);
            
            GetCredentialsForIdentityRequest request = new GetCredentialsForIdentityRequest();
            request.IdentityId = IdentityProvider.GetCurrentIdentityId();
            String token = IdentityProvider.GetCurrentOpenIdToken();
            if (token != null && token.Length != 0) {
                request.Logins = new Dictionary<string, string>();
                request.Logins.Add("cognito-identity.amazonaws.com", token);
            } else {
                request.Logins = IdentityProvider.Logins;
            }

            IdentityProvider.cib.GetCredentialsForIdentityAsync(request, delegate(AmazonServiceResult result){

                if (result.Exception != null)
                {
                    voidResult.Exception = result.Exception;
                    Debug.LogError(result.Exception.Message);
                    AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                    return;
                }
                GetCredentialsForIdentityResult credentialsResult = result.Response as GetCredentialsForIdentityResult;

                ///Calling this will trigger clear _sessionCredentials, so it's important to do it before
                if (credentialsResult.IdentityId != IdentityProvider.GetCurrentIdentityId()) {
                    IdentityProvider.UpdateIdentity(credentialsResult.IdentityId);
                }

                this._sessionCredentials = new CredentialsRefreshState
                {
                    Credentials = new ImmutableCredentials(credentialsResult.Credentials.AccessKeyId, 
                                                           credentialsResult.Credentials.SecretKey, 
                                                           credentialsResult.Credentials.SessionToken),
                    Expiration = credentialsResult.Credentials.Expiration.ToUniversalTime()
                };
                                
                // success - FinalResponse
                AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);

            }, null);


        }

        private void PopulateCredentialsWithSTS(AmazonServiceCallback callback)
        {
            AmazonServiceResult voidResult = new AmazonServiceResult(null, null);

            // Pick role to use, depending on Logins
            string roleArn = UnAuthRoleArn;
            if (IdentityProvider.Logins.Count > 0) {
                roleArn = AuthRoleArn;
            }
            if (string.IsNullOrEmpty(roleArn))
            {
                voidResult.Exception = new AmazonServiceException(
                    new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                                            "Unable to determine Role ARN. AuthRoleArn = [{0}], UnAuthRoleArn = [{1}], Logins.Count = {2}",
                                                            AuthRoleArn, UnAuthRoleArn, IdentityProvider.Logins.Count)));
                AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                return;
            }

            // Assume role with Open Id Token
            var assumeRequest = new AssumeRoleWithWebIdentityRequest
            {
                WebIdentityToken = IdentityProvider.GetCurrentOpenIdToken(),
                RoleArn = roleArn,
                RoleSessionName = "UnityProviderSession",
                DurationSeconds = DefaultDurationSeconds
                
            };
            
            sts.AssumeRoleWithWebIdentityAsync(assumeRequest, delegate(AmazonServiceResult result)
                                               {
                if (result.Exception != null)
                {
                    voidResult.Exception = result.Exception;
                    Debug.LogError(result.Exception.Message);
                    AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                    return;
                }
                AssumeRoleWithWebIdentityResponse assumeRoleWithWebIdentityResponse = result.Response as AssumeRoleWithWebIdentityResponse;

                this._sessionCredentials = new CredentialsRefreshState
                {
                    Credentials = assumeRoleWithWebIdentityResponse.Credentials.GetCredentials(),
                    Expiration = assumeRoleWithWebIdentityResponse.Credentials.Expiration.ToUniversalTime()
                };
                // success - FinalResponse
                AmazonMainThreadDispatcher.ExecCallback(callback, voidResult);
                return;
            }, null);
        }


        /// <summary>
        /// Removes a provider from the collection of logins.
        /// </summary>
        /// <param name="providerName">The provider name for the login (i.e. graph.facebook.com)</param>
        public void RemoveLogin(string providerName)
        {
            ClearCredentials();
            IdentityProvider.Logins.Remove(providerName);
        }
        
        /// <summary>
        /// Adds a login to be used for authenticated requests.
        /// </summary>
        /// <param name="providerName">The provider name for the login (i.e. graph.facebook.com)</param>
        /// <param name="token">The token provided by the identity provider.</param>
        public void AddLogin(string providerName, string token)
        {
            ClearCredentials();
            IdentityProvider.Logins[providerName] = token;
        }

    }
}
