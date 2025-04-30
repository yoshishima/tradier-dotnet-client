using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Tradier.Client;
using Tradier.Client.Models.Account;
using TradierClient.Test.Helpers;

namespace TradierClient.Test.Tests
{
    /// <summary>
    /// Contains unit tests for various account-related functionalities of the Tradier API client.
    /// </summary>
    /// <remarks>
    /// This test class validates methods of the Tradier client's account functionality,
    /// including retrieving account data such as balances, positions, history, gain/loss,
    /// orders, and user profile. A sandbox or production API token can be used during setup.
    /// </remarks>
    public class AccountTests
    {
        /// <summary>
        /// Represents an instance of the <see cref="Tradier.Client.TradierClient"/> class used for interacting with
        /// the Tradier API. This client is configured to communicate with either the sandbox or production APIs,
        /// based on the provided API token and account information during initialization.
        /// </summary>
        /// <remarks>
        /// The <see cref="_client"/> variable is utilized in various test cases to perform operations such as
        /// retrieving user profiles, account balances, positions, trading history, and more through the Tradier API.
        /// </remarks>
        private Tradier.Client.TradierClient _client;

        /// <summary>
        /// Represents the configuration settings used in tests for the Tradier client,
        /// including API tokens and the default account number.
        /// This variable is initialized with the application configuration using the
        /// <c>Configuration.GetApplicationConfiguration</c> method in the test directory context.
        /// </summary>
        private Settings _settings;

        /// <summary>
        /// Initializes the testing environment for the account-related tests.
        /// This method sets up necessary configurations by loading
        /// application settings from a configuration file. It is executed
        /// before each test to ensure a consistent setup and prevent
        /// dependency issues between tests.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _settings = Configuration.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
        }

        /// <summary>
        /// Configures and initializes the TradierClient instance for use during tests.
        /// </summary>
        /// <remarks>
        /// This setup method is invoked before each test to ensure a consistent testing environment.
        /// It initializes the TradierClient with the API token and default account number from the settings.
        /// By default, it uses the production API token unless specified otherwise.
        /// </remarks>
        [SetUp]
        public void Setup()
        {
            // Use SandBox API Token
            //var sandboxApiToken = _settings.SandboxApiToken;
            //_client = new Tradier.Client.TradierClient(sandboxApiToken);

            //Use Production API Token
            var apiToken = _settings.ApiToken;
            var defaultAccountNumber = _settings.DefaultAccountNumber;
            _client = new Tradier.Client.TradierClient(apiToken, defaultAccountNumber, true);

        }


        /// Tests the retrieval of the user profile information through the Tradier API account endpoint.
        /// <returns>
        /// An asynchronous task that performs assertions on the user profile data to ensure the API
        /// correctly fetches and returns valid profile information. Validations include checks for the
        /// presence of user ID, name, account details, and account count greater than zero.
        /// </returns>
        [Test]
        public async Task GetUserProfileTest()
        {
            var result = await _client.Account.GetUserProfile();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.Id);
            ClassicAssert.IsNotNull(result.Name);
            ClassicAssert.IsNotNull(result.Account);
            ClassicAssert.Greater(result.Account.Count, 0);
        }


        /// <summary>
        /// Tests the GetBalances method to ensure it retrieves the balances for an account successfully.
        /// </summary>
        /// <return>Asserts the correctness of the retrieved account balances, including account number and account type.</return>
        [Test]
        public async Task GetBalancesTest()
        {
            var result = await _client.Account.GetBalances();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.AccountNumber);
            ClassicAssert.IsNotNull(result.AccountType);
        }

        /// <summary>
        /// Tests the retrieval of account positions.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous test operation. Validates that the positions
        /// retrieved from the account are not null, are of the correct type, and meet the expected structure.
        /// </returns>
        [Test]
        public async Task GetPositionsTest()
        {
            // Arrange
    
            // Act
            var result = await _client.Account.GetPositions();
    
            // Assert
            ClassicAssert.IsNotNull(result);
            // Additional assertions could validate the structure of the Positions object
            // even if it's empty, such as checking that the object is of the correct type
            ClassicAssert.IsInstanceOf<Positions>(result);
    
            // If Positions has properties that should always be present (even when empty):
            // ClassicAssert.IsNotNull(result.PropertyName);
        }

        /// <summary>
        /// Validates the retrieval of historical activity for the default account
        /// using the GetHistory method.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation that retrieves
        /// and validates the account history.
        /// </returns>
        [Test]
        public async Task GetHistoryTest()
        {
            var result = await _client.Account.GetHistory();
            ClassicAssert.IsNotNull(result);
            // History might be empty for a new account or in sandbox,
            // so we just validate that the object is returned correctly
        }

        /// <summary>
        /// Tests the retrieval of cost basis gain/loss information for the user's account
        /// using the Tradier API client.
        /// </summary>
        /// <returns>Asserts that the response is not null and is returned correctly.</returns>
        [Test]
        public async Task GetGainLossTest()
        {
            var result = await _client.Account.GetGainLoss();
            ClassicAssert.IsNotNull(result);
            // The result might have empty closed positions if no transactions exist
            // so we just validate the object is returned correctly
        }

        /// <summary>
        /// Tests the GetOrders method of the Account client to ensure it retrieves order data correctly.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous unit test. The task does not return any value but will fail the test if the
        /// GetOrders method does not return a valid response (e.g., null result).
        /// </returns>
        [Test]
        public async Task GetOrdersTest()
        {
            var result = await _client.Account.GetOrders();
            ClassicAssert.IsNotNull(result);
            // The result might have empty orders if no orders exist
            // so we just validate the object is returned correctly
        }

        /// <summary>
        /// Cleans up resources and resets the state after each test execution.
        /// </summary>
        /// <remarks>
        /// This method is called after each test execution as part of the NUnit TearDown process.
        /// It sets the client instance to null to clear any shared state. The TradierClient class
        /// does not implement IDisposable, so no additional cleanup is required.
        /// </remarks>
        [TearDown]
        public void Cleanup()
        {
            // Nothing to dispose as TradierClient doesn't implement IDisposable
            _client = null;
        }



        // Note: Testing specific orders requires an actual order ID,
        // which would vary by account and may be challenging in a sandbox
        // environment. For complete testing, consider creating and then retrieving
        // a test order, or using a mock order ID known to exist.

        // [Test]
        // public async Task GetOrderTest()
        // {
        //     // This would require a known order ID in the account
        //     int testOrderId = 123456; // Replace with a valid order ID
        //     var result = await _client.Account.GetOrder(testOrderId);
        //     ClassicAssert.IsNotNull(result);
        //     ClassicAssert.AreEqual(testOrderId, result.Id);
        // }
    }
}