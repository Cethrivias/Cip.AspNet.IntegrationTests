using Api.Requests;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISmsService, SmsService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost(
    "/user",
    (ISmsService smsService, [FromBody] PostUserRequest request) => smsService.Send(request.Number, $"Welcome, {request.FirstName}")
);


app.Run();

public partial class Program {}