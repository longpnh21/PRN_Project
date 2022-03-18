using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> entity)
        {
            entity.ToTable("Club");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.UniId, "IX_Club_UniId");

            entity.Property(e => e.AvatarUrl)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ClubName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);


            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(400);

            entity.Property(e => e.EstablishedDate).HasColumnType("date");

            entity.Property(e => e.ShortDescription)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(100);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(10);

            entity.Property(e => e.Slogan)
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.HasOne(d => d.Uni)
                .WithMany(p => p.Clubs)
                .HasForeignKey(d => d.UniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Club_University");
        }
    }
}
