using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class ClubPeriodConfiguration : IEntityTypeConfiguration<ClubPeriod>
    {
        public void Configure(EntityTypeBuilder<ClubPeriod> entity)
        {
            entity.ToTable("ClubPeriod");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ClubId, "IX_ClubPeriod_ClubId");


            entity.Property(e => e.EndDate).HasColumnType("date");

            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Club)
                .WithMany(p => p.ClubPeriods)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClubPeriod_Club");
        }
    }
}
