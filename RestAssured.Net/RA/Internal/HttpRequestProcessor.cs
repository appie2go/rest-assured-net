﻿// <copyright file="HttpRequestProcessor.cs" company="On Test Automation">
// Copyright 2019 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
using System.Net.Http;
using System.Threading.Tasks;
using RestAssuredNet.RA.Exceptions;

namespace RestAssuredNet.RA.Internal
{
    /// <summary>
    /// The <see cref="HttpRequestProcessor"/> class is responsible for sending HTTP requests.
    /// </summary>
    public class HttpRequestProcessor
    {
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Sends an HTTP request message object and returns the response.
        /// </summary>
        /// <param name="request">The HTTP request message object to be sent.</param>
        /// <returns>The HTTP response.</returns>
        /// <exception cref="HttpRequestProcessorException">Thrown whenever the HTTP request fails.</exception>
        public static async Task<VerifiableResponse> Send(HttpRequestMessage request)
        {
            try
            {
                HttpResponseMessage response = await Client.SendAsync(request);
                return new VerifiableResponse(response);
            }
            catch (HttpRequestException hre)
            {
                throw new HttpRequestProcessorException(hre.Message);
            }
        }
    }
}
