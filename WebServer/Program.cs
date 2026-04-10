using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    var method = context.Request.Method;
    var path = context.Request.Path;
    System.Console.WriteLine($" -> {method} {path}");
    await next(context);
});
app.MapGet("/", () => Results.Ok(new {
    Message = "ДОбро пожаловать!",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));
app.MapGet("/me", () => Results.Ok(new {
    Name = "Ткаченко Виктория",
    Group = "ИСп-231",
    Course = 3,
    Skills = new[] { "С", "з", "РЕ" }
}));
app.MapGet("/calc/{a}/{b}", (double a, double b) => Results.Ok(new {
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));

app.MapFallback(() => Results.NotFound(new {
    Error = "Иаршрут  не найден",
    Code = 404
}));
app.Run();
//record Product(int id, string Name, decimal Price, bool InStock);



// app.Use(async (context, next) =>
// {
//     System.Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
//     await next(context);
//     var key = context.Request.Query["key"];
//     if (key != "secret" || key == "")
//     {
//         context.Response.StatusCode = 401;
//         await context.Response.WriteAsync("Unauthorized: Invalid credentials.401");
//         System.Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");
//         return;
//     }else{    
//         System.Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");
// }
//     await next(context);
// });
// app.Use(async (context, next) =>
// {
//     context.Response.Headers.Append("X-Powered-By", "ASP.NET Core Lab27");
//     await next(context);
// });


// app.MapGet("/", () => "Привет от ИСП-231! Автор: Виктория Ткаченко");
// app.MapGet("/about", () => "Это мой первый такой сервер");

// app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

// app.MapGet("/hello/{name}", (string name) => $"Привет {name}!");

// app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");
// app.MapGet("/student", () => new
// {
//     Name = "Виктория ткаченко",
//     Group = "ИСп-231",
//     Year = 3,
//     IsActive = true
// });
// app.MapGet("/subjects", () => new[]
// {
//     "РПМ",
//     "РМП",
//     "ИСРПО",
//     "СП",
// });
// app.MapGet("/product/{id}", (int id) => new Product(
//     id: id,
//     Name: $"Товар #{id}",
//     Price: id * 99.99m,
//     InStock: id % 2 == 0
// ));

