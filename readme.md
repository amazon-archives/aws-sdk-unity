# AWS Mobile SDK for Unity
The [AWS Mobile SDK for Unity](http://aws.amazon.com/mobile/sdk/) contains a set of .NET classes that enables games written with Unity to utilize AWS services. 

## Requirements

* The AWS Mobile SDK for Unity is compatible with Unity 4.0 and onward, and supports both Free and Pro versions.

## Resources
* **[Code Sample](https://github.com/awslabs/aws-sdk-unity-samples)** - Repository of example projects using the SDK.
* **[AWS Mobile Forum](https://forums.aws.amazon.com/forum.jspa?forumID=88)** – Ask questions, get help, and give feedback
* **[Developer Guide](http://docs.aws.amazon.com/mobile/sdkforunity/developerguide/)** - For in-depth getting started and usage information
* **[API Reference](http://docs.aws.amazon.com/AWSUnitySDK/latest/APIReference/)** - For operations, parameters, responses, and examples
* **[AWS Mobile Developer Blog](http://mobile.awsblog.com/)** - For updates and guidance on using the AWS SDK for Android
* **[Release Notes](https://aws.amazon.com/releasenotes/Unity)** - To see the latest features, bug fixes, and changes in the SDK
* **[Issues](https://github.com/aws/aws-sdk-unity/issues)** - Report issues and submit pull requests
* **[@awsformobile](https://twitter.com/awsformobile)** - Follow us on Twitter

## Supported AWS Services
The AWS SDK for Unity supports the following AWS services:

* [Amazon Cognito](http://aws.amazon.com/cognito/)
* [Amazon DynamoDB](http://aws.amazon.com/dynamodb/)
* [Amazon Mobile Analytics](http://aws.amazon.com/mobileanalytics/)
* [Amazon SNS](http://aws.amazon.com/sns/)
* [Amazon S3](http://aws.amazon.com/s3/)


## SDK Fundametals
There are only a few fundamentals that are helpful to know when developing against the AWS SDK for Unity
* Logging in SDK is enabled by default. To disable logging for the sdk open ``Assets\AWSSDK\src\Core\Resources\awsconfig.xml``, and delete the logging section. Alternatively you can also change the LogTo Attribute to "None".To enable logging again add the following section to the awsconfig.xml

```
        <logging
            logTo="UnityLogger"
            logResponses="Always"
            logMetrics="true"
            logMetricsFormat="JSON" />
```

* Use Unity patch 4.6.3P3 or later, for compiling applications to iOS 64 Bit Devices.
* You must have AWSPrefab on the first scene where you instantiate AWS services.
* Never embed credentrials in an application.  It is trivially easy to decompile applications and steal embedded credentials.  Always use temporarily vended credentials from services such as [Amazon Cognito Identity](http://docs.aws.amazon.com/mobile/sdkforunity/developerguide/cognito-identity.html).
* Calls are always asynchronous unlesss explicitly stated. In some cases there may be internal Sync API's, but it is highly discouraged to use them as it may block the game thread.THe Asynchronous Responses are always returned on main thread unless specified in AsyncOptions parameter.

**Note:**
 * For a complete summary of improvements since the Developer Preview, please refer to our blog post [here](http://mobile.awsblog.com/post/Tx30Z7HPU42S0IN/Improvements-in-the-AWS-Mobile-SDK-for-Unity).
 * Support for iOS9 - Please refer to our blogpost [here](https://mobile.awsblog.com/post/Tx2QM69ZE6BGTYX/Preparing-Your-Apps-for-iOS-9) if you are planning to compile your apps with XCode 7
