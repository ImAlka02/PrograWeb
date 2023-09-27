var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); //Activar patron MVC para mi app web

var app = builder.Build();


//Mapping o routing: Asociar una URI con un Endpoint
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/saludame", () => "Ola");

//Mapeo con MVC
app.MapDefaultControllerRoute();

app.Run();
