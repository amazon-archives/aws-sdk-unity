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

using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace Amazon.S3
{
    /// <summary>
    /// Interface for accessing AmazonS3.
    ///  
    ///  
    /// </summary>
    public partial interface IAmazonS3 : IDisposable
    {
        #region GetObject

//        /// <summary>
//        /// <para>Retrieves objects from Amazon S3.</para>
//        /// </summary>
//        /// 
//        /// <param name="getObjectRequest">Container for the necessary parameters to execute the GetObject service method on AmazonS3.</param>
//        /// 
//        /// <returns>The response from the GetObject service method, as returned by AmazonS3.</returns>
//        /// 
//        GetObjectResponse GetObject(GetObjectRequest getObjectRequest);
//
//        /// <summary>
//        /// Initiates the asynchronous execution of the GetObject operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.GetObject"/>
//        /// </summary>
//        /// 
//        /// <param name="getObjectRequest">Container for the necessary parameters to execute the GetObject operation on AmazonS3.</param>
//        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes.</param>
//        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
//        ///          procedure using the AsyncState property.</param>
//        /// 
//        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndGetObject
//        ///         operation.</returns>
//        IAsyncResult BeginGetObject(GetObjectRequest getObjectRequest, AsyncCallback callback, object state);
//
//        /// <summary>
//        /// Finishes the asynchronous execution of the GetObject operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.GetObject"/>
//        /// </summary>
//        /// 
//        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginGetObject.</param>
//        /// 
//        /// <returns>Returns a GetObjectResult from AmazonS3.</returns>
//        GetObjectResponse EndGetObject(IAsyncResult asyncResult);
        
		void GetObjectAsync(GetObjectRequest	getObjectRequest, AmazonServiceCallback callback, object state);


        #endregion
        
    

        #region ListObjects

//        /// <summary>
//        /// <para>Returns some or all (up to 1000) of the objects in a bucket. You can use the request parameters as selection criteria to return a
//        /// subset of the objects in a bucket.</para>
//        /// </summary>
//        /// 
//        /// <param name="listObjectsRequest">Container for the necessary parameters to execute the ListObjects service method on AmazonS3.</param>
//        /// 
//        /// <returns>The response from the ListObjects service method, as returned by AmazonS3.</returns>
//        /// 
//        ListObjectsResponse ListObjects(ListObjectsRequest listObjectsRequest);
//
//        /// <summary>
//        /// Initiates the asynchronous execution of the ListObjects operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.ListObjects"/>
//        /// </summary>
//        /// 
//        /// <param name="listObjectsRequest">Container for the necessary parameters to execute the ListObjects operation on AmazonS3.</param>
//        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes.</param>
//        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
//        ///          procedure using the AsyncState property.</param>
//        /// 
//        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndListObjects
//        ///         operation.</returns>
//        IAsyncResult BeginListObjects(ListObjectsRequest listObjectsRequest, AsyncCallback callback, object state);
//
//        /// <summary>
//        /// Finishes the asynchronous execution of the ListObjects operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.ListObjects"/>
//        /// </summary>
//        /// 
//        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginListObjects.</param>
//        /// 
//        /// <returns>Returns a ListObjectsResult from AmazonS3.</returns>
//        ListObjectsResponse EndListObjects(IAsyncResult asyncResult);
        

		void ListObjectsAsync(ListObjectsRequest listObjectsRequest, AmazonServiceCallback callback, object state);

        #endregion
        
   
        #region ListBuckets

//        /// <summary>
//        /// <para>Returns a list of all buckets owned by the authenticated sender of the request.</para>
//        /// </summary>
//        /// 
//        /// <param name="listBucketsRequest">Container for the necessary parameters to execute the ListBuckets service method on AmazonS3.</param>
//        /// 
//        /// <returns>The response from the ListBuckets service method, as returned by AmazonS3.</returns>
//        /// 
//        ListBucketsResponse ListBuckets(ListBucketsRequest listBucketsRequest);
//
//        /// <summary>
//        /// Initiates the asynchronous execution of the ListBuckets operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.ListBuckets"/>
//        /// </summary>
//        /// 
//        /// <param name="listBucketsRequest">Container for the necessary parameters to execute the ListBuckets operation on AmazonS3.</param>
//        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes.</param>
//        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
//        ///          procedure using the AsyncState property.</param>
//        /// 
//        /// <returns>An IAsyncResult that can be used to poll or wait for results, or both; this value is also needed when invoking EndListBuckets
//        ///         operation.</returns>
//        IAsyncResult BeginListBuckets(ListBucketsRequest listBucketsRequest, AsyncCallback callback, object state);
//
//        /// <summary>
//        /// Finishes the asynchronous execution of the ListBuckets operation.
//        /// <seealso cref="Amazon.S3.IAmazonS3.ListBuckets"/>
//        /// </summary>
//        /// 
//        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginListBuckets.</param>
//        /// 
//        /// <returns>Returns a ListBucketsResult from AmazonS3.</returns>
//        ListBucketsResponse EndListBuckets(IAsyncResult asyncResult);
//
//        /// <summary>
//        /// <para>Returns a list of all buckets owned by the authenticated sender of the request.</para>
//        /// </summary>
//        /// 
//        /// <returns>The response from the ListBuckets service method, as returned by AmazonS3.</returns>
//        /// 
//        ListBucketsResponse ListBuckets();
        
		//void ListBucketsAync(ListBucketsRequest listBucketsRequest, Action<ListBucketsResponse> callback);
		void ListBucketsAsync(ListBucketsRequest listBucketsRequest, AmazonServiceCallback callback, object state );
        #endregion
        




    }
}
    
