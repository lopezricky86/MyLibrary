using System.Data.Common;
using System.Diagnostics;
using MyLibrary.Api.Data;
using MyLibrary.Api.Endpoints;
using MyLibrary.Api.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"G:\MyLibraryErrorLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

var connString = builder.Configuration.GetConnectionString("LibraryDB");
builder.Services.AddSqlServer<LibraryDBContext>(connString);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();


// Log unhandled exception
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Log.Error(ex.Message, ex);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });       
        Environment.Exit(1); 
    }
});

app.MapBooksEnpoints();
app.AuthorsEndpoints();


app.Run();
