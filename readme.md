# AWS Mobile SDK for Unity - Developer Preview
The [AWS Mobile SDK for Unity](http://aws.amazon.com/mobile/sdk/) contains a set of .NET classes that enables games written with Unity to utilize AWS services. Supported AWS services currently include: Amazon Cognito, Amazon S3, Amazon DynamoDB and Amazon Mobile Analytics. The AWS Unity SDK also contains sample code that illustrate how to call AWS services from a Unity Game.

AWS Mobile SDK for Unity is currently in Developer Preview. If you have any questions, issues, or ideas, you can provide us feedback [here](https://github.com/aws/aws-sdk-unity/issues).


## Requirements

* The AWS Mobile SDK for Unity is compatible with Unity 4.0 and onward, and supports both Free and Pro versions.

**Note: Use Unity patch 4.6.3P3 or later, for compiling applications to iOS 64 Bit Devices.**

## Highlights

* **Amazon Mobile Analytics** - Amazon Mobile Analytics is a service that lets you simply and cost effectively collect and analyze your application usage data. In addition to providing usage summary charts that are available for quick reference, Amazon Mobile Analytics enables you to set up automatic export of your data to Amazon S3 for use with other data analytics tools such as Amazon Redshift, Amazon Elastic MapReduce (EMR), Extract, Transform and Load (ETL) software, or your own data warehouse.
* **Amazon Cognito** – Amazon Cognito is a service that makes it easy to save user data, such as app preferences or game state, in the AWS Cloud without writing any backend code or managing any infrastructure. You can save data locally on users’ devices allowing your applications to work even when the devices are offline. You can also synchronize data across a user’s devices so that their app experience will be consistent regardless of the device they use.
* **Amazon DynamoDB** – Amazon DynamoDB is a fast and flexible NoSQL database service for all applications that need consistent, single-digit millisecond latency at any scale. It is a fully managed database and supports both document and key-value data models. Its flexible data model and reliable performance make it a great fit for mobile, web, gaming, ad-tech, IoT, and many other applications.
* **Amazon S3** – Amazon Simple Storage Service (Amazon S3), provides developers with secure, durable, highly-scalable object storage. The AWS Mobile SDK for Unity currently supports the following operations:
  * `PostObject`
  * `GetObject`
  * `ListObjects`
  * `ListBuckets`

## Getting Started

* To get started with the AWS Mobile SDK for Unity, please reference the [AWS Mobile SDK for Unity Developer Guide](http://docs.aws.amazon.com/mobile/sdkforunity/developerguide)

## Samples

### [Cognito Sync Sample](https://github.com/awslabs/aws-sdk-unity-samples)

This sample demonstrates how to securely manage and sync your game data and create unique identities via login providers.

### [DynamoDB Sample](https://github.com/awslabs/aws-sdk-unity-samples)
This sample demonstrates how to create / update / delete / query items using DynamoDB Object Mapper.

### [S3 Sample](https://github.com/awslabs/aws-sdk-unity-samples)

The S3 sample demonstrates the following:

* List all buckets in the AWS account
* List all objects in the specified bucket
* Upload an object into the specified bucket
* Download an object from the specified bucket

### [Mobile Analytics Sample](https://github.com/awslabs/aws-sdk-unity-samples)

The Mobile Analytics sample demonstrates the following:

* How to integrate Mobile Analytics client with your app
* Create and use custom event
* Create and use monetization event
* Record and send events to server