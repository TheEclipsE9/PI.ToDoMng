using Microsoft.EntityFrameworkCore;

namespace PI.ToDoMng.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<ToDoItem> Tasks => Set<ToDoItem>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
