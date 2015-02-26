using UnityEngine;
using System.Collections;
using System;

using Amazon.MobileAnalyticsManager.Session;

namespace Amazon.MobileAnalyticsManager.Event
{
    public class AmazonMobileAnalyticsMonetizationEvent : AmazonMobileAnalyticsEvent 
    {
        // event type
        private const string PURCHASE_EVENT_NAME = "_monetization.purchase";
        
        // metric name
        private const string PURCHASE_EVENT_QUANTITY_METRIC = "_quantity";
        private const string PURCHASE_EVENT_ITEM_PRICE_METRIC = "_item_price";
        
        // attribute name
        private const string PURCHASE_EVENT_PRODUCT_ID_ATTR = "_product_id";
        private const string PURCHASE_EVENT_ITEM_PRICE_FORMATTED_ATTR = "_item_price_formatted";
        private const string PURCHASE_EVENT_STORE_ATTR = "_store";
        private const string PURCHASE_EVENT_TRANSACTION_ID_ATTR = "_transaction_id";
        private const string PURCHASE_EVENT_CURRENCY_ATTR = "_currency";

        public AmazonMobileAnalyticsMonetizationEvent() : base(PURCHASE_EVENT_NAME)
        {
        }
        
        // metrics
        
        /// <summary>
        /// Sets the quantity.
        /// </summary>
        /// <value>The quantity. For example, 1.0 </value>
        public double? Quantity {private get;set;}
        
        /// <summary>
        /// Sets the item price.
        /// </summary>
        /// <value>The item price. For example, 3.0 </value>
        public double? ItemPrice {private get;set;}
        
        // attributes

        /// <summary>
        /// Sets the product identifier.
        /// </summary>
        /// <value>The product identifier. For example, ProductId123.</value>
        public string ProductId {private get;set;}

        /// <summary>
        /// Sets the item price formatted.
        /// </summary>
        /// <value>The item price formatted. For example, $1.99 </value>
        public string ItemPriceFormatted {private get;set;}
        
        /// <summary>
        /// Sets the store.
        /// </summary>
        /// <value>The store. For example, AppStore.</value>
        public string Store {private get;set;}
        
        /// <summary>
        /// Sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier. For example, TransactionId123.</value>
        public string TransactionId {private get;set;}
        
        /// <summary>
        /// Sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency {private get;set;}
        
        /// <summary>
        /// Converts to mobile analytics model event. <see cref="Amazon.MobileAnalytics.Model.Event"/>
        /// </summary>
        /// <returns>The to mobile analytics model event.</returns>
        /// <param name="session">Session.</param>
        override public Amazon.MobileAnalytics.Model.Event ConvertToMobileAnalyticsModelEvent(AmazonMobileAnalyticsSession session)
        {
            if(Quantity != null)
            {
                this.AddMetric(PURCHASE_EVENT_QUANTITY_METRIC,Convert.ToDouble(Quantity));
            }
            
            if(ItemPrice != null)
            {
                this.AddMetric(PURCHASE_EVENT_ITEM_PRICE_METRIC,Convert.ToDouble(ItemPrice));
            }
            
            if(!string.IsNullOrEmpty(ProductId))
            {
                this.AddAttribute(PURCHASE_EVENT_PRODUCT_ID_ATTR,ProductId);
            }
            
            if(!string.IsNullOrEmpty(ItemPriceFormatted))
            {
                this.AddAttribute(PURCHASE_EVENT_ITEM_PRICE_FORMATTED_ATTR,ItemPriceFormatted);
            }
            
            if(!string.IsNullOrEmpty(Store))
            {
                this.AddAttribute(PURCHASE_EVENT_STORE_ATTR,Store);
            }
            
            if(!string.IsNullOrEmpty(TransactionId))
            {
                this.AddAttribute(PURCHASE_EVENT_TRANSACTION_ID_ATTR,TransactionId);
            }
            
            if(!string.IsNullOrEmpty(Currency))
            {
                this.AddAttribute(PURCHASE_EVENT_CURRENCY_ATTR,Currency);
            }
            
            return base.ConvertToMobileAnalyticsModelEvent(session);
        }

    }

}


