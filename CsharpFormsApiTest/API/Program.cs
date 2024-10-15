using API.Middleware;
using API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//UNCOMMENT TO ENABLE SWAGGER
//builder.Services.AddSwaggerGen();

builder.Services.AddLogger();
builder.Services.ConfigureServices();
builder.Services.AddContext();

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});


// UNCOMMENT TO ENABLE SWAGGER
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();

app.UseAuthorization();

//Middleware za hvatanje gresaka
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
