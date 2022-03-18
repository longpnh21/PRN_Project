using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class ClubRoleConfiguration : IEntityTypeConfiguration<ClubRole>
    {
        public void Configure(EntityTypeBuilder<ClubRole> entity)
        {
            entity.ToTable("ClubRole");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ReportToRoleId, "IX_ClubRole_ReportToRoleId");



            entity.Property(e => e.Role)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(50);

            entity.HasOne(d => d.ReportToRole)
                .WithMany(p => p.InverseReportToRole)
                .HasForeignKey(d => d.ReportToRoleId)
                .HasConstraintName("FK_ClubRole_ClubRole");
        }
    }
}
