using Microsoft.EntityFrameworkCore;
using PI.ToDoMng.WebApi.Domain.Entities;

namespace PI.ToDoMng.WebApi.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
