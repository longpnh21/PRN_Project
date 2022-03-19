using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
        public void Configure(EntityTypeBuilder<MemberRole> entity)
        {
            entity.HasKey(e => new { e.MemberId, e.ClubPeriodId });

            entity.ToTable("MemberRole");

            entity.Property(e => e.MemberId).HasMaxLength(300);

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.ClubPeriod)
                .WithMany(p => p.MemberRoles)
                .HasForeignKey(d => d.ClubPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRole_ClubPeriod");

            entity.HasOne(d => d.Member)
                .WithMany(p => p.MemberRoles)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRole_AspNetUsers");
        }
    }
  
}
