using Azure.AI.TextAnalytics;
using Azure; // Add this for AzureKeyCredential

namespace sentiment_reviews.Clients;

public class AzureTextAnalyticsClient
{
    private readonly string _endpoint;
    private readonly string _apiKey;

    private TextAnalyticsClient _client;

    public AzureTextAnalyticsClient(IConfiguration configuration)
    {
        _endpoint = configuration["Azure_Language_Endpoint"];
        _apiKey = configuration["Azure_Language_Key"];

        if (string.IsNullOrWhiteSpace(_endpoint) || string.IsNullOrWhiteSpace(_apiKey))
            throw new ArgumentException("Azure Text Analytics configuration is missing or invalid.");
    }

    // Placeholder for methods to interact with Azure Text Analytics API
    public TextAnalyticsClient GetClient()
    {
        if (_client != null)
            return _client;

         _client = new TextAnalyticsClient(new Uri(_endpoint), new AzureKeyCredential(_apiKey));
        return _client;

    }
}