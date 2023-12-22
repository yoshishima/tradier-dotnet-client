using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents the root object for gain loss data.
/// </summary>
public class GainLossRootobject
{
    /// <summary>
    /// Gets or sets the GainLoss object.
    /// </summary>
    [JsonPropertyName("gainloss")]
    public GainLoss GainLoss { get; set; }
}

/// <summary>
/// Represents a gain loss report.
/// </summary>
public class GainLoss
{
    /// <summary>
    /// Gets or sets the list of closed positions.
    /// </summary>
    /// <value>
    /// The closed positions.
    /// </value>
    [JsonPropertyName("closed_position")]
    public List<ClosedPosition> ClosedPosition { get; set; }
}

/// <summary>
/// Represents a closed position in a trading system.
/// </summary>
public class ClosedPosition
{
    /// <summary>
    /// Gets or sets the close date.
    /// </summary>
    /// <value>
    /// The close date.
    /// </value>
    /// <remarks>
    /// This property represents the date when an event or activity is planned to be closed or completed.
    /// </remarks>
    [JsonPropertyName("close_date")]
    public DateTime CloseDate { get; set; }

    /// <summary>
    /// Gets or sets the cost value.
    /// </summary>
    /// <value>
    /// The cost value.
    /// </value>
    [JsonPropertyName("cost")]
    public float Cost { get; set; }

    /// <summary>
    /// Gets or sets the gain/loss for the property.
    /// </summary>
    /// <value>
    /// The gain/loss value.
    /// </value>
    [JsonPropertyName("gain_loss")]
    public float GainLoss { get; set; }

    /// <summary>
    /// Gets or sets the gain/loss percentage.
    /// </summary>
    /// <value>
    /// The gain/loss percentage.
    /// </value>
    [JsonPropertyName("gain_loss_percent")]
    public float GainLossPercent { get; set; }

    /// <summary>
    /// Gets or sets the open date of the property.
    /// </summary>
    /// <value>
    /// The open date of the property.
    /// </value>
    /// <remarks>
    /// This property is decorated with the <c>JsonPropertyName</c> attribute, which specifies the name of the corresponding JSON property.
    /// The value of this property is a <c>DateTime</c> object.
    /// </remarks>
    [JsonPropertyName("open_date")]
    public DateTime OpenDate { get; set; }

    /// <summary>
    /// Gets or sets the proceeds property.
    /// </summary>
    /// <value>
    /// The amount of proceeds.
    /// </value>
    [JsonPropertyName("proceeds")]
    public float Proceeds { get; set; }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    [JsonPropertyName("quantity")]
    public float Quantity { get; set; }

    /// <summary>
    /// Gets or sets the symbol.
    /// </summary>
    /// <value>
    /// The symbol.
    /// </value>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Gets or sets the term property.
    /// </summary>
    [JsonPropertyName("term")]
    public int Term { get; set; }
}
