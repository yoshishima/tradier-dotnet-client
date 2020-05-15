﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.MarketData;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    public class MarketData
    {
        private readonly Requests _requests;

        public MarketData(Requests requests)
        {
            _requests = requests;
        }

        public async Task<Options> GetOptionChain(string symbol, string expiration, bool greeks = false)
        {
            var response = await _requests.GetRequest($"markets/options/chains?symbol={symbol}&expiration={expiration}&greeks={greeks}");
            return JsonConvert.DeserializeObject<OptionChainRootobject>(response).Options;
        }

        public async Task<Quotes> GetQuotes(string symbols, bool greeks = false)
        {
            List<string> listSymbols = symbols.Split(',').Select(x=>x.Trim()).ToList();
            return await GetQuotes(listSymbols, greeks);
        }

        public async Task<Quotes> GetQuotes(List<string> symbols, bool greeks = false)
        {
            string strSymbols = String.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"markets/quotes?symbols={strSymbols}&greeks={greeks}");
            return JsonConvert.DeserializeObject<QuoteRootobject>(response).Quotes;
        }

        public async Task<Quotes> PostGetQuotes(string symbols, bool greeks = false)
        {
            List<string> listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await PostGetQuotes(listSymbols, greeks);
        }

        public async Task<Quotes> PostGetQuotes(List<string> symbols, bool greeks = false)
        {
            string strSymbols = String.Join(",", symbols);
            var data = new Dictionary<string, string>
            {
                { "symbols", strSymbols },
                { "greeks", greeks.ToString() },
            };

            var response = await _requests.PostRequest($"markets/quotes", data);
            return JsonConvert.DeserializeObject<QuoteRootobject>(response).Quotes;
        }

        public async Task<Strikes> GetStrikes(string symbol, string expiration, CultureInfo culture = null)
        {
            culture ??= new CultureInfo("en-US");
            DateTime expirationDateTime = DateTime.Parse(expiration, culture);
            return await GetStrikes(symbol, expirationDateTime);
        }

        public async Task<Strikes> GetStrikes(string symbol, DateTime expiration)
        {
            string stringExpiration= expiration.ToString("yyyy-MM-dd");
            var response = await _requests.GetRequest($"markets/options/strikes?symbol={symbol}&expiration={stringExpiration}");
            return JsonConvert.DeserializeObject<StrikeRootobject>(response).Strikes;
        }

    }
}