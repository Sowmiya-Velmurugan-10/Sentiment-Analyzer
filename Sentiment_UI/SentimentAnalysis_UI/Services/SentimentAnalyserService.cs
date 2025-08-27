using System.Net.Http.Json;

public class SentimentAnalyserService
{

    private readonly HttpClient _http;

    public SentimentAnalyserService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ReviewResponse?> AnalyzeAsync(string text)
    {
        var request = new ReviewRequest { Request = text };
        var response = await _http.PostAsJsonAsync("analyse/sentiment", request);
        return await response.Content.ReadFromJsonAsync<ReviewResponse>();
    }

}