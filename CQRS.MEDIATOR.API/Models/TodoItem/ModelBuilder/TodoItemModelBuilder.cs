using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.MEDIATOR.API.Models.TodoItem.ModelBuilder
{
    public class TodoItemModelBuilder : IEntityTypeConfiguration<Entity.TodoItem>
    {
        public void Configure(EntityTypeBuilder<Entity.TodoItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(t => t.IsComplete).HasDefaultValue(false);
            builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(t => t.Status);
            builder.Property(t => t.Status).IsRequired().HasMaxLength(50);
            builder.Property(t => t.DueDate).IsRequired(false);
            builder.Property(t => t.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(t => t.UpdatedAt).ValueGeneratedOnUpdate();
            builder.Property(t => t.Rowguid).IsRequired().HasDefaultValueSql("NEWID()").HasMaxLength(35);
        }
    }
}