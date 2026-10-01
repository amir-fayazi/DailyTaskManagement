using DailyTaskManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DailyTaskManagement.Infrastructure.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Tasks)
                 .WithOne(t => t.User)
                 .HasForeignKey(t => t.UserId);

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.HasIndex(u => u.Username)
                 .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            
        }
    }


}
