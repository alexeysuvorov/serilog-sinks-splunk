﻿// Copyright 2014 Serilog Contributors
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.Splunk;
using Splunk.Client;

namespace Serilog
{
    /// <summary>
    /// Adds the WriteTo.SplunkViaHttp() extension method to <see cref="LoggerConfiguration"/>.
    /// </summary>
    public static class LoggerConfigurationSplunkExtensions
    {
        /// <summary>
        /// Adds a sink that writes log events as to a Splunk instance via http.
        /// </summary>
        /// <param name="loggerConfiguration">The logger configuration.</param>
        /// <param name="context">The Splunk context to log to</param>
        /// <param name="batchSizeLimit">The size of the batch prior to logging</param>
        /// <param name="batchInterval">The interval on which to log via http</param>
        /// <param name="restrictedToMinimumLevel">The minimum log event level required in order to write an event to the sink.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="renderTemplate">If true, the message template will be rendered</param>
        /// <returns>Logger configuration, allowing configuration to continue.</returns>
        /// <exception cref="ArgumentNullException">A required parameter is null.</exception>
        /// <remarks>TODO: Add link to splunk configuration and wiki</remarks>
        public static LoggerConfiguration SplunkViaHttp(
            this LoggerSinkConfiguration loggerConfiguration,
            SplunkContext context,
            int batchSizeLimit,
            TimeSpan batchInterval,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Debug,
            IFormatProvider formatProvider = null,
            bool renderTemplate = true)
        {
            var sink = new SplunkViaHttpSink(context, batchSizeLimit, batchInterval, formatProvider, renderTemplate);

            return loggerConfiguration.Sink(sink);
        }

        /// <summary>
        /// Adds a sink that writes log events as to a Splunk instance via http.
        /// </summary>
        /// <param name="loggerConfiguration">The logger configuration.</param>
        /// <param name="context">The Splunk context to log to</param>
        /// <param name="password"></param>
        /// <param name="resourceNameSpace"></param>
        /// <param name="transmitterArgs"></param>
        /// <param name="batchSizeLimit">The size of the batch prior to logging</param>
        /// <param name="batchInterval">The interval on which to log via http</param>
        /// <param name="restrictedToMinimumLevel">The minimum log event level required in order to write an event to the sink.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="index"></param>
        /// <param name="userName"></param>
        /// <param name="renderTemplate">If true, the message template will be rendered</param>
        /// <returns>Logger configuration, allowing configuration to continue.</returns>
        /// <exception cref="ArgumentNullException">A required parameter is null.</exception>
        /// <remarks>TODO: Add link to splunk configuration and wiki</remarks>
        public static LoggerConfiguration SplunkViaHttp(
            this LoggerSinkConfiguration loggerConfiguration,
            Context context,
            string index,
            string userName,
            string password,
            Namespace resourceNameSpace,
            TransmitterArgs transmitterArgs,
            int batchSizeLimit,
            TimeSpan batchInterval,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Debug,
            IFormatProvider formatProvider = null,
            bool renderTemplate = true)
        {
            var sink = new SplunkViaHttpSink(new SplunkContext(context, index, userName, password, resourceNameSpace, transmitterArgs), batchSizeLimit, batchInterval, formatProvider,renderTemplate);

            return loggerConfiguration.Sink(sink);
        }
    }
}