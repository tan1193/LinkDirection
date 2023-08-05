using Microsoft.AspNetCore.Mvc;

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


//app.MapGet("/redirect", (string slug) =>
//{
//    if (slugDefinitions.TryGetValue(slug, out var slugInfo))
//    { }
//    string redirectUrl;
//    if (!string.IsNullOrEmpty(userLocation) && slugInfo.RegionUrls.TryGetValue(userLocation, out var regionUrl))
//    {
//        redirectUrl = regionUrl;
//    }
//    else
//    {
//        redirectUrl = slugInfo.DefaultUrl;
//    }

//    RedirectResult redirect = new RedirectResult("http://www.cnn.com", true);
//    return redirect;
//})
//.WithName("Redirect")
//.WithOpenApi();

app.Run();

