using TaavDataBaseCodeFirst.Entities;

namespace TaavDataBaseCodeFirst;

public class Course
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public int Credit { get; set; }
    public CreditType  CreditType { get; set; }




    public int  GroupId { get; set; }
    public Group Group  { get; set; }

    public HashSet<StudentCourse> StudentCourses { get; set; }
    public HashSet<TeacherCourse>  TeacherCourses { get; set; }
}
