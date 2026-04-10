using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привет от ИСП-231! Автор: Виктория Ткаченко");
app.MapGet("/about", () => "Это мой первый такой сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");
app.MapGet("/student", () => new
{
    Name = "Виктория ткаченко",
    Group = "ИСп-231",
    Year = 3,
    IsActive = true
});
app.MapGet("/subjects", () => new[]
{
    "РПМ",
    "РМП",
    "ИСРПО",
    "СП",
});
app.MapGet("/product/{id}", (int id) => new Product(
    id: id,
    Name: $"Товар #{id}",
    Price: id * 99.99m,
    InStock: id % 2 == 0
));

app.Run();
record Product(int id, string Name, decimal Price, bool InStock);

