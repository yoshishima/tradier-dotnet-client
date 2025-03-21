using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Fundamentals;



namespace Tradier.Client
{
    /// <summary>
    /// Provides methods for retrieving fundamental information about companies and dividends from Tradier API.
    /// </summary>
    public class Fundamentals
    {
        /// This variable represents an instance of the Requests class used for making HTTP requests.
        /// @var Requests _requests
        /// @memberof Fundamentals
        /// @see https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
        /// /
        private readonly Requests _requests;

        /// <summary>
        /// Represents the Fundamentals endpoint in the Tradier API, which provides access to company information and dividends.
        /// </summary>
        public Fundamentals(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        /// Retrieves company information for a given list of symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of CompanyInfo objects containing the company information.</returns>
        public async Task<List<CompanyInfo>> GetCompanyInformation(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCompanyInformation(listSymbols);
        }

        /// <summary>
        /// Retrieves company information for the given symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of CompanyInfo objects representing the company information.</returns>
        public async Task<List<CompanyInfo>> GetCompanyInformation(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/company?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        /// Retrieves dividend information for the specified symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of dividend data for the provided symbols.</returns>
        public async Task<List<DividendsRootObject>> GetDividends(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetDividends(listSymbols);
        }

        /// <summary>
        /// Retrieves dividend information for the specified symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of dividend data for the provided symbols.</returns>
        public async Task<List<DividendsRootObject>> GetDividends(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/dividends?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<DividendsRootObject>>(response);
        }


        /// <summary>
        /// Retrieves company statistics for the provided symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of company statistics.</returns>
        public async Task<List<StatisticsResult>> GetCompanyStatistics(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCompanyStatistics(listSymbols);
        }

        /// <summary>
        /// Retrieves company statistics for the provided symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of company statistics.</returns>
        public async Task<List<StatisticsResult>> GetCompanyStatistics(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"markets/fundamentals/statistics?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<StatisticsResult>>(response);
        }

        /// <summary>
        /// Retrieves financial statements (income statements, balance sheets, cash flow statements) for the specified symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of financial statement data for the provided symbols.</returns>
        public async Task<List<FinancialsRootObject>> GetFinancials(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetFinancials(listSymbols);
        }

        /// <summary>
        /// Retrieves financial statements (income statements, balance sheets, cash flow statements) for the specified symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of financial statement data for the provided symbols.</returns>
        public async Task<List<FinancialsRootObject>> GetFinancials(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/financials?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<FinancialsRootObject>>(response);
        }

        /// <summary>
        /// Retrieves financial ratios for the specified symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of financial ratio data for the provided symbols.</returns>
        public async Task<List<RatiosRootObject>> GetRatios(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetRatios(listSymbols);
        }

        /// <summary>
        /// Retrieves financial ratios for the specified symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of financial ratio data for the provided symbols.</returns>
        public async Task<List<RatiosRootObject>> GetRatios(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/ratios?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<RatiosRootObject>>(response);
        }

        /// <summary>
        /// Retrieves corporate actions for the specified symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of corporate action data for the provided symbols.</returns>
        public async Task<List<CorporateActionsRootObject>> GetCorporateActions(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCorporateActions(listSymbols);
        }

        /// <summary>
        /// Retrieves corporate actions for the specified symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of corporate action data for the provided symbols.</returns>
        public async Task<List<CorporateActionsRootObject>> GetCorporateActions(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/corporate_actions?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<CorporateActionsRootObject>>(response);
        }

        /// <summary>
        /// Retrieves corporate calendars for the specified symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A list of corporate calendar data for the provided symbols.</returns>
        public async Task<List<CorporateCalendarsRootObject>> GetCorporateCalendars(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCorporateCalendars(listSymbols);
        }

        /// <summary>
        /// Retrieves corporate calendars for the specified symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols.</param>
        /// <returns>A list of corporate calendar data for the provided symbols.</returns>
        public async Task<List<CorporateCalendarsRootObject>> GetCorporateCalendars(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/calendars?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<CorporateCalendarsRootObject>>(response);
        }
    }
}