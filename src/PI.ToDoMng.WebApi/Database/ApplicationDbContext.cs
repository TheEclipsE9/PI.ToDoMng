using Microsoft.EntityFrameworkCore;

namespace PI.ToDoMng.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
