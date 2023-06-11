using System.Text.Json.Serialization;

namespace SpaceTraderUI.Model;

/// <summary>
/// This class is a wrapper for the response of SpaceTrader API.
/// Most json response looks like 
/// {
///     "data': { TargetObject }
/// }
/// So we need a wrapper
/// </summary>
/// <typeparam name="T">Target Type</typeparam>
public class HttpResponseWrapper<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}