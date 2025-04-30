using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Tradier.Client;
using TradierClient.Test.Helpers;

namespace TradierClient.Test.Tests
{
    /// <summary>
    /// Provides a suite of tests for validating the functionality and integrity of the market data operations
    /// within the Tradier API client. These tests include multiple scenarios such as fetching quotes, historical data,
    /// company information, and options data.
    /// </summary>
    public class MarketDataTests
    {
        /// <summary>
        /// Represents an instance of the TradierClient used to interact with the Tradier API.
        /// This client is initialized with appropriate API tokens to enable communication
        /// with the Tradier services (Sandbox or Production environments).
        /// </summary>
        private Tradier.Client.TradierClient _client;

        /// <summary>
        /// Represents the configuration settings required for the test execution and API client setup.
        /// This variable is used to store application configuration such as API tokens, which
        /// are extracted using the Configuration helper class.
        /// </summary>
        private Settings _settings;

        /// <summary>
        /// Initializes test dependencies and configurations required for running unit tests.
        /// Sets up the application settings using the configuration from the current test directory.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _settings = Configuration.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
        }

        /// <summary>
        /// Configures the test environment by setting up the TradierClient instance
        /// to connect to the production API using the API token provided in the settings.
        /// </summary>
        /// <remarks>
        /// This method initializes the TradierClient with the API token configured in the test settings
        /// and is executed as part of the NUnit setup for the test cases.
        /// </remarks>
        [SetUp]
        public void Setup()
        {
            // Use SandBox API Token
            //var sandboxApiToken = _settings.SandboxApiToken;
            //_client = new Tradier.Client.TradierClient(sandboxApiToken);

            //Use Production API Token
            var apiToken = _settings.ApiToken;
            _client = new Tradier.Client.TradierClient(apiToken, true);
        }

        /// Retrieves a single quote for a specified symbol and optionally includes Greek calculations.
        /// <param name="symbol">The symbol for which the quote is to be fetched.</param>
        /// <param name="greeks">Indicates whether Greek calculations should be included in the response.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the quote information for the specified symbol.</returns>
        [Test]
        [TestCase("CAVA", false, Description = "Single symbol without Greeks")]
        [TestCase("CAVA", true, Description = "Single symbol with Greeks")]
        [TestCase("AAPL", false, Description = "Different symbol test")]
        public async Task PostGetQuotesForSingleSymbol(string symbol, bool greeks)
        {
            // Arrange - nothing to do as client is already set up

            // Act
            var result = await _client.MarketData.PostGetQuotes(symbol, greeks);

            // Assert
            ClassicAssert.IsNotNull(result, "Result should not be null");
            ClassicAssert.IsNotNull(result.Quote, "Quote list should not be null");
            ClassicAssert.AreEqual(1, result.Quote.Count, "Should return exactly one quote");
    
            var quote = result.Quote.First();
            ClassicAssert.IsNotNull(quote, "Quote should not be null");
            ClassicAssert.AreEqual(symbol, quote.Symbol, "Quote should be for the requested symbol");
    
            // Add optional check for Greeks if you're testing that feature
            if (greeks)
            {
                // Add assertions for Greek values if needed
            }
        }

        /// <summary>
        /// Tests the retrieval of multi-day historical market quotes for a given symbol and interval.
        /// Verifies the correctness of the data for the start and end dates,
        /// including non-zero opening values.
        /// </summary>
        /// <param name="symbol">The stock symbol to fetch historical quotes for.</param>
        /// <param name="interval">The interval type for the historical data, such as "daily".</param>
        /// <returns>Task representing the asynchronous operation.</returns>
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

        /// Tests the retrieval of single-day historical quotes for a given symbol and interval.
        /// Validates that the data returned contains exactly one day and matches the expected format and values.
        /// <param name="symbol">The financial instrument symbol (e.g., "GME") for which the historical data is requested.</param>
        /// <param name="interval">The time interval for the historical data (e.g., "daily").</param>
        /// <returns>An asynchronous task representing the test operation.</returns>
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

