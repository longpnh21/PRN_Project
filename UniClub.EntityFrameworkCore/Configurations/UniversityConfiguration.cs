using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> entity)
        {
            entity.ToTable("University");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.EstablishedDate).HasColumnType("date");

            entity.Property(e => e.LogoUrl)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(10);

            entity.Property(e => e.Slogan)
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.UniAddress)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.UniName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.UniPhone).HasMaxLength(20);

            entity.Property(e => e.Website).HasMaxLength(256);
        }
    }
}

