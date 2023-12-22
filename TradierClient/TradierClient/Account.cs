using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Exceptions;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Account;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    /// The Account class represents an account in the system.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The private field for handling requests.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// Represents the default account number.
        /// </summary>
        private readonly string _defaultAccountNumber;

        /// <summary>
        /// Represents an account with a specific account number.
        /// </summary>
        /// <param name="requests">The Requests instance used to make account-related requests.</param>
        /// <param name="defaultAccountNumber">The default account number for the account.</param>
        public Account(Requests requests, string defaultAccountNumber)
        {
            _requests = requests;
            _defaultAccountNumber = defaultAccountNumber;
        }

        /// <summary>
        /// Retrieves the user's profile information. </summary> <returns> A <see cref="Task{TResult}"/> representing the asynchronous operation.<br/>
        /// The task result contains an instance of the <see cref="Profile"/> class,
        /// representing the user's profile information. </returns>
        /// /
        public async Task<Profile> GetUserProfile()
        {
            var response = await _requests.GetRequest("user/profile");
            return JsonSerializer.Deserialize<ProfileRootObject>(response).Profile;
        }

        /// <summary>
        /// Get balances information for a specific or a default user account.
        /// </summary>
        /// <param name="accountNumber">The account number for which the balances information is requested. If null, the default account number will be used.</param>
        /// <returns>The balances information for the specified or default user account.</returns>
        public async Task<Balances> GetBalances(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new MissingAccountNumberException();
            }

            var response = await _requests.GetRequest($"accounts/{accountNumber}/balances");
            return JsonSerializer.Deserialize<BalanceRootObject>(response).Balances;
        }

        /// <summary>
        /// Get the current positions being held in an account. These positions are updated intraday via trading.
        /// </summary>
        /// <param name="accountNumber">Optional. The account number to retrieve positions for.</param>
        /// <returns>The current positions being held in the account as an instance of the Positions class.</returns>
        public async Task<Positions> GetPositions(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new MissingAccountNumberException();
            }

            var response = await _requests.GetRequest($"accounts/{accountNumber}/positions");
            return JsonSerializer.Deserialize<PositionsRootobject>(response).Positions;
        }

        /// <summary>
        /// Get historical activity for the default account.
        /// </summary>
        /// <param name="page">The page number of the history to retrieve. Default is 1.</param>
        /// <param name="limitPerPage">The number of records to retrieve per page. Default is 25.</param>
        /// <returns>A task representing the asynchronous operation, returning the history of activity.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown if the default account number is not defined.</exception>
        public async Task<History> GetHistory(int page = 1, int limitPerPage = 25)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
            {
                throw new MissingAccountNumberException("The default account number was not defined.");
            }

            return await GetHistory(_defaultAccountNumber, page, limitPerPage);
        }

        /// <summary>
        /// Get historical activity for an account.
        /// </summary>
        /// <param name="accountNumber">The account number for which to retrieve the history.</param>
        /// <param name="page">The page of results to retrieve. Default value is 1.</param>
        /// <param name="limitPerPage">The maximum number of results to retrieve per page. Default value is 25.</param>
        /// <returns>The historical activity for the specified account.</returns>
        public async Task<History> GetHistory(string accountNumber, int page = 1, int limitPerPage = 25)
        {
            var response =
                await _requests.GetRequest($"accounts/{accountNumber}/history?page={page}&limit={limitPerPage}");
            return JsonSerializer.Deserialize<HistoryRootobject>(response).History;
        }

        /// <summary>
        /// Get cost basis information for the default user account.
        /// </summary>
        /// <param name="page">The page number of results to retrieve. (Default value: 1)</param>
        /// <param name="limitPerPage">The maximum number of results per page. (Default value: 25)</param>
        /// <returns>The cost basis gain/loss information for the default user account.</returns>
        public async Task<GainLoss> GetGainLoss(int page = 1, int limitPerPage = 25)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
            {
                throw new MissingAccountNumberException("The default account number was not defined.");
            }

            return await GetGainLoss(_defaultAccountNumber, page, limitPerPage);
        }

        /// <summary>
        /// Gets the gain/loss information for a specific user account.
        /// </summary>
        /// <param name="accountNumber">The account number for which to retrieve the gain/loss information.</param>
        /// <param name="page">The page number of the data to retrieve. Default is 1.</param>
        /// <param name="limitPerPage">The maximum number of items to retrieve per page. Default is 25.</param>
        /// <returns>The gain/loss information for the specified account.</returns>
        /// <remarks>
        /// This method retrieves the gain/loss information for a given user account.
        /// The account number, page number, and limit per page can be specified in the method parameters.
        /// By default, the method retrieves the first page and limits the result to 25 items per page.
        /// </remarks>
        public async Task<GainLoss> GetGainLoss(string accountNumber, int page = 1, int limitPerPage = 25)
        {
            var response =
                await _requests.GetRequest($"accounts/{accountNumber}/gainloss?page={page}&limit={limitPerPage}");
            return JsonSerializer.Deserialize<GainLossRootobject>(response).GainLoss;
        }

        /// <summary>
        /// Retrieve orders placed within an account.
        /// </summary>
        /// <param name="accountNumber">The account number for which to retrieve the orders. If not specified, the default account number will be used.</param>
        /// <returns>An instance of the <see cref="Orders"/> class representing the retrieved orders.</returns>
        public async Task<Orders> GetOrders(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new MissingAccountNumberException();
            }

            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new MissingAccountNumberException();
            }

            var response = await _requests.GetRequest($"accounts/{accountNumber}/orders");
            return JsonSerializer.Deserialize<OrdersRootobject>(response).Orders;
        }

        /// <summary>
        /// Get detailed information about a previously placed order in the default account.
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve information for.</param>
        /// <returns>The detailed information about the specified order.</returns>
        public async Task<Order> GetOrder(int orderId)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
            {
                throw new MissingAccountNumberException("The default account number was not defined.");
            }

            return await GetOrder(_defaultAccountNumber, orderId);
        }

        /// <summary>
        /// Get detailed information about a previously placed order.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The detailed information of the order.</returns>
        public async Task<Order> GetOrder(string accountNumber, int orderId)
        {
            var response = await _requests.GetRequest($"accounts/{accountNumber}/orders/{orderId}");
            return JsonSerializer.Deserialize<Orders>(response).Order.FirstOrDefault();
        }
    }
}