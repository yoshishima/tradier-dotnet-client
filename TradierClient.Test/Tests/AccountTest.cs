using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Tradier.Client;
using TradierClient.Test.Helpers;

namespace TradierClient.Test.Tests
{
    public class AccountTests
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
            // Use SandBox API Token with default account number
            var sandboxApiToken = _settings.SandboxApiToken;
            _client = new Tradier.Client.TradierClient(sandboxApiToken, _settings.DefaultAccountNumber);

            //Use Production API Token
            //var apiToken = _settings.ApiToken;
            //_client = new Tradier.Client.TradierClient(apiToken, _settings.DefaultAccountNumber, true);
        }

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

        [Test]
        public async Task GetBalancesTest()
        {
            var result = await _client.Account.GetBalances();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.AccountNumber);
            ClassicAssert.IsNotNull(result.AccountType);
        }

        [Test]
        public async Task GetPositionsTest()
        {
            var result = await _client.Account.GetPositions();
            ClassicAssert.IsNotNull(result);
            // The result might have empty positions if no positions are held
            // so we just validate the object is returned correctly
        }

        [Test]
        public async Task GetHistoryTest()
        {
            var result = await _client.Account.GetHistory();
            ClassicAssert.IsNotNull(result);
            // History might be empty for a new account or in sandbox,
            // so we just validate that the object is returned correctly
        }

        [Test]
        public async Task GetGainLossTest()
        {
            var result = await _client.Account.GetGainLoss();
            ClassicAssert.IsNotNull(result);
            // The result might have empty closed positions if no transactions exist
            // so we just validate the object is returned correctly
        }

        [Test]
        public async Task GetOrdersTest()
        {
            var result = await _client.Account.GetOrders();
            ClassicAssert.IsNotNull(result);
            // The result might have empty orders if no orders exist
            // so we just validate the object is returned correctly
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