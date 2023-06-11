using System.Text.Json;
using System.Text.Json.Serialization;

[JsonConverter(typeof(RequestErrorConverter))]
public class RequestError
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    [JsonPropertyName("code")]
    public int ErrorCode { get; set; }
    [JsonPropertyName("data")]
    public IEnumerable<string>? Reasons { get; set; }
}

public class RequestErrorConverter : JsonConverter<RequestError>
{
    public override RequestError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        JsonElement root = doc.RootElement.GetProperty("error");

        RequestError error = new RequestError();
        error.Message = root.GetProperty("message").GetString();
        error.ErrorCode = root.GetProperty("code").GetInt32();
        // TODO: create handler specific message
        return error;
    }

    public override void Write(Utf8JsonWriter writer, RequestError value, JsonSerializerOptions options)
    {
        // Does not need write
        throw new NotImplementedException();
    }
}

