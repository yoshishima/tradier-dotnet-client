using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class GainLossRootobject
{
    [JsonPropertyName("gainloss")]
    public GainLoss GainLoss { get; set; }
}

public class GainLoss
{
    [JsonPropertyName("closed_position")]
    public List<ClosedPosition> ClosedPosition { get; set; }
}

public class ClosedPosition
{
    [JsonPropertyName("close_date")]
    public DateTime CloseDate { get; set; }

    [JsonPropertyName("cost")]
    public float Cost { get; set; }

    [JsonPropertyName("gain_loss")]
    public float GainLoss { get; set; }

    [JsonPropertyName("gain_loss_percent")]
    public float GainLossPercent { get; set; }

    [JsonPropertyName("open_date")]
    public DateTime OpenDate { get; set; }

    [JsonPropertyName("proceeds")]
    public float Proceeds { get; set; }

    [JsonPropertyName("quantity")]
    public float Quantity { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("term")]
    public int Term { get; set; }
}
