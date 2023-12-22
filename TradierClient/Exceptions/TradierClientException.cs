﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Tradier.Client.Models.Exception;

namespace Tradier.Client.Exceptions
{
    public class TradierClientException : Exception
    {
        public TradierClientException()
        {
        }

        public TradierClientException(string message)
            : base(message)
        {
        }

        public TradierClientException(HttpResponseMessage response)
        {
            var resp = response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(resp.Result))
            {
                if (Equals(response.Content.Headers.ContentType, MediaTypeHeaderValue.Parse("application/json")))
                {
                    var fault = JsonSerializer.Deserialize<FaultRootobject>(resp.Result).Fault;
                    throw new TradierClientException(fault, response);
                }

                throw new TradierClientException(resp.Result);
            }

            // if it's not any of the cases above,
            // just output the http status code exception embedded in EnsureSuccessStatusCode()
            response.EnsureSuccessStatusCode();
        }

        public TradierClientException(Fault fault, HttpResponseMessage response)
        {
            throw new Exception(responseBuilder(response, fault));
        }

        public TradierClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private string responseBuilder(HttpResponseMessage response, Fault fault = null)
        {
            var messageStream = response.Content.ReadAsStreamAsync().Result;
            var messageField = fault != null ? fault.FaultString : messageStream.ToString();
            var messageBuilt = $"IsSuccessStatusCode: {response.IsSuccessStatusCode}\n" +
                               $"Reason: {response.ReasonPhrase}\n" +
                               $"StatusCode: {response.StatusCode.ToString()}\n" +
                               $"Message: {messageField}";

            return messageBuilt;
        }
    }
}