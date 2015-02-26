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
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon.Unity3D;
using Amazon.MobileAnalyticsManager.Delivery.Internal;
using Amazon.MobileAnalyticsManager;
using Amazon.MobileAnalyticsManager.Event;
using Amazon.MobileAnalyticsManager.Config;
using Amazon.MobileAnalyticsManager.ClientContext;

using Amazon.MobileAnalytics;
using Amazon.MobileAnalytics.Model;

using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalyticsManager.Delivery
{
    internal class AmazonMADefaultDeliveryClient:IAmazonMADeliveryClient
    {
        private static string TAG = "MobileAnalyticsDeliveryClient";
        
        private static bool _deliveryInProgress = false;
        private static object _deliveryLock = new object();
                
        private readonly IAmazonMADeliveryPolicyFactory _policyFactory;
        private IEventStore _eventStore;
        private IAmazonMobileAnalyticsManagerConfig _configuration;
        private AmazonMobileAnalyticsClientContext _clientContext;
        private AmazonMobileAnalyticsClient _maClient;
        private string _appId;
        private List<IAmazonMADeliveryPolicy>  _deliveryPolicies;
        
        /// <returns>New instance of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryClient"/></returns>
        /// <param name="isDataAllowed">If set to <c>true</c> The delivery will be attempted even on Data Network, else it will be only attempted on Wifi</param>
        /// <param name="credentials">An instance of Credentials<see cref="Amazon.Runtime.AWSCredentials"/></param>
        /// <param name="regionEndPoint">Region end point <see cref="Amazon.RegionEndpoint"/></param>
        public static IAmazonMADeliveryClient newInstance(bool isDataAllowed,
                                                          AmazonMobileAnalyticsClientContext clientContext,
                                                          AWSCredentials credentials,
                                                          RegionEndpoint regionEndPoint)
        {
            return new AmazonMADefaultDeliveryClient(
                    new Amazon.MobileAnalyticsManager.Delivery.AmazonMADefaultDeliveryPolicyFactory(isDataAllowed),
                    clientContext,
                    credentials,
                    regionEndPoint);
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amazon.MobileAnalyticsManager.Delivery.AmazonMADefaultDeliveryClient"/> class.
        /// </summary>
        /// <param name="policyFactory">Policy factory for standard policies for the delivery Client <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicyFactory"/></param>
        /// <param name="credentials">An instance of Credentials<see cref="Amazon.Runtime.AWSCredentials"/></param>
        /// <param name="regionEndPoint">Region end point <see cref="Amazon.RegionEndpoint"/></param>
        public AmazonMADefaultDeliveryClient(IAmazonMADeliveryPolicyFactory policyFactory,
                                             AmazonMobileAnalyticsClientContext clientContext, 
                                             AWSCredentials credentials,
                                             RegionEndpoint regionEndPoint)
        {
            _policyFactory  = policyFactory;
            _maClient = new AmazonMobileAnalyticsClient(credentials,regionEndPoint);
            _configuration = AmazonMobileAnalyticsManager.Config;
            _clientContext = clientContext;
            _appId = clientContext.Config.AppId;
            _eventStore = new SQLiteEventStore(_configuration.MAX_DB_SIZE,_configuration.DB_WARNING_THRESHOLD);
            _deliveryPolicies = new List<IAmazonMADeliveryPolicy>();
            _deliveryPolicies.Add(_policyFactory.NewConnectivityPolicy());
            _deliveryPolicies.Add(_policyFactory.NewBackgroundSubmissionPolicy());
        }
        
        /// <summary>
        /// Enqueues the events for delivery. The event is stored in an <see cref="Amazon.MobileAnalyticsManager.Delivery.Internal.IEventStore"/>.
        /// </summary>
        /// <param name="eventObject">Event object. <see cref="Amazon.MobileAnalytics.Model.Event"/></param>
        public void EnqueueEventsForDelivery(Amazon.MobileAnalytics.Model.Event eventObject)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate 
            {   
                string eventString = JsonMapper.ToJson(eventObject);
                bool eventStored = _eventStore.PutEvent(eventString,_appId);
                if(eventStored) {                    
                    AmazonLogging.LogInfo(TAG,"Event " + eventObject.EventType + " queued for delivery.");
                }
                else {            
                    AmazonLogging.LogError(TAG,"Event " + eventObject.EventType + " unable to be queued for delivery.");
                }
                
            }));
        }
        
        /// <summary>
        /// Set custom policies to the delivery client. This will allow you to fine grain control on when an attempt should be made to deliver the events on the service.
        /// </summary>
        /// <param name="policy">An instance of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/></param>
        public void AddDeliveryPolicies(IAmazonMADeliveryPolicy policy)
        {
            if(policy!=null)
                _deliveryPolicies.Add(policy);
        }
        
        /// <summary>
        /// Attempts the delivery of all the events from local store to service
        /// </summary>
        public void AttemptDelivery()
        {
            lock(_deliveryLock)
            {
                if(_deliveryInProgress)
                {
                    AmazonLogging.LogInfo(TAG,"Delivery already in progress, failing new delivery");
                    return;
                }
                _deliveryInProgress = true;
            }
            
            if(_maClient == null)
            {
                throw new InvalidOperationException("You must set Client before attempting delivery");
            }
            AttemptDelivery(_deliveryPolicies);
        }
        
        /// <summary>
        /// Attempts the delivery. This method needs to be called from a background thread only otherwise it will throw an exception.
        /// Will fail delivery if any of the policies.isAllowed() returns false
        /// The policies are attmpted in batches of fixed size. To increase or decrease the size of bytes transfered per batch you can use 
        /// <see cref="Amazon.MobileAnalyticsManager.Config.IAmazonMobileAnalyticsManagerConfig"/> and configure the MAX_REQUEST_SIZE property. 
        /// </summary>
        /// <param name="policies">list of <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/></param>
        private void AttemptDelivery(List<IAmazonMADeliveryPolicy> policies)
        {
            
            AmazonLogging.LogDebug(TAG,"AttemptDelivery");
            
            //validate all the policies before attempting the delivery
            foreach(IAmazonMADeliveryPolicy policy in policies){
                if(!policy.IsAllowed()){
                    AmazonLogging.LogInfo(TAG, "Policy restriction : " + policy.GetType().Name);
                    lock(_deliveryLock)
                    {
                        _deliveryInProgress = false;
                    }
                    return;
                }
            }
            
            List<string> rowIds = new List<string>();
            
            long maxRequestSize = _configuration.MAX_REQUEST_SIZE;
            List<JsonData> eventList = _eventStore.GetAllEvents(_appId);
            
            if(eventList.Count == 0)
            {
                AmazonLogging.LogInfo(TAG,"No Events to deliver");
                lock(_deliveryLock)
                {
                    _deliveryInProgress = false;
                }
                return;
            }
            
            long eventsLength = 0L;
            
            List<Amazon.MobileAnalytics.Model.Event> eventArray = new List<Amazon.MobileAnalytics.Model.Event>();
            foreach(JsonData eventData in eventList)
            {
                eventsLength += ((string)eventData["event"]).Length;
                if(eventsLength < maxRequestSize){
                    string eventString = (string)eventData["event"];
                    AmazonLogging.LogInfo(TAG,eventString);
                    Amazon.MobileAnalytics.Model.Event _analyticsEvent = JsonMapper.ToObject<Amazon.MobileAnalytics.Model.Event>(eventString);
                    eventArray.Add(_analyticsEvent);
                    rowIds.Add(eventData["id"].ToString());
                }else{
                    SubmitEvents(rowIds,eventArray,new AmazonServiceCallback((AmazonServiceResult result) => {
                        HandleResponse(result,policies);
                    }));
                    rowIds = new List<string>();
                    eventsLength = 0L;
                }
            }
            SubmitEvents(rowIds,eventArray,new AmazonServiceCallback((AmazonServiceResult result) => {
                    HandleResponse(result,policies);
            }));
            rowIds = new List<string>();
            eventsLength = 0L;
        }
        
        /// <summary>
        /// Submits a single batch of events to the service.
        /// </summary>
        /// <param name="rowIds">Row identifiers. The list of rowIds is returned back once the service execution completes on the background thread.</param>
        /// <param name="eventArray">All the events that need to be submitted</param>
        /// <param name="callback">Callback Handler once the Service Attempts the delivery</param>
        private void SubmitEvents(List<string> rowIds,List<Amazon.MobileAnalytics.Model.Event> eventList,AmazonServiceCallback callback)
        {
            if(eventList  == null || eventList.Count == 0)
            {
                lock(_deliveryLock)
                {
                    _deliveryInProgress = false;
                }
                return;
            }
            
            PutEventsRequest putRequest = new PutEventsRequest();
            putRequest.Events = eventList;
            putRequest.ClientContext = Convert.ToBase64String(
                                        System.Text.Encoding.UTF8.GetBytes(_clientContext.ToJsonString()));
            putRequest.ClientContextEncoding = "base64";
            AmazonLogging.LogDebug(TAG,"Client context is:  " + _clientContext.ToJsonString());
            _maClient.PutEventsAsync(putRequest,callback,rowIds);
        }
        
        /// <summary>
        /// Call to handle the response for each delivery Attempt.
        /// Notifies all the policies once delivery attemp has been completed.
        /// If the delivery is successful then it deletes the events from the <see cref="Amazon.MobileAnalyticsManager.Delivery.Internal.IEventStore"/>
        /// If the delivery was not successful then depending on the response the event may be deleted (e.g. 400 Http response , non throttle scenario) or the delivery count may be incremented
        /// </summary>
        /// <param name="result">Result <see cref="Amazon.Runtime.AmazonServiceResult"/></param>
        /// <param name="policies">delivery Policies to notify, <see cref="Amazon.MobileAnalyticsManager.Delivery.IAmazonMADeliveryPolicy"/> on success or response of service</param>
        private void HandleResponse(AmazonServiceResult result,List<IAmazonMADeliveryPolicy> policies)
        {
            List<string> rowsToUpdate = (List<string>)result.State;
            bool success = false;
            bool retrialable = false;
            
            if(result.Exception != null && result.HttpResponseData != null && result.HttpResponseData.IsHeaderPresent("X-AMZN-ERRORTYPE"))
            {
                try{
                    
                    string errorType = result.HttpResponseData.GetHeaderValue("X-AMZN-ERRORTYPE");
                    AmazonLogging.LogInfo(TAG,"error type = " + errorType);
                    
                    if(errorType.StartsWith("ThrottlingException"))
                    {
                        retrialable = true;
                    }
                    
                    int statusCode;
                    string messsage = result.Exception.Message;
                    AmazonLogging.LogInfo(TAG, "Delivery Client get error msg from http client: " + messsage);
                    if(Int32.TryParse(messsage.Substring(0,3), out statusCode))
                    {
                        if(statusCode>=500)
                        {
                            retrialable = true;
                        }
                    }
                }catch(Exception e){
                    AmazonLogging.LogWarn(TAG,"unable to parse response status");
                    AmazonLogging.LogException(TAG,e);
                }
            }
            else if(result.Exception != null && result.IsCognitoError )
            {
                AmazonLogging.LogInfo(TAG,"unable to deliver events because Cognito credential failure");
                retrialable = false;
            }
            else if(result.Exception != null )
            {
                AmazonLogging.LogInfo(TAG,"unable to deliver events");
                retrialable = true;
            }
            else
            {
                success = true;
                AmazonLogging.LogInfo(TAG,"successfully delivered " + rowsToUpdate.Count + " events");
                if(result.Response != null)
                    AmazonLogging.LogInfo(TAG,"HTTP response " + result.Response.HttpStatusCode );
            }
            
            if(!retrialable)
            {
                if(!success)
                    AmazonLogging.LogInfo(TAG,"unable to deliver events, delete as events cannot be retried");
                else
                    AmazonLogging.LogInfo(TAG,"events delivered, deleting them from local store");
                
                _eventStore.DeleteEvent(rowsToUpdate);
            }
            else
            {   
                AmazonLogging.LogInfo(TAG,"unable to deliver events, events will be retried in next attempt");
                _eventStore.IncrementDeliveryAttempt(rowsToUpdate);
            }
            
            foreach(IAmazonMADeliveryPolicy policy in policies)
            {
                policy.HandleDeliveryAttempt(success);
            }
            
            lock(_deliveryLock)
            {
                _deliveryInProgress = false;
            }
        }
    }
}