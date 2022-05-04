using AliexpressItemsParser;
using AliexpressItemsParser.Http;
using AliexpressItemsParser.Interfaces;
using AliexpressItemsParser.Selenium;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Use this line to use httpClient-based scraper
//builder.Services.AddScoped<IAliScraper, AliHttpScraper>();

//  TODO: Use this line to use selenium-based scraper
builder.Services.AddScoped<IAliScraper, AliSeleniumScraper>();

builder.Services.AddScoped<IAliParser, AliParser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();