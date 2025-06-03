using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }
    }
}