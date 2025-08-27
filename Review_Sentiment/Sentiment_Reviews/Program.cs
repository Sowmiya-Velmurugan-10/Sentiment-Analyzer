using sentiment_reviews.Clients;
using sentiment_reviews.Services;
using Sentiment_Reviews.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DI
builder.Services.AddSingleton<AzureTextAnalyticsClient>();
builder.Services.AddSingleton<AnalyserService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7190", "https://localhost:5013", "http://localhost:5013")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapAnalyserEndpoints();
// var Azure_Language_Endpoint = builder.Configuration["Azure_Language_Endpoint"];
// var Azure_Language_Key = builder.Configuration["Azure_Language_Key"];


app.Run();
