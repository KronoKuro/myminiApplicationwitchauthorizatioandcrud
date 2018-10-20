using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp2.Map
{
    public class NewsConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("News");
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).IsRequired(true).HasMaxLength(32);

            builder.Property(p => p.Title).IsRequired(true).HasMaxLength(255);

            builder.Property(p => p.Text).IsRequired().HasMaxLength(3000);
            builder.Property(p => p.DatePost).IsRequired(true).HasColumnType("date");
        }
    }
}