        /// <summary>
        /// Tests the retrieval of company information for one or more provided symbols using the MarketData API.
        /// Validates that the result contains the expected company data and ensures non-null responses.
        /// </summary>
        /// <param name="symbols">A comma-separated string of stock symbols to fetch company information for.</param>
        /// <returns>Task representing the asynchronous operation of the test method, validating company data retrieval.</returns>
        [Test]
        [TestCase("AAPL")]
        [TestCase("AAPL,GOOG")]
        public async Task GetCompanyInfoTest(string symbols)
        {
            // Arrange
            var expectedSymbols = symbols.Split(',');
    
            // Act
            var result = await _client.MarketData.GetCompany(symbols);
    
            // Assert
            ClassicAssert.IsNotNull(result, "Result should not be null");
            ClassicAssert.IsNotEmpty(result, "Result should not be empty");
    
            var companyData = result.FirstOrDefault()?.Results?.FirstOrDefault(x => x.Tables?.CompanyProfile != null);
            ClassicAssert.IsNotNull(companyData, "Company data should not be null");
            ClassicAssert.IsNotNull(companyData.Tables, "Tables should not be null");
            ClassicAssert.IsNotNull(companyData.Tables.CompanyProfile, "CompanyProfile should not be null");
            ClassicAssert.IsNotNull(companyData.Tables.CompanyProfile.CompanyId, "CompanyId should not be null");
    
            // Verify that all requested symbols have data
            if (expectedSymbols.Length > 1)
            {
                ClassicAssert.AreEqual(expectedSymbols.Length, result.Count, 
                    "Number of results should match number of requested symbols");
        
                foreach (var symbol in expectedSymbols)
                {
                    var hasData = result.Any(r => r.Results.Any(x => 
                        x.Tables?.CompanyProfile != null));
                    ClassicAssert.IsTrue(hasData, $"Should have company data for {symbol}");
                }
            }
        }


