﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Trading;

namespace Tradier.Client
{
    public class Trading
    {
        private readonly Requests _requests;

        public Trading(Requests requests)
        {
            _requests = requests;
        }

        public async Task<IOrder> PlaceOptionOrder(string accountNumber, string classOrder, string symbol, string optionSymbol, string side, string quantity, string type, string duration, string price = null, string stop = null, string preview = null)
        {
            var data = new Dictionary<string, string>
            {
                { "class", classOrder },
                { "symbol", symbol },
                { "option_symbol", optionSymbol },
                { "side", side },
                { "quantity", quantity },
                { "type", type },
                { "duration", duration },
                { "price", price },
                { "stop", stop },
                { "preview", preview }
            };

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);

            if (preview != null && preview.Equals("true"))
            {
                return JsonConvert.DeserializeObject<OrderPreviewResponseRootobject>(response).OrderPreviewResponse;

            }
            else
            {
                return JsonConvert.DeserializeObject<OrderResponseRootobject>(response).OrderReponse;
            }
        }

        public async Task<OrderReponse> PlaceMultilegOrder(string accountNumber, string classOrder, string symbol, string type, string duration, List<string> optionSymbol, List<string> side, List<string> quantity, string price = null)
        {
            var data = new Dictionary<string, string>
            {
                { "class", classOrder },
                { "symbol", symbol },
                { "type", type },
                { "duration", duration },
                { "price", price }
            };

            int index = 0;
            optionSymbol.ToList().ForEach(x => data.Add(string.Format("option_symbol[{0}]", index++), x));

            index = 0;
            side.ToList().ForEach(x => data.Add(string.Format("side[{0}]", index++), x));

            index = 0;
            quantity.ToList().ForEach(x => data.Add(string.Format("quantity[{0}]", index++), x));

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);
            return JsonConvert.DeserializeObject<OrderResponseRootobject>(response).OrderReponse;
        }

        public async Task<OrderReponse> ModifyOrder(string accountNumber, string orderId, string type = null, string duration = null, string price = null, string stop = null)
        {
            var data = new Dictionary<string, string>
            {
                { "type", type },
                { "duration", duration },
                { "price", price },
                { "stop", stop },
            };

            var response = await _requests.PutRequest($"accounts/{accountNumber}/orders/{orderId}", data);
            return JsonConvert.DeserializeObject<OrderResponseRootobject>(response).OrderReponse;
        }

        public async Task<OrderReponse> CancelOrder(string accountNumber, string orderId)
        {
            var response = await _requests.DeleteRequest($"accounts/{accountNumber}/orders/{orderId}");
            return JsonConvert.DeserializeObject<OrderResponseRootobject>(response).OrderReponse;
        }

        public async Task<OrderReponse> PlaceEquityOrder(string accountNumber, string classOrder, string symbol, string side, string quantity, string type, string duration, string price = null, string stop = null)
        {
            var data = new Dictionary<string, string>
            {
                { "account_id", accountNumber },
                { "class", classOrder },
                { "symbol", symbol },
                { "side", side },
                { "quantity", quantity },
                { "type", type },
                { "duration", duration },
                { "price", price },
                { "stop", stop },
            };

            var response = await _requests.PostRequest($"accounts/{accountNumber}/orders", data);
            return JsonConvert.DeserializeObject<OrderResponseRootobject>(response).OrderReponse;
        }
    }

}
