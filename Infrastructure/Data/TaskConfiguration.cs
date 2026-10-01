using DailyTaskManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DailyTaskManagement.Infrastructure.Data
{
    public class TaskConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.Property(t => t.Status)
                .HasConversion<int>();

            builder.Property(t => t.Priority)
                .HasConversion<int>();

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }


}
