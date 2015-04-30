//
// Copyright 2014-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
//
//
// Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
// You may not use this file except in compliance with the License.
// A copy of the License is located in the "license" file accompanying this file.
// See the License for the specific language governing permissions and limitations under the License.
//
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Amazon.Runtime;

namespace Amazon.Runtime.Internal.Util
{
    public abstract class DecryptionWrapper : IDecryptionWrapper
    {
        private SymmetricAlgorithm algorithm;
        private ICryptoTransform decryptor;
        private const int encryptionKeySize = 256;

        protected DecryptionWrapper()
        {
            algorithm = CreateAlgorithm();
        }

        #region IDecryptionWrapper Members

        protected abstract SymmetricAlgorithm CreateAlgorithm();
        
        public ICryptoTransform Transformer
        {
            get { return this.decryptor; }
        }

        public void SetDecryptionData(byte[] key, byte[] IV)
        {
            algorithm.KeySize = encryptionKeySize;
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.Mode = CipherMode.CBC;
            algorithm.Key = key;
            algorithm.IV = IV;
        }

        public void CreateDecryptor()
        {
            decryptor = algorithm.CreateDecryptor();
        }
        #endregion
    }

    public class DecryptionWrapperAES : DecryptionWrapper
    {
        public DecryptionWrapperAES()
            : base()
        { }

        protected override SymmetricAlgorithm CreateAlgorithm()
        {
            return AesManaged.Create();
        }
    }
}
