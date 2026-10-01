using DailyTaskManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DailyTaskManagement.Infrastructure.Data
{
    public class TaskConfiguration : IEntityTypeConfiguration<DailyTask>
    {
        public void Configure(EntityTypeBuilder<DailyTask> builder)
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
