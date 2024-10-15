using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var patchUrl = $"http://localhost:5504/odd/{MatchId}/{TeamId}/{BetValue}";
        
        var patchContent = new StringContent(
            string.Empty,
            Encoding.UTF8, 
            "application/json"
        );

        var response = await _client.PatchAsync(patchUrl, patchContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to update bet.");
        }
        var responseData = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<object>(responseData)!;
    }
}