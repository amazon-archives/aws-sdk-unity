//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//

/*
 * Do not modify this file. This file is generated from the email-2010-12-01.normal.json service model.
 */

using System;
using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.SimpleEmail.Model;

namespace Amazon.SimpleEmail
{
    /// <summary>
    /// Interface for accessing SimpleEmailService
    ///
    /// Amazon Simple Email Service 
    /// <para>
    ///  This is the API Reference for Amazon Simple Email Service (Amazon SES). This documentation
    /// is intended to be used in conjunction with the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/Welcome.html">Amazon
    /// SES Developer Guide</a>. 
    /// </para>
    ///  <note>For a list of Amazon SES endpoints to use in service requests, see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/regions.html">Regions
    /// and Amazon SES</a> in the Amazon SES Developer Guide. </note>
    /// </summary>
    public partial interface IAmazonSimpleEmailService : IDisposable
    {

        
        #region  DeleteIdentity


        /// <summary>
        /// Initiates the asynchronous execution of the DeleteIdentity operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeleteIdentity operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void DeleteIdentityAsync(DeleteIdentityRequest request, AmazonServiceCallback<DeleteIdentityRequest, DeleteIdentityResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  DeleteIdentityPolicy


        /// <summary>
        /// Initiates the asynchronous execution of the DeleteIdentityPolicy operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeleteIdentityPolicy operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void DeleteIdentityPolicyAsync(DeleteIdentityPolicyRequest request, AmazonServiceCallback<DeleteIdentityPolicyRequest, DeleteIdentityPolicyResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  DeleteVerifiedEmailAddress


        /// <summary>
        /// Initiates the asynchronous execution of the DeleteVerifiedEmailAddress operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeleteVerifiedEmailAddress operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void DeleteVerifiedEmailAddressAsync(DeleteVerifiedEmailAddressRequest request, AmazonServiceCallback<DeleteVerifiedEmailAddressRequest, DeleteVerifiedEmailAddressResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetIdentityDkimAttributes


        /// <summary>
        /// Initiates the asynchronous execution of the GetIdentityDkimAttributes operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetIdentityDkimAttributes operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetIdentityDkimAttributesAsync(GetIdentityDkimAttributesRequest request, AmazonServiceCallback<GetIdentityDkimAttributesRequest, GetIdentityDkimAttributesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetIdentityNotificationAttributes


        /// <summary>
        /// Initiates the asynchronous execution of the GetIdentityNotificationAttributes operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetIdentityNotificationAttributes operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetIdentityNotificationAttributesAsync(GetIdentityNotificationAttributesRequest request, AmazonServiceCallback<GetIdentityNotificationAttributesRequest, GetIdentityNotificationAttributesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetIdentityPolicies


        /// <summary>
        /// Initiates the asynchronous execution of the GetIdentityPolicies operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetIdentityPolicies operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetIdentityPoliciesAsync(GetIdentityPoliciesRequest request, AmazonServiceCallback<GetIdentityPoliciesRequest, GetIdentityPoliciesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetIdentityVerificationAttributes


        /// <summary>
        /// Initiates the asynchronous execution of the GetIdentityVerificationAttributes operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetIdentityVerificationAttributes operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetIdentityVerificationAttributesAsync(GetIdentityVerificationAttributesRequest request, AmazonServiceCallback<GetIdentityVerificationAttributesRequest, GetIdentityVerificationAttributesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetSendQuota


        /// <summary>
        /// Returns the user's current sending limits.
        /// 
        ///  
        /// <para>
        /// This action is throttled at one request per second.
        /// </para>
        /// </summary>
         /// <param name="options">
         ///     A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
         ///     procedure using the AsyncState property.
         /// </param>
        /// 
        /// <returns>The response from the GetSendQuota service method, as returned by SimpleEmailService.</returns>
        void GetSendQuotaAsync( AmazonServiceCallback<GetSendQuotaRequest, GetSendQuotaResponse> callback, AsyncOptions options = null);

        /// <summary>
        /// Initiates the asynchronous execution of the GetSendQuota operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetSendQuota operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetSendQuotaAsync(GetSendQuotaRequest request, AmazonServiceCallback<GetSendQuotaRequest, GetSendQuotaResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  GetSendStatistics


        /// <summary>
        /// Returns the user's sending statistics. The result is a list of data points, representing
        /// the last two weeks of sending activity. 
        /// 
        ///  
        /// <para>
        /// Each data point in the list contains statistics for a 15-minute interval.
        /// </para>
        ///  
        /// <para>
        /// This action is throttled at one request per second.
        /// </para>
        /// </summary>
         /// <param name="options">
         ///     A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
         ///     procedure using the AsyncState property.
         /// </param>
        /// 
        /// <returns>The response from the GetSendStatistics service method, as returned by SimpleEmailService.</returns>
        void GetSendStatisticsAsync( AmazonServiceCallback<GetSendStatisticsRequest, GetSendStatisticsResponse> callback, AsyncOptions options = null);

        /// <summary>
        /// Initiates the asynchronous execution of the GetSendStatistics operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetSendStatistics operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void GetSendStatisticsAsync(GetSendStatisticsRequest request, AmazonServiceCallback<GetSendStatisticsRequest, GetSendStatisticsResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  ListIdentities


        /// <summary>
        /// Returns a list containing all of the identities (email addresses and domains) for
        /// a specific AWS Account, regardless of verification status.
        /// 
        ///  
        /// <para>
        /// This action is throttled at one request per second.
        /// </para>
        /// </summary>
         /// <param name="options">
         ///     A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
         ///     procedure using the AsyncState property.
         /// </param>
        /// 
        /// <returns>The response from the ListIdentities service method, as returned by SimpleEmailService.</returns>
        void ListIdentitiesAsync( AmazonServiceCallback<ListIdentitiesRequest, ListIdentitiesResponse> callback, AsyncOptions options = null);

