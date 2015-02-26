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
using UnityEngine;
using System;

namespace Amazon.Unity3D
{

    /// <summary>
    /// Plugins can often produce unwanted and noisy log output.
    /// AmazonLogging provides a common interface for Amazon plugins so
    /// developers can turn down the messaging output when necessary.
    /// </summary>
    public class AmazonLogging
    {
        protected static LoggingLevel _level = LoggingLevel.DEBUG;
        public static LoggingLevel Level 
        {
            set
            {
                _level = value;
            } 
        
            get
            {
                return _level;
            }
        }


        // This is the logging level used by Amazon plugins.
        // If message's level is larger than current SDK loggging level, the message would not be printed.
        public enum LoggingLevel
        {
            OFF = 0,
            FATAL,
            EXCEPTION,
            ERROR,
            WARN,
            INFO,
            DEBUG
        }


        // {0} is the message tag, {1} is the message.
        private const string fatalMessage = "[{0}] FATAL: {1}";
        private const string exceptionMessage = "[{0}] EXCEPTION: {1}";
        private const string errorMessage = "[{0}] ERROR: {1}";
        private const string warnMessage = "[{0}] WARN: {1}";
        private const string infoMessage = "[{0}] INFO: {1}";
        private const string debugMessage = "[{0}] DEBUG: {1}";
        

        #region Public functions
        /// <summary>
        /// Logs the FATAL level message.
        /// If current LogginLevel < FATAL, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogFatal(string tag, string message)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(message == null)
                throw new ArgumentNullException("message");
            
            
            if (Level < LoggingLevel.FATAL)
            {
                return;
            }
            Debug.LogError(string.Format(fatalMessage, tag, message));
        }
        
        /// <summary>
        /// Logs the EXCEPTION level message.
        /// If current LoggingLevel < EXCEPTION, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogException(string tag, Exception e)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(e == null)
                throw new ArgumentNullException("e");
            
            if (Level < LoggingLevel.EXCEPTION)
            {
                return;
            }

            Debug.LogException(e);
        }
        
        /// <summary>
        /// Logs the ERROR level message.
        /// If current LoggingLevel < ERROR, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogError(string tag, string message)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(message == null)
                throw new ArgumentNullException("message");
            
            if (Level < LoggingLevel.ERROR)
            {
                return;
            }
            Debug.LogError(string.Format(errorMessage, tag, message));
        }

        /// <summary>
        /// Logs the WARN level message.
        /// If current LoggingLevel < WARN, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogWarn(string tag, string message)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(message == null)
                throw new ArgumentNullException("message");
            
            if (Level < LoggingLevel.WARN)
            {
                return;
            }
            Debug.LogWarning(string.Format(warnMessage, tag, message));

        }

        /// <summary>
        /// Logs the INFO level message.
        /// If current LoggingLevel < INFO, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogInfo(string tag, string message)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(message == null)
                throw new ArgumentNullException("message");

            if (Level < LoggingLevel.INFO)
            {
                return;
            }
            Debug.Log(string.Format(infoMessage, tag, message));
        }

        /// <summary>
        /// Logs the DEBUG level message.
        /// If current LoggingLevel < DEBUG, this message would not be printed.
        /// </summary>
        /// <param name="tag">tag of the message </param>
        /// <param name="message">Logging message.</param>
        internal static void LogDebug(string tag, string message)
        {
            if(tag == null)
                throw new ArgumentNullException("tag");
            
            if(message == null)
                throw new ArgumentNullException("message");
            
            if (Level < LoggingLevel.DEBUG)
            {
                return;
            }
            Debug.Log(string.Format(debugMessage, tag, message));
        }
        #endregion
    }

}