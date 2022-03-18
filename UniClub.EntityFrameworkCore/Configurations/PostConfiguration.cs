using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("Post");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Title)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(100);

            entity.Property(e => e.Content)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(2000);

            entity.Property(e => e.ShortDescription)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(1000);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Person");
        }
    }
}
