using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using SpaceTraderUI.Model;

[Trait("type", "account")]
[Collection("bearer")]
public class AccountTest
{
    public AccountTest(BearerFixture fixture)
    {
        AgentToken = fixture.AgentToken;
    }

    [Fact]
    public async void RegistAgent()
    {
        var agentSymbol = RandomSymbol(12);

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, SpaceTraderAPI.RegistAgent);
        object content = new
        {
            Symbol = agentSymbol,
            Faction = "COSMIC",
        };

        request.Content = new StringContent(JsonSerializer.Serialize<object>(content, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        }), Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

        using (var response = await HttpClient.SendAsync(request).ConfigureAwait(false))
        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
        {
            HttpResponseWrapper<Account> wrapper = JsonSerializer.Deserialize<HttpResponseWrapper<Account>>(responseStream);
            Account account = wrapper.Data;
            Agent agent = account.Agent;

            Assert.NotNull(agent);
            Assert.False(String.IsNullOrEmpty(account.Token));
            Assert.False(String.IsNullOrEmpty(agent.AccountId));
            Assert.False(String.IsNullOrEmpty(agent.Symbol));
            Assert.False(String.IsNullOrEmpty(agent.Headquarters));
            Assert.False(String.IsNullOrEmpty(agent.StartingFaction));
            // also check there is one
            Assert.True(account.Ships.Count > 0);
            Assert.Equal($"{agentSymbol}-1", account.Ships[0].Symbol);
        }
    }

    // [Fact]
    public void RegistAgentFail()
    {
        // HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, SpaceTraderAPI.RegistAgent);
        // object content = new
        // {
        //     Symbol = "Dawnbringer",
        //     Faction = "COSMIC",
        // };

        // message.Content = new StringContent(JsonSerializer.Serialize<object>(content, new JsonSerializerOptions
        // {
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //     WriteIndented = true
        // }), Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

        // var client = new HttpClient();
        // var responseStream = client.Send(message).Content.ReadAsStream();
    }

    // [Fact]
    [Fact(Skip = "1")]
    public async void LoadAgent()
    {
        // double check auth token is not empty.
        Assert.False(String.IsNullOrEmpty(AgentToken));

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, SpaceTraderAPI.MyAgent);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AgentToken);


        using (var response = await HttpClient.SendAsync(request).ConfigureAwait(false))
        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
        {
            HttpResponseWrapper<Agent> wrapper = JsonSerializer.Deserialize<HttpResponseWrapper<Agent>>(responseStream)!;

            Agent account = wrapper.Data!;
            Assert.NotNull(account!.AccountId);
            Assert.NotNull(account.Symbol);
            Assert.NotNull(account.StartingFaction);
        }
    }

    // setup earlier
    private string AgentToken = String.Empty;

    private HttpClient HttpClient = new HttpClient();

    private static string RandomSymbol(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}