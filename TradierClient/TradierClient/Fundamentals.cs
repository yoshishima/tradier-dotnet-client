using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Fundamentals;

namespace Tradier.Client
{
    public class Fundamentals
    {
        private readonly Requests _requests;

        public Fundamentals(Requests requests)
        {
            _requests = requests;
        }

        public async Task<List<CompanyInfo>> GetCompanyInformation(string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await GetCompanyInformation(listSymbols);
        }

        public async Task<List<CompanyInfo>> GetCompanyInformation(List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols).Trim();

            var response = await _requests.GetRequest($"/beta/markets/fundamentals/company?symbols={strSymbols}");
            Console.WriteLine(response);

            return JsonSerializer.Deserialize<List<CompanyInfo>>(response);
        }
    }
}