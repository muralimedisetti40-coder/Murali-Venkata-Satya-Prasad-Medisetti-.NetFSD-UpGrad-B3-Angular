using WebApplication9.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Logging (Console)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Use Global Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();