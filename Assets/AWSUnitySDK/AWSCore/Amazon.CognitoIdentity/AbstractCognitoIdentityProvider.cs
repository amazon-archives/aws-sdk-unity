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
using Amazon.CognitoIdentity.Model;


namespace Amazon.CognitoIdentity
{

    /// <summary>
    /// Information about an identity change in the CognitoAWSCredentials.
    /// </summary>
    public class IdentityChangedArgs : EventArgs
    {
        public string OldIdentityId { get; private set; }
        public string NewIdentityId { get; private set; }

        internal IdentityChangedArgs(string oldIdentityId, string newIdentityId)
        {
            OldIdentityId = oldIdentityId;
            NewIdentityId = newIdentityId;
        }
    }

	/// <summary>
	/// Base class for AmazonCognitoIdentityProvider and AmazonCognitoEnhancedIdentityProvider.
	/// If you want to use developer-authenticated identities, you should derive your own custom
	/// identity provider from this class. (See ExampleCustomIdentityProvider.cs in the samples)
	/// </summary>
    public abstract class AbstractCognitoIdentityProvider : IAmazonIdentityProvider
    {

        protected string _identityId;
        protected string _token;

        public IAmazonCognitoIdentity cib;

        protected bool IsIdentitySet { get { return !string.IsNullOrEmpty(_identityId); } }

        public AbstractCognitoIdentityProvider(string identityPoolId, RegionEndpoint region)
            : this(null, identityPoolId, region)
        {
        }

        public AbstractCognitoIdentityProvider(string accountId, string identityPoolId, RegionEndpoint region)
        {
            if (string.IsNullOrEmpty(identityPoolId))
                throw new ArgumentNullException("identityPoolId");
            this.AccountId = accountId;
            this.IdentityPoolId = identityPoolId;
            this.Logins = new Dictionary<string, string>(StringComparer.Ordinal);
            this.cib = new AmazonCognitoIdentityClient(new AnonymousAWSCredentials(), region);
        }

        // Updates IdentityId to new value and fires IdentityChangedEvent
        public void UpdateIdentity(string newIdentityId)
        {
            // No-op if new IdentityId is same as old
            if (_identityId == newIdentityId) 
                return;

            // Swap in new identity
            string oldIdentityId = _identityId;
            _identityId = newIdentityId;

            // Fire the event
            var handler = IdentityChangedEvent;
            if (handler != null)
            {
                var args = new IdentityChangedArgs(oldIdentityId, newIdentityId);
                handler(this, args);
            }
        }

        /// <summary>
        /// The AWS accountId for the account with Amazon Cognito
        /// </summary>
        public string AccountId { get; protected set; }
        /// <summary>
        /// The Amazon Cogntio identity pool to use
        /// </summary>
        public string IdentityPoolId { get; protected set; }


        /// <summary>
        /// Logins map used to authenticated with Amazon Cognito.
        /// Note: After modifying this field, you must manually call Clear on this
        /// instance of the CognitoAWSCredentials, as your Identity Id may have changed.
        /// </summary>
        public Dictionary<string, string> Logins { get; set; }

        /// <summary>
        /// Clears current credentials state. This will reset the IdentityId.
        /// </summary>
        public void Clear()
        {
            _identityId = null;
            Logins.Clear();
        }
   
        /// <summary>
        /// The list of current providers that are used for authenticated credentials.
        /// </summary>
        public string[] CurrentLoginProviders
        {
            get { return this.Logins.Keys.ToArray(); }
        }

        /// <summary>
        /// Removes a provider from the collection of logins.
        /// </summary>
        /// <param name="providerName">The provider name for the login (i.e. graph.facebook.com)</param>
        [Obsolete("Use AWSCredentials.RemoveLogin")]
        public void RemoveLogin(string providerName)
        {
            this.Logins.Remove(providerName);
        }

        /// <summary>
        /// Adds a login to be used for authenticated requests.
        /// </summary>
        /// <param name="providerName">The provider name for the login (i.e. graph.facebook.com)</param>
        /// <param name="token">The token provided by the identity provider.</param>
        [Obsolete("Use AWSCredentials.AddLogin")]
        public void AddLogin(string providerName, string token)
        {
            Logins[providerName] = token;
        }

        /// <summary>
        /// Gets the Identity Id corresponding to the credentials retrieved from Cognito.
        /// Note: this setting may change during execution. To be notified of its
        /// new value, attach a listener to IdentityChangedEvent
        /// </summary>
        public string GetCurrentIdentityId()
        {
            return _identityId;
        }

        /// <summary>
        /// Event for identity change notifications.
        /// This event will fire whenever the Identity Id changes.
        /// </summary>
        public event EventHandler<IdentityChangedArgs> IdentityChangedEvent;

        public string GetCurrentOpenIdToken()
        {
            return _token;
        }

        public abstract string getProviderName();

        public abstract void RefreshAsync(AmazonServiceCallback callback, object state);
    }

}
