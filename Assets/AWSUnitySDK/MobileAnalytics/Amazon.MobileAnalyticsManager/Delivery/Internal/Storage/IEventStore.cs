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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ThirdParty.Json.LitJson;

[assembly:InternalsVisibleTo("Assembly-CSharp-Editor")]
namespace Amazon.MobileAnalyticsManager.Delivery.Internal
{
    internal interface IEventStore
    {
        /// <summary>
        /// Add an event to the store.
        /// </summary>
        /// <returns><c>true</c>, if event was put, <c>false</c> otherwise.</returns>
        bool PutEvent(string eventString, string appId);
        
        /// <summary>
        /// Get All event from the Event Store
        /// </summary>
        /// <param name="appid">Appid.</param>
        /// <returns>All the events as a List of <see cref="ThirdParty.Json.LitJson.JsonData"/>.</returns>
        List<JsonData> GetAllEvents(string appid);
        
        /// <summary>
        /// Deletes a list of events.
        /// </summary>
        /// <returns><c>true</c>, if events was deleted, <c>false</c> otherwise.</returns>
        /// <param name="rowIds">Row identifiers.</param>
        bool DeleteEvent(List<string> rowIds);
        
        /// <summary>
        /// Gets Numbers the of events.
        /// </summary>
        /// <returns>The number of events.</returns>
        long NumberOfEvents(string appid);
        
        /// <summary>
        /// Increments the delivery attempt.
        /// </summary>
        /// <returns><c>true</c>, if delivery attempt was incremented, <c>false</c> otherwise.</returns>
        /// <param name="rowIds">Row identifiers.</param>
        bool IncrementDeliveryAttempt(List<string> rowIds);
        
        /// <summary>
        /// Gets the size of the database.
        /// </summary>
        /// <returns>The database size.</returns>
        long GetDatabaseSize();
        
    }
}

