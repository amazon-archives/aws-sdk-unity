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
 * Do not modify this file. This file is generated from the kinesis-2013-12-02.normal.json service model.
 */


using System;
using System.Collections.Generic;

using Amazon.Kinesis.Model;
using Amazon.Kinesis.Model.Internal.MarshallTransformations;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.Kinesis
{
    /// <summary>
    /// Implementation for accessing Kinesis
    ///
    /// Amazon Kinesis Service API Reference 
    /// <para>
    /// Amazon Kinesis is a managed service that scales elastically for real time processing
    /// of streaming big data.
    /// </para>
    /// </summary>
    public partial class AmazonKinesisClient : AmazonUnityServiceClient, IAmazonKinesis
    {
        #region Constructors

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Credentials
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        public AmazonKinesisClient(AWSCredentials credentials)
            : this(credentials, new AmazonKinesisConfig())
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Credentials
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="region">The region to connect.</param>
        public AmazonKinesisClient(AWSCredentials credentials, RegionEndpoint region)
            : this(credentials, new AmazonKinesisConfig{RegionEndpoint = region})
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Credentials and an
        /// AmazonKinesisClient Configuration object.
        /// </summary>
        /// <param name="credentials">AWS Credentials</param>
        /// <param name="clientConfig">The AmazonKinesisClient Configuration Object</param>
        public AmazonKinesisClient(AWSCredentials credentials, AmazonKinesisConfig clientConfig)
            : base(credentials, clientConfig)
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonKinesisConfig())
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="region">The region to connect.</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonKinesisConfig() {RegionEndpoint=region})
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID, AWS Secret Key and an
        /// AmazonKinesisClient Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="clientConfig">The AmazonKinesisClient Configuration Object</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, AmazonKinesisConfig clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, clientConfig)
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonKinesisConfig())
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="region">The region to connect.</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
            : this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonKinesisConfig{RegionEndpoint = region})
        {
        }

        /// <summary>
        /// Constructs AmazonKinesisClient with AWS Access Key ID, AWS Secret Key and an
        /// AmazonKinesisClient Configuration object. 
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="awsSessionToken">AWS Session Token</param>
        /// <param name="clientConfig">The AmazonKinesisClient Configuration Object</param>
        public AmazonKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonKinesisConfig clientConfig)
            : base(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, clientConfig)
        {
        }

        #endregion

        #region Overrides

        protected override AbstractAWSSigner CreateSigner()
        {
            return new AWS4Signer();
        }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
        {
            pipeline.ReplaceHandler<Amazon.Runtime.Internal.ErrorHandler>(new Amazon.Runtime.Internal.ErrorHandler<AmazonKinesisException>(this.Logger));
        }    

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        
        #region  AddTagsToStream

        /// <summary>
        /// Initiates the asynchronous execution of the AddTagsToStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the AddTagsToStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void AddTagsToStreamAsync(AddTagsToStreamRequest request, AmazonServiceCallback<AddTagsToStreamRequest, AddTagsToStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new AddTagsToStreamRequestMarshaller();
            var unmarshaller = AddTagsToStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<AddTagsToStreamRequest,AddTagsToStreamResponse> responseObject 
                            = new AmazonServiceResult<AddTagsToStreamRequest,AddTagsToStreamResponse>((AddTagsToStreamRequest)req, (AddTagsToStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<AddTagsToStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  CreateStream

        /// <summary>
        /// Initiates the asynchronous execution of the CreateStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the CreateStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void CreateStreamAsync(CreateStreamRequest request, AmazonServiceCallback<CreateStreamRequest, CreateStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new CreateStreamRequestMarshaller();
            var unmarshaller = CreateStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<CreateStreamRequest,CreateStreamResponse> responseObject 
                            = new AmazonServiceResult<CreateStreamRequest,CreateStreamResponse>((CreateStreamRequest)req, (CreateStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<CreateStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  DeleteStream

        /// <summary>
        /// Initiates the asynchronous execution of the DeleteStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeleteStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void DeleteStreamAsync(DeleteStreamRequest request, AmazonServiceCallback<DeleteStreamRequest, DeleteStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new DeleteStreamRequestMarshaller();
            var unmarshaller = DeleteStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<DeleteStreamRequest,DeleteStreamResponse> responseObject 
                            = new AmazonServiceResult<DeleteStreamRequest,DeleteStreamResponse>((DeleteStreamRequest)req, (DeleteStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<DeleteStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  DescribeStream

        /// <summary>
        /// Initiates the asynchronous execution of the DescribeStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DescribeStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void DescribeStreamAsync(DescribeStreamRequest request, AmazonServiceCallback<DescribeStreamRequest, DescribeStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new DescribeStreamRequestMarshaller();
            var unmarshaller = DescribeStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<DescribeStreamRequest,DescribeStreamResponse> responseObject 
                            = new AmazonServiceResult<DescribeStreamRequest,DescribeStreamResponse>((DescribeStreamRequest)req, (DescribeStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<DescribeStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  GetRecords

        /// <summary>
        /// Initiates the asynchronous execution of the GetRecords operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetRecords operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void GetRecordsAsync(GetRecordsRequest request, AmazonServiceCallback<GetRecordsRequest, GetRecordsResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new GetRecordsRequestMarshaller();
            var unmarshaller = GetRecordsResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<GetRecordsRequest,GetRecordsResponse> responseObject 
                            = new AmazonServiceResult<GetRecordsRequest,GetRecordsResponse>((GetRecordsRequest)req, (GetRecordsResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<GetRecordsRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  GetShardIterator

        /// <summary>
        /// Initiates the asynchronous execution of the GetShardIterator operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the GetShardIterator operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void GetShardIteratorAsync(GetShardIteratorRequest request, AmazonServiceCallback<GetShardIteratorRequest, GetShardIteratorResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new GetShardIteratorRequestMarshaller();
            var unmarshaller = GetShardIteratorResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<GetShardIteratorRequest,GetShardIteratorResponse> responseObject 
                            = new AmazonServiceResult<GetShardIteratorRequest,GetShardIteratorResponse>((GetShardIteratorRequest)req, (GetShardIteratorResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<GetShardIteratorRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  ListStreams

        /// <summary>
        /// Lists your streams.
        /// 
        ///  
        /// <para>
        ///  The number of streams may be too large to return from a single call to <code>ListStreams</code>.
        /// You can limit the number of returned streams using the <code>Limit</code> parameter.
        /// If you do not specify a value for the <code>Limit</code> parameter, Amazon Kinesis
        /// uses the default limit, which is currently 10.
        /// </para>
        ///  
        /// <para>
        ///  You can detect if there are more streams available to list by using the <code>HasMoreStreams</code>
        /// flag from the returned output. If there are more streams available, you can request
        /// more streams by using the name of the last stream returned by the <code>ListStreams</code>
        /// request in the <code>ExclusiveStartStreamName</code> parameter in a subsequent request
        /// to <code>ListStreams</code>. The group of stream names returned by the subsequent
        /// request is then added to the list. You can continue this process until all the stream
        /// names have been collected in the list. 
        /// </para>
        ///  
        /// <para>
        /// <a>ListStreams</a> has a limit of 5 transactions per second per account.
        /// </para>
        /// </summary>
         /// <param name="options">
         ///     A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
         ///     procedure using the AsyncState property.
         /// </param>
        /// 
        /// <returns>The response from the ListStreams service method, as returned by Kinesis.</returns>
        /// <exception cref="Amazon.Kinesis.Model.LimitExceededException">
        /// The requested resource exceeds the maximum number allowed, or the number of concurrent
        /// stream requests exceeds the maximum number allowed (5).
        /// </exception>
        public void ListStreamsAsync(AmazonServiceCallback<ListStreamsRequest, ListStreamsResponse> callback, AsyncOptions options = null)
        {
            ListStreamsAsync(new ListStreamsRequest(), callback, options);
        }


        /// <summary>
        /// Initiates the asynchronous execution of the ListStreams operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListStreams operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void ListStreamsAsync(ListStreamsRequest request, AmazonServiceCallback<ListStreamsRequest, ListStreamsResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new ListStreamsRequestMarshaller();
            var unmarshaller = ListStreamsResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<ListStreamsRequest,ListStreamsResponse> responseObject 
                            = new AmazonServiceResult<ListStreamsRequest,ListStreamsResponse>((ListStreamsRequest)req, (ListStreamsResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<ListStreamsRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  ListTagsForStream

        /// <summary>
        /// Initiates the asynchronous execution of the ListTagsForStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListTagsForStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void ListTagsForStreamAsync(ListTagsForStreamRequest request, AmazonServiceCallback<ListTagsForStreamRequest, ListTagsForStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new ListTagsForStreamRequestMarshaller();
            var unmarshaller = ListTagsForStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<ListTagsForStreamRequest,ListTagsForStreamResponse> responseObject 
                            = new AmazonServiceResult<ListTagsForStreamRequest,ListTagsForStreamResponse>((ListTagsForStreamRequest)req, (ListTagsForStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<ListTagsForStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  MergeShards

        /// <summary>
        /// Initiates the asynchronous execution of the MergeShards operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the MergeShards operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void MergeShardsAsync(MergeShardsRequest request, AmazonServiceCallback<MergeShardsRequest, MergeShardsResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new MergeShardsRequestMarshaller();
            var unmarshaller = MergeShardsResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<MergeShardsRequest,MergeShardsResponse> responseObject 
                            = new AmazonServiceResult<MergeShardsRequest,MergeShardsResponse>((MergeShardsRequest)req, (MergeShardsResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<MergeShardsRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  PutRecord

        /// <summary>
        /// Initiates the asynchronous execution of the PutRecord operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the PutRecord operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void PutRecordAsync(PutRecordRequest request, AmazonServiceCallback<PutRecordRequest, PutRecordResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new PutRecordRequestMarshaller();
            var unmarshaller = PutRecordResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<PutRecordRequest,PutRecordResponse> responseObject 
                            = new AmazonServiceResult<PutRecordRequest,PutRecordResponse>((PutRecordRequest)req, (PutRecordResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<PutRecordRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  PutRecords

        /// <summary>
        /// Initiates the asynchronous execution of the PutRecords operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the PutRecords operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void PutRecordsAsync(PutRecordsRequest request, AmazonServiceCallback<PutRecordsRequest, PutRecordsResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new PutRecordsRequestMarshaller();
            var unmarshaller = PutRecordsResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<PutRecordsRequest,PutRecordsResponse> responseObject 
                            = new AmazonServiceResult<PutRecordsRequest,PutRecordsResponse>((PutRecordsRequest)req, (PutRecordsResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<PutRecordsRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  RemoveTagsFromStream

        /// <summary>
        /// Initiates the asynchronous execution of the RemoveTagsFromStream operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the RemoveTagsFromStream operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void RemoveTagsFromStreamAsync(RemoveTagsFromStreamRequest request, AmazonServiceCallback<RemoveTagsFromStreamRequest, RemoveTagsFromStreamResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new RemoveTagsFromStreamRequestMarshaller();
            var unmarshaller = RemoveTagsFromStreamResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<RemoveTagsFromStreamRequest,RemoveTagsFromStreamResponse> responseObject 
                            = new AmazonServiceResult<RemoveTagsFromStreamRequest,RemoveTagsFromStreamResponse>((RemoveTagsFromStreamRequest)req, (RemoveTagsFromStreamResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<RemoveTagsFromStreamRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
        #region  SplitShard

        /// <summary>
        /// Initiates the asynchronous execution of the SplitShard operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the SplitShard operation on AmazonKinesisClient.</param>
        /// <param name="callback">An Action delegate that is invoked when the operation completes.</param>
        /// <param name="options">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        public void SplitShardAsync(SplitShardRequest request, AmazonServiceCallback<SplitShardRequest, SplitShardResponse> callback, AsyncOptions options = null)
        {
            options = options == null?new AsyncOptions():options;
            var marshaller = new SplitShardRequestMarshaller();
            var unmarshaller = SplitShardResponseUnmarshaller.Instance;
            Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
            if(callback !=null )
                callbackHelper = (AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao) => { 
                    AmazonServiceResult<SplitShardRequest,SplitShardResponse> responseObject 
                            = new AmazonServiceResult<SplitShardRequest,SplitShardResponse>((SplitShardRequest)req, (SplitShardResponse)res, ex , ao.State);    
                        callback(responseObject); 
                };
            BeginInvoke<SplitShardRequest>(request, marshaller, unmarshaller, options, callbackHelper);
        }

        #endregion
        
    }
}