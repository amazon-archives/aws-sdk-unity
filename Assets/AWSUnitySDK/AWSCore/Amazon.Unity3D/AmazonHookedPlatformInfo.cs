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
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using Amazon.Unity3D;

namespace Amazon.Unity3D
{
    
    /// <summary>
    /// This class can access hooked platform (iOS, Android etc.) information.
    /// For example, locale, make, application version and title.
    /// </summary>
    internal class AmazonHookedPlatformInfo
    {
        private const string IPHONE_OS = "iPhone OS";
        private const string ANDROID_OS = "Android";
        
        private static AmazonHookedPlatformInfo instance = null;
        
#region device related information
        private string device_platform;
        private string device_model;
        private string device_make;
        private string device_platformVersion;
        private string device_locale;
#endregion

#region application related information
        private string app_version_name;
        private string app_version_code;
        private string app_package_name;
        private string app_title;
#endregion

#region external plugins
#if UNITY_IOS 
        [DllImport("__Internal")]
        extern static public string locale();
        
        [DllImport("__Internal")]
        extern static public string title();
        
        [DllImport("__Internal")]
        extern static public string packageName();
        
        [DllImport("__Internal")]
        extern static public string versionCode();
        
        [DllImport("__Internal")]
        extern static public string versionName();

#endif
#endregion
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Amazon.Unity3D3D.AmazonHookedPlatformInfo"/> class.
        /// Provides a way of spoofing thevalues purely for internal testing purposes.
        /// </summary>
        private AmazonHookedPlatformInfo() {}
        
        
#region device information
        public string Platform
        {
            get
            {
                return device_platform;
            }
            internal set
            {
                //Mobile Analytics Service accepts only values iPhoneOS,Android
                string platform = value;
                if(platform.Equals(RuntimePlatform.IPhonePlayer.ToString(),System.StringComparison.OrdinalIgnoreCase)
                    || platform.Contains("iPhoneOS") || platform.Contains("iPhone"))
                {
                    this.device_platform = IPHONE_OS;
                }
                else if(platform.Equals(RuntimePlatform.Android.ToString(),System.StringComparison.OrdinalIgnoreCase)
                    || platform.Contains("Android") || platform.Contains("android"))
                
                {
                    this.device_platform = ANDROID_OS;
                }else
                {
                    this.device_platform = platform;
                }
            }
        }
        
        public string Model
        {
            get
            {
                return device_model;
            }
            internal set
            {
                this.device_model = value;
            }
        }
        
        public string Make
        {
            get
            {
                return device_make;
            }
            internal set
            {
                this.device_make = value;
            }
        }
        
        /// <summary>
        /// Gets the platform version.
        /// </summary>
        /// <value>The platform version. Returns values like iPhone OS 6.1, API-17 etc.</value>
        public string PlatformVersion
        {
            get
            {
                return this.device_platformVersion;
            }
            internal set
            {
#if UNITY_IOS
                string versionString = value.Replace("iPhone OS ", "");
                this.device_platformVersion = versionString;
#else
                this.device_platformVersion=value;
#endif
            }
        }
        
        
        public string PersistentDataPath {get;set;}
        
        public string Locale
        {
            get
            {
                return device_locale;
            }
            set
            {
                
                this.device_locale = value;
            }
        }
        
        public static AmazonHookedPlatformInfo Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AmazonHookedPlatformInfo();
                    instance.Init();
                }
                return instance;
            }
        }
        
#endregion
        
#region application region
        public string PackageName
        {
            get
            {
                return app_package_name;
            }
            internal set
            {
                this.app_package_name = value;
            }
        }
        
        public string VersionName
        {
            get
            {
                return app_version_name;
            }
            internal set
            {
                this.app_version_name = value;
            }
        }
        
        public string VersionCode
        {
            get
            {
                return app_version_code;
            }
            internal set
            {
                this.app_version_code = value;
            }
        }
        
        public string Title
        {
            get
            {
                return app_title;
            }
            internal set
            {
                this.app_title = value;
            }
        }
        
#endregion
        
        
        /// <summary>
        /// Init this instance. This methods needs to be called from the main thread, Otherwise the values may not initialize correctly
        /// </summary>
        public void Init()
        {
            
            PersistentDataPath = Application.persistentDataPath;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            //device related information
            
            AndroidJavaClass buildJavaClass = new AndroidJavaClass("android.os.Build");
            AndroidJavaClass versionJavaClass = new AndroidJavaClass("android.os.Build$VERSION");
            
            PlatformVersion = versionJavaClass.GetStatic<string>("RELEASE");
            Model = buildJavaClass.GetStatic<string>("MODEL");
            Make = buildJavaClass.GetStatic<string>("MANUFACTURER");
            
            AndroidJavaClass localeClass = new AndroidJavaClass("java.util.Locale");
            AndroidJavaObject localeObject = localeClass.CallStatic<AndroidJavaObject>("getDefault");
            Locale = localeObject.Call<string>("toString");
            
            Platform = Application.platform.ToString();
            
            //application related information
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
            AndroidJavaObject currentContext = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            
            PackageName = currentContext.Call<string>("getPackageName");
            
            AndroidJavaObject packageManager = currentContext.Call<AndroidJavaObject>("getPackageManager");
            AndroidJavaObject packageinfo = packageManager.Call<AndroidJavaObject>("getPackageInfo",PackageName,0);
            
            AndroidJavaObject applicationInfo = packageManager.Call<AndroidJavaObject>("getApplicationInfo",PackageName,0);
            
            VersionCode =  System.Convert.ToString(packageinfo.Get<int>("versionCode"));
            VersionName = packageinfo.Get<string>("versionName");
            Title = packageManager.Call<string>("getApplicationLabel",applicationInfo);
            
#elif UNITY_IOS && !UNITY_EDITOR
            //platform related information
            Platform = Application.platform.ToString();
            Locale = locale();
            PlatformVersion = SystemInfo.operatingSystem;
            Make = "apple";
            if(iPhone.generation.ToString().StartsWith("iPhone"))
            {
                Model = "iPhone";
            }
            else if (iPhone.generation.ToString().StartsWith("iPad"))
            {
                Model = "iPad";
            }
            else
            {
                Model = "iPod";
            }
            
            //Application related information
            Title = title();
            VersionCode = versionCode();
            VersionName = versionName();
            PackageName =  packageName();
            
#else
            Platform = Application.platform.ToString();
            if(Thread.CurrentThread.CurrentCulture!=CultureInfo.InvariantCulture){
                Locale = Thread.CurrentThread.CurrentCulture.Name;
            }else{
                Locale = Application.systemLanguage.ToString();
            }
            PlatformVersion = SystemInfo.operatingSystem;
            Model = SystemInfo.deviceModel;
            Make = "";
#endif
            AmazonLogging.LogDebug("PlatformInfo","make = " + Make);
            AmazonLogging.LogDebug("PlatformInfo","model = " + Model);  
            AmazonLogging.LogDebug("PlatformInfo","platform version = " + PlatformVersion);
            AmazonLogging.LogDebug("PlatformInfo","locale = " + Locale);

            AmazonLogging.LogDebug("ApplicationInfo","Title = " + Title);
            AmazonLogging.LogDebug("ApplicationInfo","Version Code = " + VersionCode);
            AmazonLogging.LogDebug("ApplicationInfo","Version Name = " +  VersionName);
            AmazonLogging.LogDebug("ApplicationInfo","Package Name = " + PackageName);

        }
        
    }
}