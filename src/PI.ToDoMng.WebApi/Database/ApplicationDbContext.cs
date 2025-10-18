using Microsoft.EntityFrameworkCore;

namespace PI.ToDoMng.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
