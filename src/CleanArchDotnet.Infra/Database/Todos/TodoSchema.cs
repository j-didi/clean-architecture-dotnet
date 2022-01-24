using CleanArchDotnet.Core.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchDotnet.Infra.Database.Todos;

public class TodoSchema: IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.Description).HasColumnType("varchar(255)").IsRequired();
        builder.Property(e => e.Status).IsRequired();
    }
}