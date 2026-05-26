using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<NetworkService>();

var app = builder.Build();

app.MapControllers();
app.Run();


// Model
public record Book(int Id, string Title, string Author);