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
#pragma warning disable 1587
#region Header
///
/// ParserToken.cs
///   Internal representation of the tokens used by the lexer and the parser.
///
/// The authors disclaim copyright to this source code. For more details, see
/// the COPYING file included with this distribution.
///
#endregion


namespace ThirdParty.Json.LitJson
{
    internal enum ParserToken
    {
        // Lexer tokens
        None = System.Char.MaxValue + 1,
        Number,
        True,
        False,
        Null,
        CharSeq,
        // Single char
        Char,

        // Parser Rules
        Text,
        Object,
        ObjectPrime,
        Pair,
        PairRest,
        Array,
        ArrayPrime,
        Value,
        ValueRest,
        String,

        // End of input
        End,

        // The empty rule
        Epsilon
    }
}
