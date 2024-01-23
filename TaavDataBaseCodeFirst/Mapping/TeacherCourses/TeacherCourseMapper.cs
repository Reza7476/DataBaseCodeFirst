using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaavDataBaseCodeFirst;

public class TeacherCourseMapper : IEntityTypeConfiguration<TeacherCourse>
{
    public void Configure(EntityTypeBuilder<TeacherCourse> builder)
    {

        builder.HasKey(t => new { t.TeacherId, t.CourseId });

        builder.HasOne(t=>t.Teacher)
            .WithMany(t=>t.TeacherCourses)
            .HasForeignKey(t => t.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(t=>t.Course)
            .WithMany( c=>c.TeacherCourses)
            .HasForeignKey(t=>t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);  

    }
}
