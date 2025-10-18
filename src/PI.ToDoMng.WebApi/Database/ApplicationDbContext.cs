using Microsoft.EntityFrameworkCore;

namespace PI.ToDoMng.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Database=ToDoMng;Username=admin;Password=admin", options =>
        {

        });
    }
}
