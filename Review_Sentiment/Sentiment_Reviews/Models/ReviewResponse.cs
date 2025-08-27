using Azure.AI.TextAnalytics;

namespace sentiment_reviews.Models;

public class ReviewResponse
{
    public string Sentiment { get; set; } = string.Empty;

    public SentimentScores Scores { get; set; }

    public string[] KeyPhrases { get; set; } = [];

    public string RedactedText { get; set; } = string.Empty;
}

public class SentimentScores
{
    public double Positive { get; set; }
    public double Neutral { get; set; }
    public double Negative { get; set; }
}