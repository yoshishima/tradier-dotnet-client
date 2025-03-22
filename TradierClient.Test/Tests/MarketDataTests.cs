using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Tradier.Client;
using TradierClient.Test.Helpers;

namespace TradierClient.Test.Tests
{
    public class MarketDataTests
    {
        private Tradier.Client.TradierClient _client;
        private Settings _settings;

        [SetUp]
        public void Init()
        {
            _settings = Configuration.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
        }

        [SetUp]
        public void Setup()
        {
            // Use SandBox API Token
            var sandboxApiToken = _settings.SandboxApiToken;
            _client = new Tradier.Client.TradierClient(sandboxApiToken);

            //Use Production API Token
            //var apiToken = _settings.ApiToken;
            //_client = new Tradier.Client.TradierClient(apiToken, true);
        }

        [Test]
        [TestCase("CKH", false)]
        public async Task PostGetQuotesForSingleSymbol(string symbols, bool greeks)
        {
            var result = await _client.MarketData.PostGetQuotes(symbols, greeks);
            ClassicAssert.IsNotNull(result.Quote.First());
            ClassicAssert.AreEqual(1, result.Quote.Count);
        }

        [Test]
        [TestCase("GME", "daily")]
        public async Task GetMultiDayHistoricalQuotesTest(string symbol, string interval)
        {
            var start = TimingHelper.GetLastWednesday();
            var end = TimingHelper.GetLastThursday();
            var result = await _client.MarketData.GetHistoricalQuotes(symbol, interval, start, end);
            ClassicAssert.IsNotNull(result.Day);
            ClassicAssert.AreEqual(2, result.Day.Count);

            var firstDay = result.Day.First();
            var secondDay = result.Day.Last();
            ClassicAssert.AreEqual(start.ToString("yyyy-MM-dd"), firstDay.Date);
            ClassicAssert.NotZero(firstDay.Open);
            ClassicAssert.AreEqual(end.ToString("yyyy-MM-dd"), secondDay.Date);
            ClassicAssert.NotZero(secondDay.Open);
        }

        [Test]
        [TestCase("GME", "daily")]
        public async Task GetSingleDayHistoricalQuotesTest(string symbol, string interval)
        {
            var start = TimingHelper.GetLastWednesday();
            var end = TimingHelper.GetLastWednesday();
            var result = await _client.MarketData.GetHistoricalQuotes(symbol, interval, start, end);
            ClassicAssert.IsNotNull(result.Day);
            ClassicAssert.AreEqual(1, result.Day.Count);

            var firstDay = result.Day.First();
            ClassicAssert.AreEqual(start.ToString("yyyy-MM-dd"), firstDay.Date);
            ClassicAssert.NotZero(firstDay.Open);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("AAPL,GOOG")]
        public async Task GetCompanyInfoTest(string symbols)
        {
            var result = await _client.MarketData.GetCompany(symbols);

            var companyData = result.FirstOrDefault().Results.FirstOrDefault(x => x.Tables?.CompanyProfile != null);
            ClassicAssert.IsNotNull(companyData);
            ClassicAssert.IsNotNull(companyData?.Tables?.CompanyProfile?.CompanyId);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("AAPL,GOOG")]
        public async Task GetCorporateCalendarTest(string symbols)
        {
            var result = await _client.MarketData.GetCorporateCalendars(symbols);

            var companyData = result.FirstOrDefault().Results.FirstOrDefault(x => x.Tables?.CorporateCalendars != null);
            ClassicAssert.IsNotNull(companyData);
            ClassicAssert.IsNotNull(companyData?.Tables?.CorporateCalendars?.FirstOrDefault()?.CompanyId);
        }

        [Test]
        public async Task GetEtbSecuritiesTest()
        {
            var result = await _client.MarketData.GetEtbSecurities();
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        [Test]
        [TestCase("Alphabet")]
        public async Task SearchCompaniesTest(string symbol)
        {
            var result = await _client.MarketData.SearchCompanies(symbol);
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        [Test]
        [TestCase("GOOG")]
        public async Task LookupSymbolTest(string query)
        {
            var result = await _client.MarketData.LookupSymbol(query);
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        [Test]
        [TestCase("AAPL")]
        public async Task GetQuotesTest(string symbol)
        {
            var result = await _client.MarketData.GetQuotes(symbol);
            ClassicAssert.IsNotNull(result.Quote.FirstOrDefault());
            ClassicAssert.AreEqual(symbol, result.Quote.First().Symbol);
        }

        [Test]
        [TestCase("AAPL")]
        public async Task GetOptionExpirations(string symbol)
        {
            var result = await _client.MarketData.GetOptionExpirations(symbol);
            ClassicAssert.IsNotNull(result.Date);
            ClassicAssert.Greater(result.Date.Count, 0);
        }

        [Test]
        public async Task GetClockTest()
        {
            var result = await _client.MarketData.GetClock();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.Date);
            ClassicAssert.IsNotNull(result.Description);
            ClassicAssert.IsNotNull(result.State);
        }

        [Test]
        public async Task GetCalendarTest()
        {
            var result = await _client.MarketData.GetCalendar(DateTime.Now.Month, DateTime.Now.Year);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(DateTime.Now.Month, result.Month);
            ClassicAssert.AreEqual(DateTime.Now.Year, result.Year);
            ClassicAssert.IsNotNull(result.Days);
        }

        [Test]
        [TestCase("AAPL")]
        public async Task GetTimeSalesTest(string symbol)
        {
            var start = DateTime.Now.AddDays(-5);
            var end = DateTime.Now;
            var result = await _client.MarketData.GetTimeSales(symbol, "15min", start, end);
            ClassicAssert.IsNotNull(result);
            if (result.Data != null && result.Data.Any())
            {
                ClassicAssert.IsNotNull(result.Data.First().Time);
                ClassicAssert.NotZero(result.Data.First().Price);
            }
        }

        [Test]
        [TestCase("AAPL", "C", "strike")]
        public async Task LookupOptionSymbolsTest(string symbol)
        {
            var result = await _client.MarketData.LookupOptionSymbols(symbol);
            ClassicAssert.IsNotNull(result);
            // This test might need adjustment based on actual API behavior
            // As option symbols availability depends on market conditions
        }

        [Test]
        [TestCase("AAPL")]
        public async Task GetStrikesTest(string symbol)
        {
            // Get the next expiration date first
            var expirations = await _client.MarketData.GetOptionExpirations(symbol);
            if (expirations.Date != null && expirations.Date.Any())
            {
                var expiration = expirations.Date.First();
                var result = await _client.MarketData.GetStrikes(symbol, expiration);
                ClassicAssert.IsNotNull(result);
                ClassicAssert.IsNotNull(result.Strike);
                ClassicAssert.Greater(result.Strike.Count, 0);
            }
            else
            {
                Assert.Inconclusive("No option expirations found for this symbol");
            }
        }

        [Test]
        [TestCase("AAPL")]
        public async Task GetOptionChainTest(string symbol)
        {
            // Get the next expiration date first
            var expirations = await _client.MarketData.GetOptionExpirations(symbol);
            if (expirations.Date != null && expirations.Date.Any())
            {
                var expiration = expirations.Date.First();
                var result = await _client.MarketData.GetOptionChain(symbol, expiration);
                ClassicAssert.IsNotNull(result);
                ClassicAssert.IsNotNull(result.Option);
                if (result.Option.Any())
                {
                    ClassicAssert.AreEqual(symbol, result.Option.First().Underlying);
                }
            }
            else
            {
                Assert.Inconclusive("No option expirations found for this symbol");
            }
        }
    }
}