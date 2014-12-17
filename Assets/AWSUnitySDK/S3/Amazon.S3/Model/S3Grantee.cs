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
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace Amazon.S3.Model
{
    /// <summary>Grantee
    /// </summary>
    public class S3Grantee
    {
        
        private string displayName;
        private string emailAddress;
        private string canonicalUser;
        private string uRI;

        /// <summary>
        /// Type of grantee
        ///  
        /// </summary>
        public GranteeType Type
        {
            get 
            {
                if (this.IsSetEmailAddress())
                    return GranteeType.Email;
                if (this.IsSetURI())
                    return GranteeType.Group;
                if (this.IsSetCanonicalUser())
                    return GranteeType.CanonicalUser;

                return null; 
            }
        }

        // Check to see if Type property is set
        internal bool IsSetType()
        {
            return this.Type != null;
        }

        /// <summary>
        /// Screen name of the grantee.
        ///  
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        // Check to see if DisplayName property is set
        internal bool IsSetDisplayName()
        {
            return this.displayName != null;
        }

        /// <summary>
        /// Email address of the grantee.
        ///  
        /// </summary>
        public string EmailAddress
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }

        // Check to see if EmailAddress property is set
        internal bool IsSetEmailAddress()
        {
            return this.emailAddress != null;
        }

        /// <summary>
        /// The canonical user ID of the grantee.
        ///  
        /// </summary>
        public string CanonicalUser
        {
            get { return this.canonicalUser; }
            set { this.canonicalUser = value; }
        }

        // Check to see if ID property is set
        internal bool IsSetCanonicalUser()
        {
            return this.canonicalUser != null;
        }

        /// <summary>
        /// URI of the grantee group.
        ///  
        /// </summary>
        public string URI
        {
            get { return this.uRI; }
            set { this.uRI = value; }
        }

        // Check to see if URI property is set
        internal bool IsSetURI()
        {
            return this.uRI != null;
        }
    }
}
