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
    ///     The <c>Trading</c> class
    /// </summary>
    public class Trading
    {
        /// <summary>
        ///     Represents the default account number.
        /// </summary>
        private readonly string _defaultAccountNumber;

        /// <summary>
        ///     Represents a variable that holds an instance of the class <see cref="Requests" />.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Trading" /> class.
        /// </summary>
        /// <param name="requests">The requests object used for making trading requests.</param>
        /// <param name="defaultAccountNumber">The default account number used for trading.</param>
        public Trading(Requests requests, string defaultAccountNumber)
        {
            _requests = requests;
            _defaultAccountNumber = defaultAccountNumber;
        }

        /// <summary>
        ///     Place an order using the default account number to trade a single option.
        /// </summary>
        /// <param name="symbol">The symbol of the underlying security.</param>
        /// <param name="optionSymbol">The symbol of the option contract.</param>
        /// <param name="side">The side of the order, either "buy" or "sell".</param>
        /// <param name="quantity">The quantity of contracts to trade.</param>
        /// <param name="type">The type of the order, such as "limit" or "market".</param>
        /// <param name="duration">The duration of the order, such as "day" or "gtc".</param>
        /// <param name="price">The limit price (optional).</param>
        /// <param name="stop">The stop price (optional).</param>
        /// <param name="preview">Indicates whether to preview the order instead of placing it (default is false).</param>
        /// <returns>An object representing the placed order.</returns>
        public async Task<IOrder> PlaceOptionOrder(string symbol, string optionSymbol, string side, int quantity,
            string type, string duration, double? price = null, double? stop = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOptionOrder(_defaultAccountNumber, symbol, optionSymbol, side, quantity, type, duration,
                price, stop, preview);
        }

        /// <summary>
        ///     Place an order to trade a single option.
        /// </summary>
        /// <param name="accountNumber">The account number to place the order.</param>
        /// <param name="symbol">The symbol of the option.</param>
        /// <param name="optionSymbol">The symbol of the option contract.</param>
        /// <param name="side">The side of the order (Buy or Sell).</param>
        /// <param name="quantity">The quantity of the option contracts to trade.</param>
        /// <param name="type">The order type (e.g., Limit, Market).</param>
        /// <param name="duration">The duration of the order (e.g., Day, GTC).</param>
        /// <param name="price">The price at which to execute the order (optional).</param>
        /// <param name="stop">The stop price for the order (optional).</param>
        /// <param name="preview">Flag indicating whether to preview the order without placing it (default is false).</param>
        /// <returns>
        ///     The placed order represented by an object implementing the IOrder interface.
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place a multileg order using the default account number with up to 4 legs.
        /// </summary>
        /// <param name="symbol">The symbol of the order</param>
        /// <param name="type">The type of the order</param>
        /// <param name="duration">The duration of the order</param>
        /// <param name="legs">
        ///     A list of tuples representing each leg of the multileg order. Each tuple contains the symbol, type,
        ///     and quantity of the leg
        /// </param>
        /// <param name="price">The price of the order (optional)</param>
        /// <param name="preview">Whether it's a preview order (optional)</param>
        /// <returns>
        ///     Returns a task representing the asynchronous operation. The task will resolve to an object implementing the
        ///     interface IOrder.
        /// </returns>
        public async Task<IOrder> PlaceMultilegOrder(string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceMultilegOrder(_defaultAccountNumber, symbol, type, duration, legs, price, preview);
        }

        /// <summary>
        ///     Place a multileg order with up to 4 legs
        /// </summary>
        /// <param name="accountNumber">The account number for the order</param>
        /// <param name="symbol">The symbol for the order</param>
        /// <param name="type">The type of the order</param>
        /// <param name="duration">The duration of the order</param>
        /// <param name="legs">The list of legs for the multileg order, each leg consists of an option symbol, side, and quantity</param>
        /// <param name="price">The price of the order</param>
        /// <param name="preview">Flag indicating whether to return the order preview response or order response</param>
        /// <returns>The order response or order preview response as IOrder</returns>
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place an order using the default account to trade an equity security
        /// </summary>
        /// <param name="symbol">The symbol of the equity security</param>
        /// <param name="side">The side of the order (buy or sell)</param>
        /// <param name="quantity">The quantity of the order</param>
        /// <param name="type">The type of the order (market, limit, stop, etc.)</param>
        /// <param name="duration">The duration of the order (day, gtc, etc.)</param>
        /// <param name="price">The price at which to execute the order (optional)</param>
        /// <param name="stop">The stop price for stop orders (optional)</param>
        /// <param name="preview">Whether to preview the order instead of placing it (optional)</param>
        /// <returns>The placed order as an instance of IOrder</returns>
        public async Task<IOrder> PlaceEquityOrder(string symbol, string side, int quantity, string type,
            string duration, double? price = null, double? stop = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceEquityOrder(_defaultAccountNumber, symbol, side, quantity, type, duration, price, stop,
                preview);
        }

        /// <summary>
        ///     Places an order to trade an equity security.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="symbol">The symbol of the equity security to trade.</param>
        /// <param name="side">The side of the order, either "buy" or "sell".</param>
        /// <param name="quantity">The quantity of the security to trade.</param>
        /// <param name="type">The type of the order, e.g. "limit", "market".</param>
        /// <param name="duration">The duration of the order, e.g. "day", "gtc" (good til cancelled).</param>
        /// <param name="price">The price at which to execute the order. Optional, use null if not applicable.</param>
        /// <param name="stop">The stop price for stop orders. Optional, use null if not applicable.</param>
        /// <param name="preview">Whether to preview the order without actually placing it. Defaults to false.</param>
        /// <returns>The placed order as an instance of IOrder.</returns>
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place a combo order using the default account number. This is a specialized type of order consisting of one equity
        ///     leg and one option leg.
        /// </summary>
        /// <param name="symbol">The symbol of the order.</param>
        /// <param name="type">The type of the order.</param>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     A list of tuples representing the legs of the order. Each tuple contains the symbol, type, and
        ///     quantity of the leg.
        /// </param>
        /// <param name="price">The price at which the order should be executed (optional).</param>
        /// <param name="preview">Flag indicating whether to preview the order without actually placing it (default: false).</param>
        /// <returns>A Task containing the placed combo order.</returns>
        public async Task<IOrder> PlaceComboOrder(string symbol, string type, string duration,
            List<(string, string, int)> legs, double? price = null, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceComboOrder(_defaultAccountNumber, symbol, type, duration, legs, price, preview);
        }

        /// <summary>
        ///     Place a combo order. This is a specialized type of order consisting of one equity leg and one option leg.
        /// </summary>
        /// <param name="accountNumber">The account number the order will be placed for.</param>
        /// <param name="symbol">The symbol of the combo order.</param>
        /// <param name="type">The type of the combo order.</param>
        /// <param name="duration">The duration of the combo order.</param>
        /// <param name="legs">
        ///     The list of legs for the combo order. Each leg contains the option symbol, side (buy/sell), and
        ///     quantity.
        /// </param>
        /// <param name="price">The price of the combo order. Optional parameter; defaults to null.</param>
        /// <param name="preview">
        ///     A flag indicating whether to return a preview of the order. Optional parameter; defaults to
        ///     false.
        /// </param>
        /// <returns>
        ///     Returns an instance of the IOrder interface representing the placed combo order, or an instance of the
        ///     IOrderPreviewResponse interface representing a preview of the combo order.
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place a one-triggers-other order using the default account number.
        ///     This order type is composed of two separate orders sent simultaneously.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     A list of tuples containing the necessary information for each leg of the order.
        ///     Each tuple should contain the following information: symbol, quantity, action, orderType, price, stopPrice
        ///     (optional), and limitPrice (optional).
        /// </param>
        /// <param name="preview">A flag indicating whether to preview the order (optional, default is false).</param>
        /// <returns>
        ///     A task representing the asynchronous operation. The task result will be of type IOrder.
        /// </returns>
        public async Task<IOrder> PlaceOtoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOtoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        ///     Place a one-triggers-other order. This order type is composed of two separate orders sent simultaneously.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     A list of tuples representing the legs of the order.
        ///     Each tuple should contain the symbol, quantity, type, option symbol, side, price, and stop of the leg.
        /// </param>
        /// <param name="preview">Indicates whether the order is a preview. Default value is false.</param>
        /// <returns>
        ///     Returns a Task object representing the asynchronous operation. The task result is
        ///     either an IOrder object or an OrderPreview object.
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place a one-cancels-other order using the default account number.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     A list of tuples representing individual orders in the one-cancels-other order. Each tuple contains the following
        ///     elements:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>The order type.</description>
        ///         </item>
        ///         <item>
        ///             <description>The quantity of the order.</description>
        ///         </item>
        ///         <item>
        ///             <description>The symbol of the order.</description>
        ///         </item>
        ///         <item>
        ///             <description>The side of the order (buy or sell).</description>
        ///         </item>
        ///         <item>
        ///             <description>The time-in-force of the order.</description>
        ///         </item>
        ///         <item>
        ///             <description>The limit price of the order (optional).</description>
        ///         </item>
        ///         <item>
        ///             <description>The stop price of the order (optional).</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <param name="preview">An optional parameter indicating whether to preview the order (defaults to false).</param>
        /// <returns>
        ///     A Task representing the asynchronous operation. The task result will be an IOrder object representing the placed
        ///     one-cancels-other order.
        /// </returns>
        public async Task<IOrder> PlaceOcoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOcoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        ///     Place a one-cancels-other order.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     The list of legs (sub-orders) in the OCO order. Each leg is represented by a tuple containing
        ///     symbol, quantity, order type, option symbol, side, price, and stop.
        /// </param>
        /// <param name="preview">Optional. Indicates whether to preview the order or directly place it. Default is false.</param>
        /// <returns>
        ///     Returns an awaitable task that represents the asynchronous operation. The task result contains the order which can
        ///     be either a real order or a preview response.
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Place a one-triggers-one-cancels-other order using the default account number.
        /// </summary>
        /// <param name="duration">The duration of the order.</param>
        /// <param name="legs">
        ///     A list of tuples representing the individual orders in the OTOCO order.
        ///     Each tuple consists of (symbol, quantity, side, priceType, timeInForce, price, stopPrice).
        /// </param>
        /// <param name="preview">Determines whether the order is a preview. Default is false.</param>
        /// <returns>The placed order.</returns>
        public async Task<IOrder> PlaceOtocoOrder(string duration,
            List<(string, int, string, string, string, double?, double?)> legs, bool preview = false)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await PlaceOtocoOrder(_defaultAccountNumber, duration, legs, preview);
        }

        /// <summary>
        ///     Place a one-triggers-one-cancels-other order.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="duration">The order duration.</param>
        /// <param name="legs">
        ///     The list of order leg tuples containing symbol, quantity, type, option symbol, side, price, and
        ///     stop.
        /// </param>
        /// <param name="preview">A flag indicating whether to preview the order. Default is false.</param>
        /// <returns>
        ///     Returns an <see cref="IOrder" /> representing the placed order if preview is set to false.
        ///     Returns a preview order response if preview is set to true.
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

            return GetOrderReponseOrOrderPreviewResponse(response, preview);
        }

        /// <summary>
        ///     Modify an order using the default account number.
        /// </summary>
        /// <param name="orderId">The ID of the order to modify.</param>
        /// <param name="type">The new order type. (Optional)</param>
        /// <param name="duration">The new order duration. (Optional)</param>
        /// <param name="price">The new order price. (Optional)</param>
        /// <param name="stop">The new order stop value. (Optional)</param>
        /// <returns>Returns an OrderResponse object.</returns>
        public async Task<OrderReponse> ModifyOrder(int orderId, string type = null, string duration = null,
            double? price = null, double? stop = null)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await ModifyOrder(_defaultAccountNumber, orderId, type, duration, price, stop);
        }

        /// <summary>
        ///     Modify an order.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="orderId">The order ID.</param>
        /// <param name="type">The type of the order. (optional)</param>
        /// <param name="duration">The duration of the order. (optional)</param>
        /// <param name="price">The price of the order. (optional)</param>
        /// <param name="stop">The stop price of the order. (optional)</param>
        /// <returns>The modified order response.</returns>
        public async Task<OrderReponse> ModifyOrder(string accountNumber, int orderId, string type = null,
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
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderReponse;
        }

        /// <summary>
        ///     Cancel an order using the default account number
        /// </summary>
        /// <param name="orderId">The ID of the order to cancel</param>
        /// <returns>A Task representing the asynchronous operation. The result will be an OrderResponse object</returns>
        public async Task<OrderReponse> CancelOrder(int orderId)
        {
            if (string.IsNullOrEmpty(_defaultAccountNumber))
                throw new MissingAccountNumberException("The default account number was not defined.");

            return await CancelOrder(_defaultAccountNumber, orderId);
        }

        /// <summary>
        ///     Cancel an order using the specified account number and order ID.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the order.</param>
        /// <param name="orderId">The ID of the order to be canceled.</param>
        /// <returns>The response object containing the details of the canceled order.</returns>
        public async Task<OrderReponse> CancelOrder(string accountNumber, int orderId)
        {
            var response = await _requests.DeleteRequest($"accounts/{accountNumber}/orders/{orderId}");
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderReponse;
        }

        /// <summary>
        ///     Retrieves the order response or order preview response based on the provided response and preview flag.
        /// </summary>
        /// <param name="response">The response string to deserialize.</param>
        /// <param name="preview">Flag indicating whether the response is an order preview.</param>
        /// <returns>The deserialized order response or order preview response.</returns>
        private IOrder GetOrderReponseOrOrderPreviewResponse(string response, bool preview)
        {
            if (preview)
                return JsonSerializer.Deserialize<OrderPreviewResponseRootobject>(response).OrderPreviewResponse;
            return JsonSerializer.Deserialize<OrderResponseRootobject>(response).OrderReponse;
        }
    }
}