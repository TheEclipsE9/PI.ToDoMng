using Microsoft.EntityFrameworkCore;
using PI.ToDoMng.WebApi;
using PI.ToDoMng.WebApi.Database;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString(ToDoMngConstants.Database.TODOMNG_CON_STR_KEY);
if (string.IsNullOrEmpty(conStr))
    throw new InvalidOperationException($"Connection string '{ToDoMngConstants.Database.TODOMNG_CON_STR_KEY}' not found or empty.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(conStr, mySqlOptions =>
    {
        var timeOut = TimeSpan.FromSeconds(30).Seconds;
        mySqlOptions.CommandTimeout(timeOut);
    }));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
