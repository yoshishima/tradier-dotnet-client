# Tradier .NET Client

A comprehensive .NET library for interacting with the [Tradier API](https://documentation.tradier.com/). This client enables you to access account information, retrieve market data, execute trades, and manage watchlists.

## Features

- ✅ Targets .NET 9.0
- ✅ Uses System.Text.Json for efficient serialization/deserialization
- ✅ Complete API coverage including account data, market information, and trading
- ✅ Full support for Fundamentals API endpoints
- ✅ Asynchronous methods with Task-based pattern
- ✅ Flexible HttpClient integration

## Prerequisites

To use this client, you need an Access Token from Tradier, either for:
- [Developer Sandbox](https://developer.tradier.com/user/sign_up) (for testing)
- [Brokerage Account](https://documentation.tradier.com/brokerage-api) (for live trading)

## Installation

Install the [NuGet package](https://www.nuget.org/packages/tradier-dotnet-client/) using the Package Manager Console:

```
PM> Install-Package tradier-dotnet-client
```

Or via the .NET CLI:

```
dotnet add package tradier-dotnet-client
```

## Quick Start

### Basic Initialization

```csharp
using Tradier.Client;

// For sandbox environment (default)
var client = new TradierClient("<YOUR_TOKEN>");

// For production environment
var client = new TradierClient("<YOUR_TOKEN>", useProduction: true);

// With default account number
var client = new TradierClient("<YOUR_TOKEN>", "<ACCOUNT_NUMBER>", useProduction: true);
```

### Using Your Own HttpClient

```csharp
using System.Net.Http;
using Tradier.Client;

var httpClient = new HttpClient();
// Configure HttpClient as needed (e.g., timeout, handlers)
var client = new TradierClient(httpClient, "<YOUR_TOKEN>", useProduction: true);
```

## API Coverage

### Account

```csharp
// Get user profile
var profile = await client.Account.GetUserProfile();

// Get account balances
var balances = await client.Account.GetBalances();
// Or for a specific account
var balances = await client.Account.GetBalances("<ACCOUNT_NUMBER>");

// Get positions
var positions = await client.Account.GetPositions();

// Get account history
var history = await client.Account.GetHistory();
// With pagination
var history = await client.Account.GetHistory(page: 2, limitPerPage: 50);

// Get gain/loss
var gainLoss = await client.Account.GetGainLoss();

// Get orders
var orders = await client.Account.GetOrders();

// Get a specific order
var order = await client.Account.GetOrder(orderId);
```

### Authentication

```csharp
// Create access token from authorization code
var token = await client.Authentication.CreateAccessToken("<AUTH_CODE>");

// Refresh access token
var newToken = await client.Authentication.RefreshAccessToken("<REFRESH_TOKEN>");
```

### Market Data

```csharp
// Get quotes
var quotes = await client.MarketData.GetQuotes("AAPL,MSFT,GOOG");

// Get option chain
var options = await client.MarketData.GetOptionChain("AAPL", DateTime.Parse("2023-12-15"));
// Include Greeks
var optionsWithGreeks = await client.MarketData.GetOptionChain("AAPL", "2023-12-15", greeks: true);

// Get option strikes
var strikes = await client.MarketData.GetStrikes("SPY", DateTime.Parse("2023-12-15"));

// Get option expirations
var expirations = await client.MarketData.GetOptionExpirations("AAPL");

// Get historical quotes
var historicalData = await client.MarketData.GetHistoricalQuotes(
    "AAPL", 
    "daily", 
    DateTime.Parse("2023-01-01"), 
    DateTime.Parse("2023-03-31")
);

// Get time and sales data
var timeSales = await client.MarketData.GetTimeSales(
    "AAPL", 
    "5min", 
    DateTime.Parse("2023-03-01 09:30"), 
    DateTime.Parse("2023-03-01 16:00")
);

// Get clock information
var clock = await client.MarketData.GetClock();

// Get calendar information
var calendar = await client.MarketData.GetCalendar();

// Search for companies or symbols
var searchResults = await client.MarketData.SearchCompanies("Apple");
var symbolLookup = await client.MarketData.LookupSymbol("AAPL");
```

### Trading

```csharp
// Place equity order
var equityOrder = await client.Trading.PlaceEquityOrder(
    "AAPL",
    "buy",
    10,
    "limit",
    "day",
    price: 150.00
);

// Place option order
var optionOrder = await client.Trading.PlaceOptionOrder(
    "SPY",
    "SPY230616C450000",
    "buy_to_open",
    1,
    "limit",
    "day",
    price: 5.00
);

// Place multileg option order
var multilegOrder = await client.Trading.PlaceMultilegOrder(
    "SPY",
    "limit",
    "day",
    new List<(string, string, int)> { 
        ("SPY230616C450000", "buy_to_open", 1), 
        ("SPY230616C460000", "sell_to_open", 1) 
    },
    price: 2.50
);

// Place combo order (equity + option)
var comboOrder = await client.Trading.PlaceComboOrder(
    "SPY",
    "limit",
    "day",
    new List<(string, string, int)> {
        ("SPY", "buy", 100),
        ("SPY230616P440000", "buy_to_open", 1)
    },
    price: 445.00
);

// Place one-triggers-other (OTO) order
var otoOrder = await client.Trading.PlaceOtoOrder(
    "day",
    new List<(string, int, string, string, string, double?, double?)> {
        ("AAPL", 100, "limit", "", "buy", 150.00, null),
        ("AAPL", 100, "limit", "", "sell", 160.00, null)
    }
);

// Place one-cancels-other (OCO) order
var ocoOrder = await client.Trading.PlaceOcoOrder(
    "day",
    new List<(string, int, string, string, string, double?, double?)> {
        ("AAPL", 100, "limit", "", "sell", 160.00, null),
        ("AAPL", 100, "stop", "", "sell", null, 140.00)
    }
);

// Place one-triggers-one-cancels-other (OTOCO) order
var otocoOrder = await client.Trading.PlaceOtocoOrder(
    "day",
    new List<(string, int, string, string, string, double?, double?)> {
        ("AAPL", 100, "limit", "", "buy", 150.00, null),
        ("AAPL", 100, "limit", "", "sell", 160.00, null),
        ("AAPL", 100, "stop", "", "sell", null, 140.00)
    }
);

// Modify an order
var modifiedOrder = await client.Trading.ModifyOrder(
    orderId,
    "limit",
    "day",
    price: 152.50
);

// Cancel an order
var cancelledOrder = await client.Trading.CancelOrder(orderId);
```

### Watchlist

```csharp
// Get all watchlists
var watchlists = await client.Watchlist.GetWatchlists();

// Create a watchlist
var newWatchlist = await client.Watchlist.CreateWatchlist(
    "Tech Stocks", 
    "AAPL,MSFT,GOOG,AMZN,META"
);

// Get a specific watchlist
var watchlist = await client.Watchlist.GetWatchlist(watchlistId);

// Update a watchlist
var updatedWatchlist = await client.Watchlist.UpdateWatchlist(
    watchlistId, 
    "Updated Tech Stocks", 
    "AAPL,MSFT,GOOG,AMZN,META,NFLX"
);

// Add symbols to watchlist
var watchlistWithAddedSymbols = await client.Watchlist.AddSymbolsToWatchlist(
    watchlistId, 
    "TSLA,NVDA"
);

// Remove symbol from watchlist
var watchlistWithRemovedSymbol = await client.Watchlist.RemoveSymbolFromWatchlist(
    watchlistId, 
    "AMZN"
);

// Delete a watchlist
var deletedWatchlists = await client.Watchlist.DeleteWatchlist(watchlistId);
```

### Fundamentals

```csharp
// Get company information
var companyInfo = await client.Fundamentals.GetCompanyInformation("AAPL,MSFT");

// Get financial statements
var financials = await client.Fundamentals.GetFinancials("AAPL");

// Get financial ratios
var ratios = await client.Fundamentals.GetRatios("AAPL");

// Get dividend information
var dividends = await client.Fundamentals.GetDividends("AAPL");

// Get corporate actions
var corporateActions = await client.Fundamentals.GetCorporateActions("AAPL");

// Get corporate calendars
var corporateCalendars = await client.Fundamentals.GetCorporateCalendars("AAPL");

// Get company statistics
var companyStats = await client.Fundamentals.GetCompanyStatistics("AAPL");
```

### Streaming 

```csharp
// Get streaming token
var streamToken = await client.Streaming.GetStreamingToken();

// Establish WebSocket connection
await client.Streaming.EstablishWebSocket(
    streamToken.Url,
    streamToken.SessionId,
    "AAPL,MSFT,SPY"
);
```

## Error Handling

The client provides specific exception types to help identify and handle errors:

```csharp
try
{
    var order = await client.Trading.PlaceEquityOrder("AAPL", "buy", 10, "limit", "day", 150.00);
}
catch (MissingAccountNumberException ex)
{
    // Handle missing account number
    Console.WriteLine("Account number is required: " + ex.Message);
}
catch (TradierClientException ex)
{
    // Handle API errors
    Console.WriteLine("Tradier API error: " + ex.Message);
}
catch (Exception ex)
{
    // Handle other errors
    Console.WriteLine("Unexpected error: " + ex.Message);
}
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Authors

* **[Yoshishima](https://github.com/yoshishima)** - Current maintainer and developer

### Original Authors
This project was forked from the work initially created by:
* **[Henrique Tedeschi](https://github.com/htedeschi)**
* **[Vitali Karmanov](https://github.com/vitali-karmanov)**

## License

This library is provided under the Apache 2.0 License - see the [LICENSE](https://github.com/yoshishima/tradier-dotnet-client/blob/master/LICENSE) file for details.

## Disclaimer

This wrapper is NOT an official .NET Tradier Library. It's provided "as is" without expressed or implied warranty. Please use it at your own risk and discretion.
