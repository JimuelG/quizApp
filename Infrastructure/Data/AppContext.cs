using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }

}
