using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp2.Models;

namespace WebApp2.Map
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).IsRequired(true).HasMaxLength(32);

            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(255);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(3000);
            builder.Property(p => p.ReleaseDate).IsRequired(true).HasColumnType("date");

        }
    }
}
