using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.ToTable("Department");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.UniId, "IX_Department_UniId");

            entity.Property(e => e.DepName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(256);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .HasMaxLength(10)
                .IsFixedLength(false);

            entity.HasOne(d => d.University)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.UniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_University");
        }
    }
}
