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
    ///     Represents a class for retrieving company information using fundamental data.
    /// </summary>
    public class Fundamentals
    {
        /// <summary>
        ///     Private readonly field for handling requests.
        /// </summary>
        /// <remarks>
        ///     This field is used to manage and handle requests in the system.
        ///     It holds an instance of the <see cref="Requests" /> class.
        /// </remarks>
        private readonly Requests _requests;

        /// <summary>
        ///     Initializes a new instance of the Fundamentals class with the specified Requests object.
        /// </summary>
        /// <param name="requests">The Requests object to be used for making requests.</param>
        public Fundamentals(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        ///     Retrieves company information for a given list of symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation. The task result contains a list of
        ///     <see cref="CompanyInfo" />.
        /// </returns>
        public async Task<List<CompanyInfo>> GetCompanyInformation(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCompanyInformation(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the information of the companies.</returns>
        public async Task<List<CompanyInfo>> GetCompanyInformation(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/company?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves the calendars of multiple companies based on the provided symbols.
        /// </summary>
        /// <param name="symbols">The symbols of the companies.</param>
        /// <returns>A list of CompanyInfo objects representing the calendars of the companies.</returns>
        public async Task<List<CompanyInfo>> GetCompanyCalendars(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCompanyCalendars(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the information of the companies.</returns>
        public async Task<List<CompanyInfo>> GetCompanyCalendars(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/calendars?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves the dividends for a list of symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated string of symbols.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of CompanyInfo objects.</returns>
        public async Task<List<CompanyInfo>> GetDividends(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetDividends(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the information of the companies.</returns>
        public async Task<List<CompanyInfo>> GetDividends(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/dividends?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves corporate actions for multiple companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A string containing comma-separated symbols of companies.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation. The task result contains a list of CompanyInfo objects
        ///     representing the corporate actions for the given companies.
        /// </returns>
        public async Task<List<CompanyInfo>> GetCorporateActions(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCorporateActions(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the information of the companies.</returns>
        public async Task<List<CompanyInfo>> GetCorporateActions(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response =
                await _requests.GetRequest($"/beta/markets/fundamentals/corporate_actions?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves the ratios for a given list of company symbols.
        /// </summary>
        /// <param name="symbols">The company symbols as a comma-separated string.</param>
        /// <returns>A list of CompanyInfo objects representing the ratios for each company.</returns>
        public async Task<List<CompanyInfo>> GetRatios(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetRatios(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>
        ///     A list of CompanyInfo objects containing the information of the companies.
        /// </returns>
        public async Task<List<CompanyInfo>> GetRatios(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/ratios?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves financial information for a list of company symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated string of company symbols</param>
        /// <returns>
        ///     A task containing a list of company information.
        ///     The company information includes details such as company name, industry, financial metrics, etc.
        /// </returns>
        public async Task<List<CompanyInfo>> GetFinancials(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetFinancials(listSymbols);
        }

        /// <summary>
        ///     Retrieves the information of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the information of the companies.</returns>
        public async Task<List<CompanyInfo>> GetFinancials(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/financials?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }

        /// <summary>
        ///     Retrieves the price statistics for a list of company symbols.
        /// </summary>
        /// <param name="symbols">A string containing the symbols of the companies, separated by commas.</param>
        /// <returns>A list of CompanyInfo objects representing the price statistics for each company.</returns>
        public async Task<List<CompanyInfo>> GetPriceStatistics(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetPriceStatistics(listSymbols);
        }

        /// <summary>
        ///     Retrieves the price statistics of companies based on the given list of symbols.
        /// </summary>
        /// <param name="symbols">A list of symbols representing the companies.</param>
        /// <returns>A list of CompanyInfo objects containing the price statistics of the companies.</returns>
        public async Task<List<CompanyInfo>> GetPriceStatistics(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/statistics?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }
    }
}