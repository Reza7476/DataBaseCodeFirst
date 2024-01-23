using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaavDataBaseCodeFirst;

public class StudentCourseMapper : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {

        builder.HasKey(s => new {s.StudentId, s.CourseId}); 


        builder.HasOne(s=>s.Student)
            .WithMany(s=>s.StudentCourses)
            .HasForeignKey(s=>s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(s => s.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}