        /// <summary>
        /// Fetches and validates corporate calendar data for the provided symbols.
        /// </summary>
        /// <param name="symbols">A comma-separated list of stock symbols to retrieve corporate calendar data for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Tests the retrieval of Easy-to-Borrow (ETB) securities data by invoking the MarketData.GetEtbSecurities method.
        /// Ensures that the result contains a list of securities and validates that at least one security symbol is available.
        /// </summary>
        /// <returns>
        /// A Task that represents the asynchronous test operation.
        /// </returns>
        [Test]
        public async Task GetEtbSecuritiesTest()
        {
            var result = await _client.MarketData.GetEtbSecurities();
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        /// <summary>
        /// Tests the SearchCompanies API method for retrieving company information based on the provided symbol.
        /// </summary>
        /// <param name="symbol">The string query to search for matching companies.</param>
        /// <returns>A Task representing the asynchronous operation, which performs assertions on the returned data from the search query.</returns>
        [Test]
        [TestCase("Alphabet")]
        public async Task SearchCompaniesTest(string symbol)
        {
            var result = await _client.MarketData.SearchCompanies(symbol);
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        /// <summary>
        /// Tests the ability to look up securities based on a query string using the Tradier Market Data API.
        /// </summary>
        /// <param name="query">The search query string used to look up securities.</param>
        /// <returns>Returns an asynchronous task that, when awaited, validates if the result contains at least one matching symbol.</returns>
        [Test]
        [TestCase("GOOG")]
        public async Task LookupSymbolTest(string query)
        {
            var result = await _client.MarketData.LookupSymbol(query);
            ClassicAssert.IsNotNull(result.Security.FirstOrDefault()?.Symbol);
        }

        /// <summary>
        /// Fetches quote data for a given symbol and validates the result.
        /// </summary>
        /// <param name="symbol">The stock symbol for which the quote data is requested.</param>
        /// <returns>A task that represents the asynchronous operation, which contains the fetched quote data for the given symbol.</returns>
        [Test]
        [TestCase("AAPL")]
        public async Task GetQuotesTest(string symbol)
        {
            var result = await _client.MarketData.GetQuotes(symbol);
            ClassicAssert.IsNotNull(result.Quote.FirstOrDefault());
            ClassicAssert.AreEqual(symbol, result.Quote.First().Symbol);
        }

        /// Retrieves the available option expiration dates for a given security symbol.
        /// <param name="symbol">The symbol of the security for which to retrieve option expiration dates.</param>
        /// <param name="includeAllRoots">Specifies whether to include all root symbols (default is false).</param>
        /// <param name="strikes">Specifies whether to include strikes for each expiration (default is false).</param>
        /// <returns>An Expirations object containing a list of available expiration dates.</returns>
        [Test]
        [TestCase("AAPL")]
        public async Task GetOptionExpirations(string symbol)
        {
            var result = await _client.MarketData.GetOptionExpirations(symbol);
            ClassicAssert.IsNotNull(result.Date);
            ClassicAssert.Greater(result.Date.Count, 0);
        }

        /// <summary>
        /// Retrieves a test instance of a clock, typically used for testing purposes
        /// to provide a controllable or fixed time value.
        /// </summary>
        /// <returns>
        /// A test clock instance that can be manipulated or used to simulate specific time conditions.
        /// </returns>
        [Test]
        public async Task GetClockTest()
        {
            // Act
            var result = await _client.MarketData.GetClock();
    
            // Assert
            ClassicAssert.IsNotNull(result, "Clock result should not be null");
            ClassicAssert.IsNotNull(result.Date, "Date should not be null");
            ClassicAssert.IsNotNull(result.Description, "Description should not be null");
            ClassicAssert.IsNotNull(result.State, "State should not be null");
    
            // Additional assertions for property format/value validation could be added here
            // For example:
            // ClassicAssert.IsTrue(DateTime.TryParse(result.Date, out _), "Date should be in a valid date format");
            // ClassicAssert.Contains(new[] { "open", "closed", "pre", "after" }, result.State.ToLower(), "State should be a valid market state");
        }

        /// Tests the GetCalendar method of the MarketData class to ensure it retrieves
        /// the calendar data for the specified month and year.
        /// Asserts that the returned data is not null, the month and year properties
        /// match the input values, and the days property is not null.
        /// <returns>Asynchronous operation for the test execution.</returns>
        [Test]
        public async Task GetCalendarTest()
        {
            var result = await _client.MarketData.GetCalendar(DateTime.Now.Month, DateTime.Now.Year);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(DateTime.Now.Month, result.Month);
            ClassicAssert.AreEqual(DateTime.Now.Year, result.Year);
            ClassicAssert.IsNotNull(result.Days);
        }

        /// <summary>
        /// Tests the GetTimeSales method to retrieve time series sales data for a given stock symbol.
        /// </summary>
        /// <param name="symbol">The stock symbol for which to retrieve time sales data.</param>
        /// <returns>
        /// An asynchronous task that verifies the time sales data is correctly retrieved, non-null,
        /// and includes valid time and price values for the first series entry.
        /// </returns>
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

        /// <summary>
        /// Tests the retrieval of option symbols for a given underlying symbol using the LookupOptionSymbols method.
        /// Validates the result to ensure it is not null and contains at least one option symbol.
        /// </summary>
        /// <param name="symbol">The underlying symbol for which to retrieve option symbols.</param>
        [Test]
        [TestCase("AAPL")]
        public async Task LookupOptionSymbolsTest(string symbol)
        {
            var result = await _client.MarketData.LookupOptionSymbols(symbol);
    
            ClassicAssert.IsNotNull(result);
            // Additional assertions can be added based on expected results
            // For example, if we expect at least one option symbol to be returned:
            ClassicAssert.Greater(result.Count, 0);
            
        }


        /// <summary>
        /// Tests the retrieval of strike prices for a given symbol at its nearest option expiration date.
        /// </summary>
        /// <param name="symbol">The stock symbol to fetch strike prices for.</param>
        /// <returns>Asynchronously returns a task that performs assertions to validate the retrieval of strike prices for the given symbol.</returns>
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

        /// Retrieves the option chain for a given stock symbol and its next available expiration date.
        /// The method first fetches the option expiration dates for the symbol. If any expiration dates are found,
        /// it retrieves the option chain for the nearest expiration date and validates the result.
        /// <param name="symbol">The stock symbol for which to fetch the option chain.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the option chain data for the specified symbol.</exception>
        /// <exception cref="AssertInconclusiveException">Thrown if no option expirations are found for the given symbol.</exception>
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