        /// <summary>
        /// Initiates the asynchronous execution of the ListIdentities operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListIdentities operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void ListIdentitiesAsync(ListIdentitiesRequest request, AmazonServiceCallback<ListIdentitiesRequest, ListIdentitiesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  ListIdentityPolicies


        /// <summary>
        /// Initiates the asynchronous execution of the ListIdentityPolicies operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListIdentityPolicies operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void ListIdentityPoliciesAsync(ListIdentityPoliciesRequest request, AmazonServiceCallback<ListIdentityPoliciesRequest, ListIdentityPoliciesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  ListVerifiedEmailAddresses


        /// <summary>
        /// Returns a list containing all of the email addresses that have been verified.
        /// 
        ///  <important>The ListVerifiedEmailAddresses action is deprecated as of the May 15,
        /// 2012 release of Domain Verification. The ListIdentities action is now preferred.</important>
        /// 
        /// <para>
        /// This action is throttled at one request per second.
        /// </para>
        /// </summary>
         /// <param name="options">
         ///     A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
         ///     procedure using the AsyncState property.
         /// </param>
        /// 
        /// <returns>The response from the ListVerifiedEmailAddresses service method, as returned by SimpleEmailService.</returns>
        void ListVerifiedEmailAddressesAsync( AmazonServiceCallback<ListVerifiedEmailAddressesRequest, ListVerifiedEmailAddressesResponse> callback, AsyncOptions options = null);

        /// <summary>
        /// Initiates the asynchronous execution of the ListVerifiedEmailAddresses operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListVerifiedEmailAddresses operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void ListVerifiedEmailAddressesAsync(ListVerifiedEmailAddressesRequest request, AmazonServiceCallback<ListVerifiedEmailAddressesRequest, ListVerifiedEmailAddressesResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  PutIdentityPolicy


        /// <summary>
        /// Initiates the asynchronous execution of the PutIdentityPolicy operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the PutIdentityPolicy operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void PutIdentityPolicyAsync(PutIdentityPolicyRequest request, AmazonServiceCallback<PutIdentityPolicyRequest, PutIdentityPolicyResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  SendEmail


        /// <summary>
        /// Initiates the asynchronous execution of the SendEmail operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SendEmail operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void SendEmailAsync(SendEmailRequest request, AmazonServiceCallback<SendEmailRequest, SendEmailResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  SendRawEmail


        /// <summary>
        /// Initiates the asynchronous execution of the SendRawEmail operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SendRawEmail operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void SendRawEmailAsync(SendRawEmailRequest request, AmazonServiceCallback<SendRawEmailRequest, SendRawEmailResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  SetIdentityDkimEnabled


        /// <summary>
        /// Initiates the asynchronous execution of the SetIdentityDkimEnabled operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SetIdentityDkimEnabled operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void SetIdentityDkimEnabledAsync(SetIdentityDkimEnabledRequest request, AmazonServiceCallback<SetIdentityDkimEnabledRequest, SetIdentityDkimEnabledResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  SetIdentityFeedbackForwardingEnabled


        /// <summary>
        /// Initiates the asynchronous execution of the SetIdentityFeedbackForwardingEnabled operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SetIdentityFeedbackForwardingEnabled operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void SetIdentityFeedbackForwardingEnabledAsync(SetIdentityFeedbackForwardingEnabledRequest request, AmazonServiceCallback<SetIdentityFeedbackForwardingEnabledRequest, SetIdentityFeedbackForwardingEnabledResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  SetIdentityNotificationTopic


        /// <summary>
        /// Initiates the asynchronous execution of the SetIdentityNotificationTopic operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SetIdentityNotificationTopic operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void SetIdentityNotificationTopicAsync(SetIdentityNotificationTopicRequest request, AmazonServiceCallback<SetIdentityNotificationTopicRequest, SetIdentityNotificationTopicResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  VerifyDomainDkim


        /// <summary>
        /// Initiates the asynchronous execution of the VerifyDomainDkim operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the VerifyDomainDkim operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void VerifyDomainDkimAsync(VerifyDomainDkimRequest request, AmazonServiceCallback<VerifyDomainDkimRequest, VerifyDomainDkimResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  VerifyDomainIdentity


        /// <summary>
        /// Initiates the asynchronous execution of the VerifyDomainIdentity operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the VerifyDomainIdentity operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void VerifyDomainIdentityAsync(VerifyDomainIdentityRequest request, AmazonServiceCallback<VerifyDomainIdentityRequest, VerifyDomainIdentityResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  VerifyEmailAddress


        /// <summary>
        /// Initiates the asynchronous execution of the VerifyEmailAddress operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the VerifyEmailAddress operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void VerifyEmailAddressAsync(VerifyEmailAddressRequest request, AmazonServiceCallback<VerifyEmailAddressRequest, VerifyEmailAddressResponse> callback, AsyncOptions options = null);


        #endregion
        
        #region  VerifyEmailIdentity


        /// <summary>
        /// Initiates the asynchronous execution of the VerifyEmailIdentity operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the VerifyEmailIdentity operation on AmazonSimpleEmailServiceClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        void VerifyEmailIdentityAsync(VerifyEmailIdentityRequest request, AmazonServiceCallback<VerifyEmailIdentityRequest, VerifyEmailIdentityResponse> callback, AsyncOptions options = null);


        #endregion
        
    }
}