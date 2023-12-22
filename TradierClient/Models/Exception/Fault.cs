using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Exception
{
    public class FaultRootobject
    {
        [JsonPropertyName("fault")] public Fault Fault { get; set; }
    }

    public class Fault
    {
        [JsonPropertyName("faultstring")] public string FaultString { get; set; }

        [JsonPropertyName("detail")] public Detail Detail { get; set; }
    }

    public class Detail
    {
        [JsonPropertyName("errorcode")] public string ErrorCode { get; set; }
    }
}