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
using System.Collections;
using System;
using Amazon.Unity3D;
using Amazon.MobileAnalyticsManager.Event;
using Amazon.Util;
using Amazon.Unity3D.Storage;
using ThirdParty.Json.LitJson;
using System.IO;

namespace Amazon.MobileAnalyticsManager.Session
{
    public class AmazonMobileAnalyticsSession
    {
        private static string TAG = "AmazonMobileAnalyticsSession";
        
        // Event Type Constants ---------------------------
        public static string SESSION_START_EVENT_TYPE            = "_session.start";
        public static string SESSION_STOP_EVENT_TYPE             = "_session.stop";
        public static string SESSION_PAUSE_EVENT_TYPE            = "_session.pause";
        public static string SESSION_RESUME_EVENT_TYPE           = "_session.resume";
        // Event Attribute/Metric Key Constants -----------
        private const string SESSION_ID_ATTRIBUTE_KEY            = "_session.id";
        private const string SESSION_DURATION_METRIC_KEY         = "_session.duration";
        private const string SESSION_START_TIME_ATTRIBUTE_KEY    = "_session.startTime";
        private const string SESSION_STOP_TIME_ATTRIBUTE_KEY     = "_session.stopTime";
        
        
        // session info
        private DateTime _startTime;
        private DateTime? _stopTime;
        private DateTime _preStartTime;
        private string _sessionId;
        private long _duration;
        
        // lock to guard session info
        private Object _lock = new Object();
       


        public class SessionStorage
        {
            public SessionStorage()
            {
                _sessionId = null; _duration = 0;
            }
            
            public DateTime _startTime;
            public DateTime? _stopTime;
            public DateTime _preStartTime;
            public string _sessionId;
            public long _duration;
        }
        private SessionStorage _sessionStorage = new SessionStorage();
   
        //application id
        private string _appid;
        
        private string _sessionStorageFilePath;
        
        #region public
        public AmazonMobileAnalyticsSession(string appId)
        {
            if(string.IsNullOrEmpty(appId))
                throw new ArgumentNullException("appId");

            _appid = appId;
            _sessionStorageFilePath = AmazonHookedPlatformInfo.Instance.PersistentDataPath + "/"+_appid +"_session_storage.json";
        }
        
        
        
        /// <summary>
        /// Start this session.
        /// </summary>
        internal void Start()
        {
            // read session info from persistent storage, in case app is killed
            RetrieveSessionStorage();
            
            // if session storage is valid, restore session and resume session
            if(_sessionStorage != null && !string.IsNullOrEmpty(_sessionStorage._sessionId))
            {
                _startTime = _sessionStorage._startTime;
                _stopTime = _sessionStorage._stopTime;
                _sessionId = _sessionStorage._sessionId;
                _duration = _sessionStorage._duration;
                
                Resume();
            }
            else
            {
                NewSession();
            }
            
        }
        
        /// <summary>
        /// Pause this session.
        /// </summary>
        public void Pause()
        {
            PauseSession();
            SaveSessionStorage();
        }
        
        /// <summary>
        /// Resume this session.
        /// </summary>
        public void Resume()
        {
            if(_stopTime == null)
            {
                //this may sometimes be a valid scenario e.g when the applciation starts
                AmazonLogging.LogError(TAG, "call Resume() without calling Pause() first");
                return;
            }
            
            DateTime currentTime = DateTime.UtcNow;
            
            if(_stopTime.Value < currentTime)
            {
                
                long resumeTimeStamp =  Convert.ToInt64((currentTime - AWSSDKUtils.EPOCH_START).TotalSeconds) ;
                long stopTimeStamp =  Convert.ToInt64((_stopTime.Value - AWSSDKUtils.EPOCH_START).TotalSeconds);
                
                // new session 
                if(resumeTimeStamp - stopTimeStamp > AmazonMobileAnalyticsManager.Config.SESSION_DELTA)
                {
                    StopSession();
                    NewSession();
                    
                }
                // resume old session
                else
                {
                    ResumeSession();
                }
            
            }
            else
            {
                AmazonLogging.LogError(TAG, "session stop time is earlier than start time !");
            }

        }

        /// <summary>
        /// Gets the session info.
        /// </summary>
        /// <param name="startTimestamp">Start timestamp.</param>
        /// <param name="stopTimestamp">Stop timestamp.</param>
        /// <param name="sessionId">Session identifier.</param>
        /// <param name="duration">Duration.</param>
        public void GetSessionInfo(out string startTimestamp, out string stopTimestamp, out string sessionId, out long duration)
        {
            if(string.IsNullOrEmpty(_sessionId))
            {
                AmazonLogging.LogError(TAG,"session id is empty");
                NewSession();
            }
            
            lock(_lock)
            {
                startTimestamp = _startTime.ToString(AWSSDKUtils.ISO8601DateFormatNoMS);
                if(_stopTime != null)
                {
                    stopTimestamp = ((DateTime)_stopTime).ToString(AWSSDKUtils.ISO8601DateFormatNoMS);
                }
                else
                    stopTimestamp = null;
                sessionId = string.Copy(_sessionId);
                duration = _duration;
            }
        }
        #endregion
        
        
        #region private
        private void NewSession()
        {
            lock(_lock)
            {
                _startTime = DateTime.UtcNow;
                _preStartTime = DateTime.UtcNow;
                _stopTime = null;
                _sessionId = Guid.NewGuid().ToString();
                _duration = 0;
            }
            
            AmazonMobileAnalyticsEvent theEvent = new  AmazonMobileAnalyticsEvent(SESSION_START_EVENT_TYPE);
            AmazonMobileAnalyticsManager.GetInstance(_appid).RecordEvent(theEvent);
        }
        
