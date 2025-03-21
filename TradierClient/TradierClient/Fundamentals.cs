using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Fundamentals;
using Tradier.Client.Models.Dividends;



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
        /// Retrieves a list of dividend data for the provided symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated string of symbols for which dividend data should be retrieved.</param>
        /// <returns>
        /// A list of dividend data for the provided symbols.
        /// </returns>
        public async Task<List<Dividends>> GetDividend(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetDividend(listSymbols);
        }

        /// <summary>
        /// Retrieves dividend data for a list of symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of symbols.</param>
        /// <returns>A task representing the asynchronous operation that returns a list of dividend data.</returns>
        public async Task<List<Dividends>> GetDividend(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/dividends?symbols={strSymbols}");

            return JsonSerializer.Deserialize<List<Dividends>>(response);
        }
    }
}