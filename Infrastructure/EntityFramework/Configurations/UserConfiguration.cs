using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName).HasMaxLength(50);

        builder.Ignore(x => x.FullName);
        
        builder.HasMany(x => x.Habits)
            .WithOne( x=> x.User)
            .HasForeignKey(x => x.UserId);
        

    }
}