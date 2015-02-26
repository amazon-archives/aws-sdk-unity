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
using System.IO;
using System.Threading;
using UnityEngine;
using Amazon.Unity3D;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalyticsManager.Config
{
    internal class AmazonMobileAnalyticsJsonUtil
    {
        private static string TAG = "AmazonMobileAnalyticsJsonUtil";
        private static bool loaded=false;
        private static JsonData Properties;
        
        public AmazonMobileAnalyticsJsonUtil()
        {
            if(!loaded){
                LoadProperties();
            }
        }
        
        /// <summary>
        /// Loads the database properties from json file in rerouces folder.
        /// </summary>
        private static void LoadProperties()
        {
            try
            {
                TextAsset awsMobileAnalytics = UnityEngine.Resources.Load("aws_mobile_analytics") as TextAsset;
                using (Stream stream = new MemoryStream(awsMobileAnalytics.bytes))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        LoadProperties(reader);
                    }
                }
            }
            catch(Exception exception)
            {
                AmazonLogging.LogError(TAG,
                                       "Error loading the mobile analytics properties. Are you sure you have included the aws_mobile_analytics.json file in the MobileAnalytics->Resources folder" + exception.Message);
                throw exception;
            }
        }
        
        /// <summary>
        /// Loads the database properties.
        /// </summary>
        /// <param name="reader">Reader.</param>
        private static void LoadProperties(TextReader reader)
        {
            if(loaded)
            {
                return;
            }
            JsonData awsMobileAnalyticsProperties = null;
            try
            {
                awsMobileAnalyticsProperties =  JsonMapper.ToObject(new JsonReader(reader));
                Properties = awsMobileAnalyticsProperties["XML"]["Properties"];
                loaded = true;
            }
            catch(Exception exception)
            {
                loaded = false;
                AmazonLogging.LogError(TAG,"Error loading the jsonProperties " + exception.Message);
                AmazonLogging.LogError(TAG,exception.Message);
            }
        }
        
        /// <summary>
        /// Gets the long.
        /// </summary>
        /// <returns>The long.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">Default value.</param>
        public long GetLong(String propertyName, long defaultValue)
        {
            string value = null;
            try{
                value = Convert.ToString(Properties[propertyName]);
                long retValue = defaultValue;
                retValue = Convert.ToInt64(value);
                return retValue;
            }catch(Exception e){
                AmazonLogging.LogWarn(TAG,"Unable to parse " + value + " to long");
                AmazonLogging.LogException(TAG,e);
            }
            return defaultValue;
        }
        
        
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">Default value.</param>
        public string GetString(String propertyName, String defaultValue)
        {
            string value = Convert.ToString(Properties[propertyName]);
            return (value==null)?defaultValue:value;
        }
        
        
        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">Default value.</param>
        public int GetInt(String propertyName, int defaultValue)
        {
            string value = null;
            try{
                value = Convert.ToString(Properties[propertyName]);
                int retValue = defaultValue;
                retValue = Convert.ToInt32(value);
                return retValue;
            }catch(Exception e){
                AmazonLogging.LogWarn(TAG,"Unable to parse " + value + " to int");
                AmazonLogging.LogException(TAG,e);
            }
            return defaultValue;
        }
        
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <returns><c>true</c>, if boolean was gotten, <c>false</c> otherwise.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">If set to <c>true</c> default value.</param>
        public bool GetBoolean(String propertyName, bool defaultValue)
        {   
            string value = null;
            try{
                value = Convert.ToString(Properties[propertyName]);
                bool retValue = defaultValue;
                retValue = Convert.ToBoolean(value);
                return retValue;
            }catch(Exception e){
                AmazonLogging.LogWarn("AmazonMobileAnalyticsJsonUtil","Unable to parse " + value + " to bool");
                AmazonLogging.LogException("AmazonMobileAnalyticsJsonUtil",e);
            }
            return defaultValue;
        }
        
        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">Default value.</param>
        public double GetDouble(String propertyName,double defaultValue)
        {
            string value = null;
            try{
                value = Convert.ToString(Properties[propertyName]);
                double retValue = defaultValue;
                retValue = Convert.ToDouble(value);
                return retValue;
            }catch(Exception e){
                AmazonLogging.LogWarn(TAG,"Unable to parse " + value + " to double");
                AmazonLogging.LogException(TAG,e);
            }
            return defaultValue;
        }
        
        /// <summary>
        /// Gets the short.
        /// </summary>
        /// <returns>The short.</returns>
        /// <param name="PropertyName">Property name.</param>
        /// <param name="defaultValue">Default value.</param>
        public short GetShort(String propertyName, short defaultValue)
        {
            string value=null;
            try{
                value = Convert.ToString(Properties[propertyName]);
                short retValue = defaultValue;
                retValue = Convert.ToInt16(value);
                return retValue;
            }catch(Exception e){
                AmazonLogging.LogWarn(TAG,"Unable to parse " + value + " to short ");
                AmazonLogging.LogException(TAG,e);
            }
            return defaultValue;
        }
        
    }

}



