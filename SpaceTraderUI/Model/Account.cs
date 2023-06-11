using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpaceTraderUI.Model;

public class Account
{
    // A workaround to get over nullable warning. Object will not be used at all.
    private static Agent EmptyAgent = new();

    /// <summary>
    /// The Bearer token will be used for API communication. Each agent has unique a Token.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; } = String.Empty;

    /// <summary>
    /// Contains all details the agent. Agent.AccountId will be used for site routing.
    /// </summary>
    [JsonPropertyName("agent")]
    public Agent Agent { get; set; } = EmptyAgent;

    // [JsonPropertyName("contract")]
    // public List<Contract> Contracts { get; set; }

    [JsonPropertyName("faction")]
    public Faction Faction { get; set; } = Faction.EmptyFaction;

    [JsonPropertyName("ship")]
    [JsonConverter(typeof(ShipConverter))]
    public List<Ship> Ships { get; set; } = new();

    /// <summary>
    /// This converter is specifically used for NewAgent. Load Agent will handle parse in blazor.
    /// </summary>
    private class ShipConverter : JsonConverter<List<Ship>>
    {
        public override List<Ship>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonElement root = JsonElement.ParseValue(ref reader);
            var ship = JsonSerializer.Deserialize<Ship>(root);

            return new List<Ship>() { ship! };
        }

        public override void Write(Utf8JsonWriter writer, List<Ship> value, JsonSerializerOptions options)
        {
            // no write
            throw new NotImplementedException();
        }
    }
}