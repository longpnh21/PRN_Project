using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Event");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Description)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.EventName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(50);

            entity.Property(e => e.ImageUrl).HasMaxLength(256);

            entity.Property(e => e.Location)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.StartDate).HasColumnType("datetime");
        }
    }
}
