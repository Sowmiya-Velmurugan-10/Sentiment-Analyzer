using sentiment_reviews.Clients;
using sentiment_reviews.Models;
using Sentiment_Reviews.Models;

namespace sentiment_reviews.Services;

public class AnalyserService
{
    private readonly AzureTextAnalyticsClient _client;

    public AnalyserService(IConfiguration configuration)
    {
        _client = new AzureTextAnalyticsClient(configuration);
    }

    public async Task<ReviewResponse> AnalyseSentiment(ReviewRequest review)
    {
        if (review == null || string.IsNullOrWhiteSpace(review.Request))
            throw new ArgumentException("Review request cannot be null or empty."); 

        var client = _client.GetClient();

        var sentiment = await client.AnalyzeSentimentAsync(review.Request);
        var keyPhrases = await client.ExtractKeyPhrasesAsync(review.Request);
        var pii = await client.RecognizePiiEntitiesAsync(review.Request);

        return new ReviewResponse()
        {
            Sentiment = sentiment.Value.Sentiment.ToString(),
            Scores = new SentimentScores()
            {
                Positive = sentiment.Value.ConfidenceScores.Positive,
                Neutral = sentiment.Value.ConfidenceScores.Neutral,
                Negative = sentiment.Value.ConfidenceScores.Negative
            },
            KeyPhrases = keyPhrases.Value.ToArray(),
            RedactedText = pii.Value.RedactedText
        };
    }
}