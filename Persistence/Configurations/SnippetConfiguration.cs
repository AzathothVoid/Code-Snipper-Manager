using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class SnippetConfiguration : IEntityTypeConfiguration<Snippet>
    {
        public void Configure(EntityTypeBuilder<Snippet> builder)
        {
            builder.ToTable("snippets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Language).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Tags);
            builder.Property(x => x.IsPublic).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

        }
    }
}
