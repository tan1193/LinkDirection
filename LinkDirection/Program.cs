using LinkDirection.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/redirect", (string slug) =>
{
    Dictionary<string, SlugInfo> slugDefinitions;
    string jsonFilePath = "link-definitions.json";
    string jsonContents = System.IO.File.ReadAllText(jsonFilePath);
    var linkDefinitions = JsonConvert.DeserializeObject<LinkDefinitions>(jsonContents);
    slugDefinitions = linkDefinitions.Slugs.ToDictionary(s => s.Slug);

    if (slugDefinitions.TryGetValue(slug, out var slugInfo))
    {
        string redirectUrl = slugInfo.DefaultUrl;
        Results.Redirect(redirectUrl);
    }

    return ;
})
.WithName("Redirect")
.WithOpenApi();

app.Run();

