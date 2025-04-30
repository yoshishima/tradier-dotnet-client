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
    /// Represents a user account in the system, providing mechanisms for account-related operations.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Stores the default account number used within the application.
        /// </summary>
        private readonly string _defaultAccountNumber;

        /// <summary>
        /// Represents the private field used for managing and executing HTTP requests within the account operations.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// Represents an account in the system, providing methods to interact
        /// with account-related data and perform various account-specific operations.
        /// </summary>
        /// <remarks>
        /// This class uses the Requests instance to communicate with the system
        /// and functions with either the default account number or a specified account number.
        /// </remarks>
        public Account(Requests requests, string defaultAccountNumber)
        {
            _requests = requests;
            _defaultAccountNumber = defaultAccountNumber;
        }

        /// <summary>
        /// Retrieves the user's profile information.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains an instance
        /// of the <see cref="Profile" /> class, providing the user's profile information.
        /// </returns>
        public async Task<Profile> GetUserProfile()
        {
            var response = await _requests.GetRequest("user/profile");
            return JsonSerializer.Deserialize<ProfileRootObject>(response).Profile;
        }

        /// <summary>
        /// Retrieves the balances associated with the account.
        /// </summary>
        /// <param name="accountId">The unique identifier of the account to retrieve balances for.</param>
        /// <param name="currency">The currency to filter the balances. If null, returns balances in all currencies.</param>
        /// <returns>A list of balance objects containing details of each balance for the specified account.</returns>
        public async Task<Balances> GetBalances(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber)) throw new MissingAccountNumberException();

            var response = await _requests.GetRequest($"accounts/{accountNumber}/balances");
            return JsonSerializer.Deserialize<BalanceRootObject>(response).Balances;
        }

        /// <summary>
        /// Retrieves the current positions held within an account. Positions information is updated intraday.
        /// </summary>
        /// <param name="accountNumber">
        /// Optional. The account number for which to retrieve the positions. If no account number is provided,
        /// the default account number will be used.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="Positions"/> class representing the current positions in the specified account.
        /// </returns>
        /// <exception cref="MissingAccountNumberException">
        /// Thrown if no account number is provided and no default account number is available.
        /// </exception>
        public async Task<Positions> GetPositions(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber)) throw new MissingAccountNumberException();

            var response = await _requests.GetRequest($"accounts/{accountNumber}/positions");
            return JsonSerializer.Deserialize<PositionsRootobject>(response).Positions;
        }

        /// <summary>
        /// Retrieves the historical activity for the default account.
        /// </summary>
        /// <param name="page">The page number of the history to retrieve. Default is 1.</param>
        /// <param name="limitPerPage">The number of records to retrieve per page. Default is 25.</param>
        /// <returns>A task representing the asynchronous operation, returning the history of account activity.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown if the default account number is not defined.</exception>
        public async Task<History> GetHistory(int page = 1, int limitPerPage = 25)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await GetHistory(_defaultAccountNumber, page, limitPerPage);
        }

        /// <summary>
        /// Retrieves the history of transactions or activities for a specific entity.
        /// </summary>
        /// <param name="entityId">The identifier of the entity whose history is to be retrieved.</param>
        /// <param name="startDate">The starting date from which the history should be retrieved.</param>
        /// <param name="endDate">The ending date up to which the history should be retrieved.</param>
        /// <returns>
        /// A collection of historical records or activities associated with the specified entity within the given date range.
        /// </returns>
        public async Task<History> GetHistory(string accountNumber, int page = 1, int limitPerPage = 25)
        {
            var response =
                await _requests.GetRequest($"accounts/{accountNumber}/history?page={page}&limit={limitPerPage}");
            return JsonSerializer.Deserialize<HistoryRootobject>(response).History;
        }

        /// <summary>
        /// Retrieves the cost basis gain/loss information for the default user account.
        /// </summary>
        /// <param name="page">The page number of results to retrieve. (Default value: 1)</param>
        /// <param name="limitPerPage">The maximum number of results per page. (Default value: 25)</param>
        /// <returns>The cost basis gain/loss information for the default user account.</returns>
        /// <exception cref="Tradier.Client.Exceptions.MissingAccountNumberException">
        /// Thrown when the default account number is not defined.
        /// </exception>
        public async Task<GainLoss> GetGainLoss(int page = 1, int limitPerPage = 25)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await GetGainLoss(_defaultAccountNumber, page, limitPerPage);
        }

        /// <summary>
        /// Retrieves the gain/loss information for a specified account.
        /// </summary>
        /// <param name="accountNumber">The account number for which to retrieve the gain/loss information.</param>
        /// <param name="page">The page number to retrieve. Default is 1.</param>
        /// <param name="limitPerPage">The maximum number of items to retrieve per page. Default is 25.</param>
        /// <returns>The gain/loss details associated with the specified account.</returns>
        public async Task<GainLoss> GetGainLoss(string accountNumber, int page = 1, int limitPerPage = 25)
        {
            var response =
                await _requests.GetRequest($"accounts/{accountNumber}/gainloss?page={page}&limit={limitPerPage}");
            return JsonSerializer.Deserialize<GainLossRootobject>(response).GainLoss;
        }

        /// <summary>
        /// Retrieves orders placed within a specified account or the default account if no account number is provided.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number for which to retrieve the orders. If null or not specified, the default account
        /// number will be used.
        /// </param>
        /// <returns>An instance of the <see cref="Orders" /> class representing the retrieved orders.</returns>
        /// <exception cref="MissingAccountNumberException">
        /// Thrown if no account number is provided and the default account number is not set.
        /// </exception>
        public async Task<Orders> GetOrders(string accountNumber = null)
        {
            accountNumber = string.IsNullOrEmpty(accountNumber) ? _defaultAccountNumber : accountNumber;

            if (string.IsNullOrEmpty(accountNumber)) throw new MissingAccountNumberException();

            if (string.IsNullOrEmpty(accountNumber)) throw new MissingAccountNumberException();

            var response = await _requests.GetRequest($"accounts/{accountNumber}/orders");
            return JsonSerializer.Deserialize<OrdersRootobject>(response).Orders;
        }

        /// <summary>
        /// Retrieves detailed information about a previously placed order using the default account.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to retrieve.</param>
        /// <returns>The detailed information of the specified order.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown when the default account number is not defined.</exception>
        public async Task<Order> GetOrder(int orderId)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await GetOrder(_defaultAccountNumber, orderId);
        }

        /// <summary>
        /// Retrieves detailed information about a specific order associated with an account.
        /// </summary>
        /// <param name="accountNumber">The account number corresponding to the order.</param>
        /// <param name="orderId">The unique identifier for the order to retrieve.</param>
        /// <returns>The detailed information of the specified order.</returns>
        public async Task<Order> GetOrder(string accountNumber, int orderId)
        {
            var response = await _requests.GetRequest($"accounts/{accountNumber}/orders/{orderId}");
            return JsonSerializer.Deserialize<Orders>(response).Order.FirstOrDefault();
        }
    }
}