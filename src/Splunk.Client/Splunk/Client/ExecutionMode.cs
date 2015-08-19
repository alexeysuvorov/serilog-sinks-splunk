﻿/*
 * Copyright 2014 Splunk, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"): you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

//// TODO:
//// [O] Contracts
//// [O] Documentation

namespace Splunk.Client
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Specifies the type of a Splunk search <see cref="Job"/>.
    /// </summary>
    public enum ExecutionMode
    {
        /// <summary>
        /// Specifies an asynchronous <see cref="Job"/>.
        /// </summary> 
        /// <remarks>
        /// A Search ID (SID) is returned as soon as the job starts. In this
        /// case you must poll back for results. This is the default.
        /// </remarks>
        [EnumMember(Value="normal")]
        Normal, 
        
        /// <summary>
        /// Specifies that a Search ID (SID) should be returned when the <see 
        /// cref="Job"/> completes, not before then.
        /// </summary>
        [EnumMember(Value = "blocking")]
        Blocking,

        /// <summary>
        /// Specifies that a Search ID (SID) should be returned when the 
        /// <see cref="Job"/> is complete.
        /// </summary>
        [EnumMember(Value = "oneshot")]
        OneShot
    }
}
