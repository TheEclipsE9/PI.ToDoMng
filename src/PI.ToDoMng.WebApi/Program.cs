using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PI.ToDoMng.WebApi;
using PI.ToDoMng.WebApi.Api.Endpoints;
using PI.ToDoMng.WebApi.Application.Services;
using PI.ToDoMng.WebApi.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString(ToDoMngConstants.Database.TODOMNG_CON_STR_KEY);
if (string.IsNullOrEmpty(conStr))
    throw new InvalidOperationException($"Connection string '{ToDoMngConstants.Database.TODOMNG_CON_STR_KEY}' not found or empty.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conStr, msSqlOptions =>
    {
        var timeOut = TimeSpan.FromSeconds(5).Seconds;
        msSqlOptions.CommandTimeout(timeOut);
    }));

builder.Services.AddScoped<AuthService>();

var app = builder.Build();

AuthEndpoints.Map(app);

app.Run();
