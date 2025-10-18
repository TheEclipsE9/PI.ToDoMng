using Microsoft.EntityFrameworkCore;
using PI.ToDoMng.WebApi.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration
                        .GetConnectionString("mysqldb") ?? throw new InvalidOperationException("Connection string 'mysqldb' not found.")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
