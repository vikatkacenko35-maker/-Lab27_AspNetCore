using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привет от ИСП-231! Автор: Виктория Ткаченко");
app.MapGet("/about", () => "Это мой первый таукой сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");

app.Run();
