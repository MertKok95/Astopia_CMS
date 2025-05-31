using Cms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Infrastructure.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(c => c.Id);

                    builder.HasOne(c => c.User)
                        .WithMany(u => u.Contents)
                        .HasForeignKey(c => c.User.Id)
                        .IsRequired();

                    builder.HasOne(c => c.Category)
                        .WithMany(cat => cat.Contents)
                        .HasForeignKey(c => c.CategoryId)
                        .IsRequired();

                    builder.HasMany(c => c.Variants)
                        .WithOne(v => v.Content)
                        .HasForeignKey(v => v.ContentId);
        }
    }
}
