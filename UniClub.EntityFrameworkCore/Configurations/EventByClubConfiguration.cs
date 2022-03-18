using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class EventByClubConfiguration : IEntityTypeConfiguration<EventByClub>
    {
        public void Configure(EntityTypeBuilder<EventByClub> entity)
        {
            entity.HasKey(e => new { e.ClubId, e.EventId });

            entity.ToTable("EventByClub");

            entity.HasOne(d => d.Club)
                .WithMany(p => p.EventByClubs)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventByClub_Club");

            entity.HasOne(d => d.Event)
                .WithMany(p => p.EventByClubs)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventByClub_Event");
        }
    }
}
