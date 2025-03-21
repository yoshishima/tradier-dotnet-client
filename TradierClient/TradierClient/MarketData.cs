using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.MarketData;
using Calendar = Tradier.Client.Models.MarketData.Calendar;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    ///     The <c>MarketData</c> class provides methods to retrieve market data from Tradier API.
    /// </summary>
    public class MarketData
    {
        /// <summary>
        ///     Represents an instance of the Requests class.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        ///     Represents market data.
        /// </summary>
        /// <param name="requests">The instance of the Requests class used to make requests for market data.</param>
        public MarketData(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        ///     Get all quotes in an option chain
        /// </summary>
        public async Task<Options> GetOptionChain(string symbol, DateTime expiration, bool greeks = false)
        {
            var stringExpiration = expiration.ToString("yyyy-MM-dd");
            var response =
                await _requests.GetRequest(
                    $"markets/options/chains?symbol={symbol}&expiration={stringExpiration}&greeks={greeks}");
            return JsonSerializer.Deserialize<OptionChainRootobject>(response).Options;
        }

        /// <summary>
        ///     Get all quotes in an option chain.
        /// </summary>
        /// <param name="symbol">The symbol of the option chain.</param>
        /// <param name="expiration">The expiration date of the option chain in a string format.</param>
        /// <param name="greeks">A boolean value indicating whether to include the option greeks.</param>
        /// <param name="culture">
        ///     A CultureInfo object specifying the culture for parsing the expiration date. If null, the "en-US"
        ///     culture will be used.
        /// </param>
        /// <returns>
        ///     A Task object representing the asynchronous operation. The task will resolve to an Options object containing all
        ///     the quotes in the option chain.
        /// </returns>
        public async Task<Options> GetOptionChain(string symbol, string expiration, bool greeks = false,
            CultureInfo culture = null)
        {
            culture ??= new CultureInfo("en-US");
            var expirationDateTime = DateTime.Parse(expiration, culture);
            return await GetOptionChain(symbol, expirationDateTime, greeks);
        }

        /// <summary>
        ///     Retrieves the expiration dates for options related to a specified underlying symbol.
        /// </summary>
        /// <param name="symbol">The symbol of the underlying asset.</param>
        /// <param name="includeAllRoots">Optional. Specifies whether to include all root symbols or not.</param>
        /// <param name="strikes">Optional. Specifies whether to include strikes or not.</param>
        /// <returns>An instance of the Expirations class that contains the expiration dates for the specified options.</returns>
        public async Task<Expirations> GetOptionExpirations(string symbol, bool includeAllRoots = false, bool strikes = false)
        {
            var response = await _requests.GetRequest(
                $"markets/options/expirations?symbol={symbol}&includeAllRoots={includeAllRoots.ToString().ToLower()}&strikes={strikes.ToString().ToLower()}");
            return JsonSerializer.Deserialize<OptionExpirationsRootobject>(response).Expirations;
        }

        /// <summary>
        ///     Get a list of quotes using a keyword lookup on the symbols description.
        /// </summary>
        /// <param name="symbols">A comma-separated string of symbols to lookup.</param>
        /// <param name="greeks">Indicates whether to include Greeks information in the quotes.</param>
        /// <returns>The quotes matching the given symbols.</returns>
        public async Task<Quotes> GetQuotes(string symbols, bool greeks = false)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetQuotes(listSymbols, greeks);
        }

        /// <summary>
        ///     Get a list of quotes for the given symbols.
        /// </summary>
        /// <param name="symbols">The list of symbols to retrieve quotes for.</param>
        /// <param name="greeks">Optional parameter to include Greek values in the quotes.</param>
        /// <returns>The quotes for the given symbols.</returns>
        public async Task<Quotes> GetQuotes(List<string> symbols, bool greeks = false)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"markets/quotes?symbols={strSymbols}&greeks={greeks}");
            return JsonSerializer.Deserialize<QuoteRootobject>(response).Quotes;
        }

        /// <summary>
        /// Get historical pricing for a security.
        /// </summary>
        /// <param name="symbol">The symbol of the security.</param>
        /// <param name="interval">The interval of the quotes (daily, weekly, monthly).</param>
        /// <param name="start">The start date of the historical quotes (yyyy-MM-dd).</param>
        /// <param name="end">The end date of the historical quotes (yyyy-MM-dd).</param>
        /// <param name="sessionFilter">The session filter (optional): 'open', 'all', null (for all sessions).</param>
        /// <param name="culture">The culture info used to parse the date strings (optional, default: en-US).</param>
        /// <returns>
        /// The historical quotes for the specified parameters.
        /// </returns>
        public async Task<HistoricalQuotes> GetHistoricalQuotes(string symbol, string interval, string start,
            string end, string sessionFilter = null, CultureInfo culture = null)
        {
            culture ??= new CultureInfo("en-US");
            var startDateTime = DateTime.Parse(start, culture);
            var endDateTime = DateTime.Parse(end, culture);

            return await GetHistoricalQuotes(symbol, interval, startDateTime, endDateTime, sessionFilter);
        }

        /// <summary>
        /// Get historical pricing for a security
        /// </summary>
        /// <param name="symbol">The symbol of the security</param>
        /// <param name="interval">The interval of pricing data (daily, weekly, monthly)</param>
        /// <param name="start">The start date of the historical data</param>
        /// <param name="end">The end date of the historical data</param>
        /// <param name="sessionFilter">The session filter (optional): 'open', 'all', null (for all sessions)</param>
        /// <returns>The historical quotes for the specified security and time range</returns>
        public async Task<HistoricalQuotes> GetHistoricalQuotes(string symbol, string interval, DateTime start,
            DateTime end, string sessionFilter = null)
        {
            var stringStart = start.ToString("yyyy-MM-dd");
            var stringEnd = end.ToString("yyyy-MM-dd");

            var requestUrl = $"markets/history?symbol={symbol}&interval={interval}&start={stringStart}&end={stringEnd}";

            // Add session filter parameter if provided
            if (!string.IsNullOrEmpty(sessionFilter))
            {
                requestUrl += $"&session_filter={sessionFilter}";
            }

            var response = await _requests.GetRequest(requestUrl);
            return JsonSerializer.Deserialize<HistoricalQuotesRootobject>(response).History;
        }

        /// <summary>
        ///     Get a list of symbols using a keyword lookup on the symbols description using POST request.
        /// </summary>
        /// <param name="symbols">A comma-separated string of symbols.</param>
        /// <param name="greeks">A boolean value indicating whether to include greeks information. Default value is false.</param>
        /// <returns>
        ///     A <see cref="Task" /> representing the asynchronous operation. The task result contains an instance of
        ///     <see cref="Quotes" /> class.
        /// </returns>
        public async Task<Quotes> PostGetQuotes(string symbols, bool greeks = false)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await PostGetQuotes(listSymbols, greeks);
        }

        /// <summary>
        ///     Get a list of symbols using a keyword lookup on the symbols description using POST request
        /// </summary>
        /// <param name="symbols">The list of symbols to search for</param>
        /// <param name="greeks">A flag indicating whether to include Greeks in the response (default value is false)</param>
        /// <returns>The quotes for the specified symbols</returns>
        public async Task<Quotes> PostGetQuotes(List<string> symbols, bool greeks = false)
        {
            var strSymbols = string.Join(",", symbols);
            var data = new Dictionary<string, string>
            {
                { "symbols", strSymbols },
                { "greeks", greeks.ToString() }
            };

            var response = await _requests.PostRequest("markets/quotes", data);
            return JsonSerializer.Deserialize<QuoteRootobject>(response).Quotes;
        }

        /// <summary>
        ///     Get an options strike prices for a specified expiration date
        /// </summary>
        /// <param name="symbol">The symbol of the options</param>
        /// <param name="expiration">The expiration date of the options</param>
        /// <param name="culture">The culture used for parsing the expiration date. Default value is null.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation. The task result contains the strike prices.</returns>
        public async Task<Strikes> GetStrikes(string symbol, string expiration, CultureInfo culture = null)
        {
            culture ??= new CultureInfo("en-US");
            var expirationDateTime = DateTime.Parse(expiration, culture);
            return await GetStrikes(symbol, expirationDateTime);
        }

        /// <summary>
        ///     Get an options strike prices for a specified expiration date
        /// </summary>
        /// <param name="symbol">The symbol of the options</param>
        /// <param name="expiration">The expiration date of the options in DateTime format</param>
        /// <returns>The strike prices of the options for the specified expiration date</returns>
        public async Task<Strikes> GetStrikes(string symbol, DateTime expiration)
        {
            var stringExpiration = expiration.ToString("yyyy-MM-dd");
            var response =
                await _requests.GetRequest($"markets/options/strikes?symbol={symbol}&expiration={stringExpiration}");
            return JsonSerializer.Deserialize<OptionStrikesRootobject>(response).Strikes;
        }

        /// <summary>
        ///     Retrieves the time and sales data for a specific symbol within a given time range.
        /// </summary>
        /// <param name="symbol">The symbol for which to retrieve the time and sales data.</param>
        /// <param name="interval">The interval at which the pricing is captured.</param>
        /// <param name="start">The start time of the time range.</param>
        /// <param name="end">The end time of the time range.</param>
        /// <param name="filter">The filter type for the time and sales data. Default value is "all".</param>
        /// <param name="culture">The culture to be used for datetime parsing. If not specified, "en-US" is used.</param>
        /// <returns>
        ///     A <see cref="Series" /> object containing the time and sales data for the specified symbol within the given time
        ///     range and interval.
        /// </returns>
        public async Task<Series> GetTimeSales(string symbol, string interval, string start, string end,
            string filter = "all", CultureInfo culture = null)
        {
            culture ??= new CultureInfo("en-US");
            var startDateTime = DateTime.Parse(start, culture);
            var endDateTime = DateTime.Parse(end, culture);

            return await GetTimeSales(symbol, interval, startDateTime, endDateTime, filter);
        }

        /// <summary>
        ///     Retrieves the time and sales data for a given symbol within a specified time range.
        /// </summary>
        /// <param name="symbol">The symbol or ticker of the security for which to retrieve the time and sales data.</param>
        /// <param name="interval">
        ///     The interval at which the pricing data should be captured. Examples: "1min", "5min", "15min",
        ///     etc.
        /// </param>
        /// <param name="start">The start date and time of the time range from which to retrieve the data.</param>
        /// <param name="end">The end date and time of the time range from which to retrieve the data.</param>
        /// <param name="filter">
        ///     Optional. The type of session filter to apply. Valid values are "all" (default), "pre", "regular",
        ///     "post".
        /// </param>
        /// <returns>
        ///     A Series object containing the time and sales data captured at the specified intervals.
        /// </returns>
        public async Task<Series> GetTimeSales(string symbol, string interval, DateTime start, DateTime end,
            string filter = "all")
        {
            var stringStart = start.ToString("yyyy-MM-dd HH:mm");
            var stringEnd = end.ToString("yyyy-MM-dd HH:mm");

            var response = await _requests.GetRequest(
                $"markets/timesales?symbol={symbol}&interval={interval}&start={stringStart}&end={stringEnd}&session_filter={filter}");
            return JsonSerializer.Deserialize<TimesalesRootobject>(response).Series;
        }

        /// <summary>
        ///     Retrieves a list of ETB (Easy To Borrow) securities that can be sold short with a Tradier Brokerage account.
        /// </summary>
        /// <returns>
        ///     An instance of the Securities class representing the list of ETB securities.
        /// </returns>
        public async Task<Securities> GetEtbSecurities()
        {
            var response = await _requests.GetRequest("markets/etb");
            return JsonSerializer.Deserialize<SecuritiesRootobject>(response).Securities;
        }

        /// <summary>
        ///     Retrieves the current market clock information.
        /// </summary>
        /// <returns>
        ///     The current market clock information.
        /// </returns>
        public async Task<Clock> GetClock()
        {
            var response = await _requests.GetRequest("markets/clock");
            return JsonSerializer.Deserialize<ClockRootobject>(response).Clock;
        }

        /// <summary>
        ///     Get the market calendar for the current or given month
        /// </summary>
        /// <param name="month">The month for which to retrieve the calendar. If not specified, the current month will be used.</param>
        /// <param name="year">The year for which to retrieve the calendar. If not specified, the current year will be used.</param>
        /// <returns>The market calendar for the specified month and year.</returns>
        public async Task<Calendar> GetCalendar(int? month = null, int? year = null)
        {
            var response = await _requests.GetRequest($"markets/calendar?month={month}&year={year}");
            return JsonSerializer.Deserialize<CalendarRootobject>(response).Calendar;
        }

        /// <summary>
        ///     Searches for companies based on the given query and returns securities.
        /// </summary>
        /// <param name="query">The query string to search for companies.</param>
        /// <param name="indexes">Specifies whether to include index securities in the search. Default is false.</param>
        /// <returns>
        ///     An instance of the Securities class that contains the search result.
        /// </returns>
        public async Task<Securities> SearchCompanies(string query, bool indexes = false)
        {
            var response = await _requests.GetRequest($"markets/search?q={query}&indexes={indexes}");
            return JsonSerializer.Deserialize<SecuritiesRootobject>(response).Securities;
        }

        /// <summary>
        ///     Search for a symbol using the ticker symbol or partial symbol
        /// </summary>
        /// <param name="query">The ticker symbol or partial symbol to search for</param>
        /// <param name="exchanges">(Optional) Comma-separated list of exchanges to filter the search (e.g., NYSE, NASDAQ)</param>
        /// <param name="types">(Optional) Comma-separated list of security types to filter the search (e.g., stock, ETF)</param>
        /// <returns>The securities that match the search query</returns>
        public async Task<Securities> LookupSymbol(string query, string exchanges = null, string types = null)
        {
            var urlBuilder = $"markets/lookup?q={query}";

            if (!string.IsNullOrEmpty(exchanges)) urlBuilder += $"&exchanges={exchanges}";

            if (!string.IsNullOrEmpty(types)) urlBuilder += $"&types={types}";

            var response = await _requests.GetRequest(urlBuilder);
            return JsonSerializer.Deserialize<SecuritiesRootobject>(response).Securities;
        }

        /// <summary>
        ///     Retrieves all option symbols for a given underlying symbol.
        /// </summary>
        /// <param name="symbol">The underlying symbol for which to retrieve option symbols.</param>
        /// <returns>A <see cref="List{Symbol}" /> containing the option symbols.</returns>
        public async Task<List<Symbol>> LookupOptionSymbols(string symbol)
        {
            var response = await _requests.GetRequest($"markets/options/lookup?underlying={symbol}");
            return JsonSerializer.Deserialize<OptionSymbolsRootobject>(response).Symbols;
        }

        /// <summary>
        ///     Retrieves company data for given symbols.
        /// </summary>
        /// <param name="symbols">The symbols of the companies to retrieve the data for.</param>
        /// <returns>A list of CompanyDataRootObject containing the company data.</returns>
        public async Task<List<CompanyDataRootObject>> GetCompany(string symbols)
        {
            var response = await _requests.GetRequest($"/beta/markets/fundamentals/company?symbols={symbols}");
            return JsonSerializer.Deserialize<List<CompanyDataRootObject>>(response);
        }

        /// <summary>
        ///     Retrieves the corporate calendars for the given symbols.
        /// </summary>
        /// <param name="symbols">The symbols for which to retrieve the corporate calendars.</param>
        /// <returns>A list of CorporateCalendarRootObject representing the corporate calendars.</returns>
        public async Task<List<CorporateCalendarRootObject>> GetCorporateCalendars(string symbols)
        {
            var response = await _requests.GetRequest($"/beta/markets/fundamentals/calendars?symbols={symbols}");
            return JsonSerializer.Deserialize<List<CorporateCalendarRootObject>>(response);
        }
    }
}