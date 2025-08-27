public class ReviewResponse
    {
        public string Sentiment { get; set; }
        public ConfidenceScores Scores { get; set; }
        public string[] KeyPhrases { get; set; }
        public string RedactedText { get; set; }
    }

    public class ConfidenceScores
    {
        public double Positive { get; set; }
        public double Neutral { get; set; }
        public double Negative { get; set; }
    }