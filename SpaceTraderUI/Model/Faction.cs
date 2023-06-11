using System.Text.Json.Serialization;

public partial class Faction
{
    public static Faction EmptyFaction = new Faction();

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = String.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = String.Empty;

    [JsonPropertyName("headquarters")]
    public string Headquarters { get; set; } = String.Empty;

    [JsonPropertyName("traits")]
    public List<Trait> Traits { get; set; } = new();

    [JsonPropertyName("isRecruiting")]
    public bool IsRecruiting { get; set; } = false;
}

public partial class Trait
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = String.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = String.Empty;
}