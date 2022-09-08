using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class HabitConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.ToTable("Habits");
        
        builder.HasKey(x => x.Id);
 
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Habits).HasForeignKey(x => x.UserId);
    }
}