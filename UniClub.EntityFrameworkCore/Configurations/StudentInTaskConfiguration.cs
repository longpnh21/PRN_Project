using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore.Configurations
{
    internal class StudentInTaskConfiguration : IEntityTypeConfiguration<StudentInTask>
    {
        public void Configure(EntityTypeBuilder<StudentInTask> entity)
        {
            entity.HasKey(e => new { e.StudentId, e.TaskId });

            entity.ToTable("StudentInTask");

            entity.HasIndex(e => e.TaskId, "IX_StudentInTask_TaskId");

            entity.Property(e => e.StudentId).HasMaxLength(300);

            entity.Property(e => e.AssignedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.StudentInTasks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentInTask_Person");

            entity.HasOne(d => d.Task)
                .WithMany(p => p.StudentInTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentInTask_Task");
        }
    }
}
