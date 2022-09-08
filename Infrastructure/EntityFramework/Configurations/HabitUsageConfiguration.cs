using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class HabitUsageConfiguration : IEntityTypeConfiguration<HabitUsage>
{
    public void Configure(EntityTypeBuilder<HabitUsage> builder)
    {
        builder.ToTable("HabitUsages");
        
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Habit)
            .WithMany(x => x.Usages)
            .HasForeignKey(x => x.HabitId);

        builder.Property(x => x.Time)
            .HasDefaultValue(DateTime.UtcNow);
    }
}