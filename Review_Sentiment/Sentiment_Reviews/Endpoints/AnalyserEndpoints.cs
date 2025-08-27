using sentiment_reviews.Models;
using sentiment_reviews.Services;
using Sentiment_Reviews.Models;

namespace Sentiment_Reviews.Endpoints;

public static class AnalyserEndpoints
{

    public static void MapAnalyserEndpoints(this WebApplication app)
    {
        app.MapPost("/analyse/Sentiment", AnalyseSentiment);
    }

    private static async Task<IResult> AnalyseSentiment(ReviewRequest request, AnalyserService service)
    {
        try
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Request))
                return Results.BadRequest("Review request cannot be null or empty.");
                
            var result = await service.AnalyseSentiment(request);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
        
    }
}