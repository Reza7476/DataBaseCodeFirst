using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaavDataBaseCodeFirst.Entities;

namespace TaavDataBaseCodeFirst.Mapping.Students;
public class StudentMapper : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(s => s.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(s => s.Group)
            .WithMany(s => s.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);




        //builder.HasOne(s => s.Profile)
        //    .WithOne(p => p.Student)
        //    .HasForeignKey<Profile>(p => p.StudentId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(s => s.Grade)
        //    .WithMany(g => g.students)
        //    .HasForeignKey(s => s.GradeId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
