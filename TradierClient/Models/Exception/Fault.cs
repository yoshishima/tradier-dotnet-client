using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Exception
{
    /// <summary>
    /// Represents a root object containing a Fault object.
    /// </summary>
    public class FaultRootobject
    {
        /// <summary>
        /// Gets or sets the Fault details.
        /// </summary>
        /// <value>
        /// The Fault details.
        /// </value>
        [JsonPropertyName("fault")] public Fault Fault { get; set; }
    }

    /// <summary>
    /// Represents a fault object.
    /// </summary>
    public class Fault
    {
        /// <summary>
        /// Gets or sets the fault string for an error response.
        /// </summary>
        [JsonPropertyName("faultstring")] public string FaultString { get; set; }

        /// <summary>
        /// Gets or sets the detail of the property.
        /// </summary>
        /// <value>
        /// The detail of the property.
        /// </value>
        [JsonPropertyName("detail")] public Detail Detail { get; set; }
    }

    /// <summary>
    /// Represents a class that includes error code details.
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonPropertyName("errorcode")] public string ErrorCode { get; set; }
    }
}