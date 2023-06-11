using System.Text.Json.Serialization;

namespace SpaceTraderUI.Model;

public record Agent
{
    // This property will be used as RestAPI routing. AccountId is saft 
    // to be exposed because most API communication are done using Bearer Token.
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; } = String.Empty;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = String.Empty;

    [JsonPropertyName("headquarters")]
    public string Headquarters { get; set; } = String.Empty;

    [JsonPropertyName("credits")]
    public double Credits { get; set; }

    [JsonPropertyName("startingFaction")]
    public string StartingFaction { get; set; } = String.Empty;
}