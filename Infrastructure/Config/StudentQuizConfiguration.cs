using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class StudentQuizConfiguration : IEntityTypeConfiguration<StudentQuiz>
{
    public void Configure(EntityTypeBuilder<StudentQuiz> builder)
    {
        builder.Property(s => s.ScorePercentage).HasColumnType("decimal(18,2)");
    }
}
