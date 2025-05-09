using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Exceptions;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Trading;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    /// The <c>Trading</c> class provides methods for placing, modifying,
    /// and canceling orders such as option orders, equity orders,
    /// multileg orders, combo orders, OTO (One Triggers Other) orders,
    /// OCO (One Cancels Other) orders, and OTOCO (One Triggers OCO) orders.
    /// It facilitates order management for different account scenarios.
    /// </summary>
    public class Trading
    {
        /// <summary>
        /// Holds the default account number used for trading operations.
        /// </summary>
        private readonly string _defaultAccountNumber;

        /// <summary>
        /// Represents an instance of the <see cref="Requests"/> class used to perform HTTP request operations.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// Provides functionality for placing trading orders, including options, multileg, and equity orders.
        /// </summary>
        public Trading(Requests requests, string defaultAccountNumber)
        {
            _requests = requests;
            _defaultAccountNumber = defaultAccountNumber;
        }

        /// <summary>
        /// Places an order to trade a single option using the default account number.
        /// </summary>
        /// <param name="symbol">The symbol of the underlying security.</param>
        /// <param name="optionSymbol">The symbol of the option contract to trade.</param>
        /// <param name="side">Indicates the side of the order, either "buy" or "sell".</param>
        /// <param name="quantity">The number of contracts to trade.</param>
        /// <param name="type">The type of the order, such as "limit" or "market".</param>
        /// <param name="duration">Specifies the duration for which the order remains active, such as "day" or "gtc".</param>
        /// <param name="price">The optional limit price for the order.</param>
        /// <param name="stop">The optional stop price for stop orders.</param>
        /// <param name="preview">Indicates whether to preview the order without placing it. Defaults to false.</param>
        /// <returns>Returns an object representing the order placed or previewed.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown when the default account number is not defined.</exception>
        public async Task<IOrder> PlaceOptionOrder(string symbol, string optionSymbol, string side, int quantity,
            string type, string duration, double? price = null, double? stop = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOptionOrder(_defaultAccountNumber, symbol, optionSymbol, side, quantity, type, duration,
                price, stop, preview);
        }

        /// <summary>
        /// Places an order to trade a single option using the specified account number and order details.
        /// </summary>
        /// <param name="accountNumber">The account number used to place the order.</param>
        /// <param name="symbol">The symbol of the underlying asset associated with the option.</param>
        /// <param name="optionSymbol">The symbol of the specific option contract to be traded.</param>
        /// <param name="side">The side of the order (e.g., Buy or Sell).</param>
        /// <param name="quantity">The number of option contracts to trade.</param>
        /// <param name="type">The type of the order (e.g., Limit, Market).</param>
        /// <param name="duration">The duration of the order (e.g., Day, GTC).</param>
        /// <param name="price">The execution price of the order, if applicable (optional).</param>
        /// <param name="stop">The stop price of the order, if applicable (optional).</param>
        /// <param name="preview">Indicates whether the order is being previewed without execution (default is false).</param>
        /// <returns>
        /// An instance of <see cref="IOrder"/> representing the outcome of the placed or previewed order.
        /// </returns>
        public async Task<IOrder> PlaceOptionOrder(string accountNumber, string symbol, string optionSymbol,
            string side, int quantity, string type, string duration, double? price = null, double? stop = null,
            bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "option" },
                { "symbol", symbol },
                { "option_symbol", optionSymbol },
                { "side", side },
                { "quantity", quantity.ToString() },
                { "type", type },
                { "duration", duration },
                { "price", price.ToString() },
                { "stop", stop.ToString() },
                { "preview", preview.ToString() }
            };

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places a multileg order using the default account number with up to 4 legs.
        /// </summary>
        /// <param name="symbol">The symbol of the order.</param>
        /// <param name="type">The type of the order.</param>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        /// A list of tuples representing each leg of the multileg order, where each tuple contains the
        /// symbol, type, and quantity of the leg.
        /// </param>
        /// <param name="price">The price of the order (optional).</param>
        /// <param name="preview">Indicates whether this is a preview order (optional).</param>
        /// <returns>
        /// A task that represents the asynchronous operation, resolving to an object implementing the
        /// <see cref="IOrder"/> interface.
        /// </returns>
        /// <exception cref="MissingAccountNumberException">
        /// Thrown if the default account number is not defined.
        /// </exception>
        public async Task<IOrder> PlaceMultilegOrder(string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceMultilegOrder(_defaultAccountNumber, symbol, type, duration, legs, price, preview);
        }

        /// <summary>
        /// Places a multileg order for the specified account with up to 4 legs.
        /// </summary>
        /// <param name="accountNumber">The account number where the order will be placed.</param>
        /// <param name="symbol">The symbol representing the underlying asset for the order.</param>
        /// <param name="type">The type of the order, such as market, limit, etc.</param>
        /// <param name="duration">The duration for which the order is active (e.g., day, GTC).</param>
        /// <param name="legs">A list containing details of up to 4 legs for the multileg order. Each leg includes an option symbol, side (buy or sell), and quantity.</param>
        /// <param name="price">The price at which the order is placed, if applicable. This parameter is optional.</param>
        /// <param name="preview">A flag indicating whether to return only a preview of the order or to execute the order.</param>
        /// <returns>An <see cref="IOrder"/> object representing the result of the order placement or its preview.</returns>
        public async Task<IOrder> PlaceMultilegOrder(string accountNumber, string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "multileg" },
                { "symbol", symbol },
                { "type", type },
                { "duration", duration },
                { "price", price.ToString() }
            };

            var index = 0;

            foreach (var leg in legs)
            {
                data.Add($"option_symbol[{index}]", leg.Item1);
                data.Add($"side[{index}]", leg.Item2);
                data.Add($"quantity[{index}]", leg.Item3.ToString());

                index++;
            }

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places an equity order using the default account.
        /// </summary>
        /// <param name="symbol">The symbol of the equity security to trade.</param>
        /// <param name="side">The side of the order (buy or sell).</param>
        /// <param name="quantity">The quantity of the order.</param>
        /// <param name="type">The order type (market, limit, stop, etc.).</param>
        /// <param name="duration">The order duration (day, gtc, etc.).</param>
        /// <param name="price">The price at which the order should execute (optional).</param>
        /// <param name="stop">The stop price for stop orders (optional).</param>
        /// <param name="preview">Whether the order is a preview request (optional).</param>
        /// <returns>The order details as an instance of <see cref="IOrder"/>.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown if the default account number is not defined.</exception>
        public async Task<IOrder> PlaceEquityOrder(string symbol, string side, int quantity, string type,
            string duration, double? price = null, double? stop = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceEquityOrder(_defaultAccountNumber, symbol, side, quantity, type, duration, price, stop,
                preview);
        }

        /// <summary>
        /// Places an equity order for a specific account.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="symbol">The symbol of the equity security to trade.</param>
        /// <param name="side">The side of the order (e.g., "buy" or "sell").</param>
        /// <param name="quantity">The quantity of the security to trade.</param>
        /// <param name="type">The type of the order (e.g., "limit", "market").</param>
        /// <param name="duration">The duration of the order (e.g., "day", "gtc").</param>
        /// <param name="price">The price for the order execution. Optional, use null if not applicable.</param>
        /// <param name="stop">The stop price for the order. Optional, use null if not applicable.</param>
        /// <param name="preview">Indicates whether to preview the order without placing it. Defaults to false.</param>
        /// <returns>An instance of <see cref="IOrder"/> representing the placed order.</returns>
        public async Task<IOrder> PlaceEquityOrder(string accountNumber, string symbol, string side, int quantity,
            string type, string duration, double? price = null, double? stop = null, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "account_id", accountNumber },
                { "class", "equity" },
                { "symbol", symbol },
                { "side", side },
                { "quantity", quantity.ToString() },
                { "type", type },
                { "duration", duration },
                { "price", price.ToString() },
                { "stop", stop.ToString() },
                { "preview", preview.ToString() }
            };

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places a combo order using the default account number. This order includes multiple legs with specific symbols,
        /// types, and quantities.
        /// </summary>
        /// <param name="symbol">The symbol of the primary order.</param>
        /// <param name="type">The type of order to be placed.</param>
        /// <param name="duration">The duration for which the order remains active.</param>
        /// <param name="legs">
        /// A list of tuples specifying the legs of the order. Each tuple contains the symbol, type, and quantity
        /// of a leg.
        /// </param>
        /// <param name="price">The price at which the order should be executed (optional).</param>
        /// <param name="preview">
        /// A flag indicating whether to preview the order without executing it. Default is false.
        /// </param>
        /// <returns>A Task containing the result of the placed combo order.</returns>
        public async Task<IOrder> PlaceComboOrder(string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceComboOrder(_defaultAccountNumber, symbol, type, duration, legs, price, preview);
        }

        /// <summary>
        /// Places a combo order, which combines multiple legs such as one equity leg and one or more option legs.
        /// </summary>
        /// <param name="accountNumber">The account number to place the order against.</param>
        /// <param name="symbol">The symbol representing the primary security for the combo order.</param>
        /// <param name="type">The type of the order, such as market or limit.</param>
        /// <param name="duration">The duration for which the order is valid (e.g., day, good-till-canceled).</param>
        /// <param name="legs">
        /// A collection of tuples where each tuple defines a leg of the combo order. Each tuple includes an option
        /// symbol, the side of the trade (buy or sell), and the quantity for that leg.
        /// </param>
        /// <param name="price">
        /// The price for the combo order. This is an optional parameter and may be null when not required.
        /// </param>
        /// <param name="preview">
        /// A flag indicating whether to return a preview of the order instead of placing it. Defaults to false.
        /// </param>
        /// <returns>
        /// Returns an implementation of the <see cref="IOrder" /> interface if the order is placed successfully. If
        /// preview is set to true, it returns an order preview instead.
        /// </returns>
        public async Task<IOrder> PlaceComboOrder(string accountNumber, string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "combo" },
                { "symbol", symbol },
                { "type", type },
                { "duration", duration },
                { "price", price.ToString() }
            };

            var index = 0;

            foreach (var leg in legs)
            {
                data.Add($"option_symbol[{index}]", leg.Item1);
                data.Add($"side[{index}]", leg.Item2);
                data.Add($"quantity[{index}]", leg.Item3.ToString());

                index++;
            }

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places a one-triggers-other (OTO) order using the default account number.
        /// An OTO order is composed of two linked orders sent simultaneously: one primary order
        /// and a secondary order that is triggered only if the primary order executes.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        /// A list of tuples containing details for each leg of the order. Each tuple includes the following:
        /// symbol, quantity, action, order type, price, stop price (optional), and limit price (optional).
        /// </param>
        /// <param name="preview">
        /// Indicates whether the order should be previewed without being executed. Defaults to false.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an <see cref="IOrder"/> instance
        /// containing details of the placed order.
        /// </returns>
        /// <exception cref="MissingAccountNumberException">
        /// Thrown if the default account number is not defined.
        /// </exception>
        public async Task<IOrder> PlaceOtoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOtoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        /// Places a one-triggers-other (OTO) order. This order type is composed of two separate orders sent simultaneously.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        /// A list of tuples representing the legs of the order. Each tuple represents the symbol, quantity,
        /// type, option symbol, side, price, and stop of the leg.
        /// </param>
        /// <param name="preview">Indicates whether the order is a preview. Default value is false.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The result contains an object of type IOrder.
        /// </returns>
        public async Task<IOrder> PlaceOtoOrder(string accountNumber, string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "oto" },
                { "duration", duration },
                { "preview", preview.ToString() }
            };

            var index = 0;

            foreach (var leg in legs)
            {
                data.Add($"symbol[{index}]", leg.Item1);
                data.Add($"quantity[{index}]", leg.Item2.ToString());
                data.Add($"type[{index}]", leg.Item3);
                data.Add($"option_symbol[{index}]", leg.Item4);
                data.Add($"side[{index}]", leg.Item5);
                data.Add($"price[{index}]", leg.Item6.HasValue ? leg.Item6.ToString() : "");
                data.Add($"stop[{index}]", leg.Item7.HasValue ? leg.Item7.ToString() : "");

                index++;
            }

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places a one-cancels-other (OCO) order using the default account number.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        /// A list of tuples representing individual orders in the one-cancels-other order. Each tuple includes:
        /// - The order type.
        /// - The quantity of the order.
        /// - The symbol of the order.
        /// - The side of the order (buy or sell).
        /// - The time-in-force of the order.
        /// - The limit price of the order (optional).
        /// - The stop price of the order (optional).
        /// </param>
        /// <param name="preview">Indicates whether the order is a preview. Defaults to false.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result will be an IOrder object
        /// representing the placed one-cancels-other order.
        /// </returns>
        public async Task<IOrder> PlaceOcoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOcoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        /// Places a one-cancels-other (OCO) order.
        /// </summary>
        /// <param name="accountNumber">The account number to use for the order.</param>
        /// <param name="duration">The duration of the order, defining how long the order remains active.</param>
        /// <param name="legs">
        /// A list of tuples representing the legs (sub-orders) of the OCO order. Each tuple consists of:
        /// symbol (string), quantity (int), order type (string), option symbol (string), side (string), price (double?), and stop (double?).
        /// </param>
        /// <param name="preview">
        /// Optional. A boolean value indicating whether to preview the order before placing it. Defaults to false.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains an object implementing the <see cref="IOrder"/> interface,
        /// which includes either the order details or a preview response.
        /// </returns>
        public async Task<IOrder> PlaceOcoOrder(string accountNumber, string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "oco" },
                { "duration", duration },
                { "preview", preview.ToString() }
            };

            var index = 0;

            foreach (var leg in legs)
            {
                data.Add($"symbol[{index}]", leg.Item1);
                data.Add($"quantity[{index}]", leg.Item2.ToString());
                data.Add($"type[{index}]", leg.Item3);
                data.Add($"option_symbol[{index}]", leg.Item4);
                data.Add($"side[{index}]", leg.Item5);
                data.Add($"price[{index}]", leg.Item6.HasValue ? leg.Item6.ToString() : "");
                data.Add($"stop[{index}]", leg.Item7.HasValue ? leg.Item7.ToString() : "");

                index++;
            }

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Places a one-triggers-one-cancels-other (OTOCO) order using the default account number.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        /// A list of tuples representing the individual orders in the OTOCO order.
        /// Each tuple contains values for (symbol, quantity, side, priceType, timeInForce, price, stopPrice).
        /// </param>
        /// <param name="preview">Indicates whether the order should be previewed before being placed. Default is false.</param>
        /// <returns>The placed OTOCO order.</returns>
        /// <exception cref="MissingAccountNumberException">Thrown when no default account number is defined.</exception>
        public async Task<IOrder> PlaceOtocoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOtocoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        /// Places a one-triggers-one-cancels-other (OTOCO) order for the specified account.
        /// </summary>
        /// <param name="accountNumber">The account number to place the order under.</param>
        /// <param name="duration">The duration of the order (e.g., day, good-till-canceled).</param>
        /// <param name="legs">
        /// A collection of order leg tuples containing the following fields:
        /// symbol, quantity, type, option symbol, side, price, and stop values.
        /// </param>
        /// <param name="preview">
        /// A boolean value indicating whether the order is simulated (preview mode) or actually executed.
        /// Default is false.
        /// </param>
        /// <returns>
        /// An <see cref="IOrder" /> object representing the placed order, or a preview response
        /// if the preview flag is set to true.
        /// </returns>
        public async Task<IOrder> PlaceOtocoOrder(string accountNumber, string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            var data = new Dictionary<string, string>
            {
                { "class", "otoco" },
                { "duration", duration },
                { "preview", preview.ToString() }
            };

            var index = 0;

            foreach (var leg in legs)
            {
                data.Add($"symbol[{index}]", leg.Item1);
                data.Add($"quantity[{index}]", leg.Item2.ToString());
                data.Add($"type[{index}]", leg.Item3);
                data.Add($"option_symbol[{index}]", leg.Item4);
                data.Add($"side[{index}]", leg.Item5);
                data.Add($"price[{index}]", leg.Item6.HasValue ? leg.Item6.ToString() : "");
                data.Add($"stop[{index}]", leg.Item7.HasValue ? leg.Item7.ToString() : "");

                index++;
            }

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            return GetOrderResponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        /// Modifies an order using the default account number.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to modify.</param>
        /// <param name="type">The new order type. (Optional)</param>
        /// <param name="duration">The new order duration. (Optional)</param>
        /// <param name="price">The new order price. (Optional)</param>
        /// <param name="stop">The new order stop value. (Optional)</param>
        /// <returns>Returns an <see cref="OrderResponse"/> representing the modified order.</returns>
        public async Task<OrderResponse> ModifyOrder(int orderId, string type = null, string duration = null,
            double? price = null, double? stop = null)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await ModifyOrder(_defaultAccountNumber, orderId, type, duration, price, stop);
        }

        /// <summary>
        /// Modifies an existing order in the specified account.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="orderId">The unique identifier of the order to be modified.</param>
        /// <param name="type">The new type of the order. This parameter is optional.</param>
        /// <param name="duration">The new duration of the order. This parameter is optional.</param>
        /// <param name="price">The updated price for the order. This parameter is optional.</param>
        /// <param name="stop">The updated stop price for the order. This parameter is optional.</param>
        /// <returns>The response containing details of the modified order.</returns>
        public async Task<OrderResponse> ModifyOrder(string accountNumber, int orderId, string type = null,
            string duration = null, double? price = null, double? stop = null)
        {
            var data = new Dictionary<string, string>
            {
                { "type", type },
                { "duration", duration },
                { "price", price.HasValue ? price.ToString() : "" },
                { "stop", stop.HasValue ? stop.ToString() : "" }
            };

            var response = await _requests.PutRequest($"accounts/{accountNumber}/orders/{orderId}", data);
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderResponse;
        }

        /// <summary>
        /// Cancels an order using the default account number.
        /// </summary>
        /// <param name="orderId">The ID of the order to cancel.</param>
        /// <returns>A task representing the asynchronous operation. The result is an <see cref="OrderResponse"/> object containing the details of the canceled order.</returns>
        public async Task<OrderResponse> CancelOrder(int orderId)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await CancelOrder(_defaultAccountNumber, orderId);
        }

        /// <summary>
        /// Cancels an order using the specified account number and order ID.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="orderId">The unique identifier of the order to be canceled.</param>
        /// <returns>An <see cref="OrderResponse"/> object representing the result of the cancelation.</returns>
        public async Task<OrderResponse> CancelOrder(string accountNumber, int orderId)
        {
            var response = await _requests.DeleteRequest($"accounts/{accountNumber}/orders/{orderId}");
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderResponse;
        }

        /// <summary>
        /// Retrieves the order response or order preview response based on the provided response and preview flag.
        /// </summary>
        /// <param name="response">The response string to deserialize.</param>
        /// <param name="preview">Indicates whether the response is an order preview.</param>
        /// <returns>The deserialized order response or order preview response.</returns>
        private IOrder GetOrderResponseOrOrderPreviewResponse(string response, bool preview)
        {
            if (preview)
                return JsonSerializer.Deserialize<OrderPreviewResponseRootobject>(response).OrderPreviewResponse;
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderResponse;
        }
    }
}