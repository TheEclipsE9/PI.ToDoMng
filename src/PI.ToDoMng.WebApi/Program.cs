using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PI.ToDoMng.WebApi;
using PI.ToDoMng.WebApi.Database;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString(ToDoMngConstants.Database.TODOMNG_CON_STR_KEY);
if (string.IsNullOrEmpty(conStr))
    throw new InvalidOperationException($"Connection string '{ToDoMngConstants.Database.TODOMNG_CON_STR_KEY}' not found or empty.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conStr, msSqlOptions =>
    {
        var timeOut = TimeSpan.FromSeconds(30).Seconds;
        msSqlOptions.CommandTimeout(timeOut);
    }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    // Seed data
    DbInitializer.Seed(dbContext);
}

app.MapGet("/todoitems", (ApplicationDbContext db) =>
{
    var todoitems = db.ToDoItems.ToList();


    return todoitems;
});

app.Run();