        private void StopSession()
        {
            DateTime currentTime = DateTime.UtcNow;
            
            // update session info
            lock(_lock)
            {
                _stopTime = currentTime;
            }

            
            // record session stop event
            AmazonMobileAnalyticsEvent managerEvent = new  AmazonMobileAnalyticsEvent(SESSION_STOP_EVENT_TYPE);
            lock(_lock)
            {
                if(_stopTime != null)
                    managerEvent.StopTimestamp = ((DateTime)_stopTime).ToString(AWSSDKUtils.ISO8601DateFormatNoMS);
                
                managerEvent.Duration = _duration;
            }
            AmazonMobileAnalyticsManager.GetInstance(_appid).RecordEvent(managerEvent);
        }
        
        private void PauseSession()
        {
            DateTime currentTime = DateTime.UtcNow;
           
            // update session info
            lock(_lock)
            {
                _stopTime = currentTime;
                _duration += Convert.ToInt64((currentTime-_preStartTime).TotalMilliseconds);
            }
            
            // record session pause event
            AmazonMobileAnalyticsEvent managerEvent = new  AmazonMobileAnalyticsEvent(SESSION_PAUSE_EVENT_TYPE);
            lock(_lock)
            {
                if(_stopTime != null)
                    managerEvent.StopTimestamp = ((DateTime)_stopTime).ToString(AWSSDKUtils.ISO8601DateFormatNoMS);
                    
                managerEvent.Duration = _duration;
            }
            AmazonMobileAnalyticsManager.GetInstance(_appid).RecordEvent(managerEvent);
        }
        
        private void ResumeSession()
        {
            DateTime currentTime = DateTime.UtcNow;
            
            // update session info
            lock(_lock)
            {
                _preStartTime = currentTime;
            }
            
            // record session resume event
            AmazonMobileAnalyticsEvent managerEvent = new  AmazonMobileAnalyticsEvent(SESSION_RESUME_EVENT_TYPE);
            lock(_lock)
            {
                if(_stopTime != null)
                    managerEvent.StopTimestamp = ((DateTime)_stopTime).ToString(AWSSDKUtils.ISO8601DateFormatNoMS);
                    
                managerEvent.Duration = _duration;
            }
            AmazonMobileAnalyticsManager.GetInstance(_appid).RecordEvent(managerEvent);
        }
        
        private void SaveSessionStorage()
        {
            if(! AmazonMainThreadDispatcher.IsMainThread)
            {
                throw new Exception("You must call SaveSessionStorage() from main thread. ");
            }
            
            lock(_lock)
            {
                _sessionStorage._startTime = _startTime;
                _sessionStorage._stopTime = _stopTime;
                _sessionStorage._preStartTime = _preStartTime;
                _sessionStorage._sessionId = _sessionId;
                _sessionStorage._duration = _duration;
            }
            
            // store session into file
            AmazonLogging.LogDebug(TAG, "Store session info: " + JsonMapper.ToJson(_sessionStorage));
            
            // create a file to store session info
            if (!File.Exists(_sessionStorageFilePath))
            {
                FileStream fs = File.Create(_sessionStorageFilePath);
                fs.Close();
                
                File.WriteAllText(_sessionStorageFilePath,JsonMapper.ToJson(_sessionStorage));
            }
            else
            {
                File.WriteAllText(_sessionStorageFilePath,String.Empty);
                File.WriteAllText(_sessionStorageFilePath,JsonMapper.ToJson(_sessionStorage));
            }
        }
        
        private void RetrieveSessionStorage()
        {
            if(! AmazonMainThreadDispatcher.IsMainThread)
            {
                throw new Exception("You must call RetrieveSessionStorage() from main thread. ");
            }
            
            string sessionString = null;
            if (File.Exists(_sessionStorageFilePath))
            {
                System.IO.StreamReader sessionFile = new System.IO.StreamReader(_sessionStorageFilePath);
                sessionString = sessionFile.ReadToEnd();
                sessionFile.Close();
                AmazonLogging.LogDebug(TAG, "Retrieve session info: " + sessionString);
            }
            else
            {
                AmazonLogging.LogDebug(TAG, "session file not exist");
            }
            
            if(!string.IsNullOrEmpty(sessionString))
                _sessionStorage = JsonMapper.ToObject<SessionStorage>(sessionString);
        }
        
        #endregion
    }
}
