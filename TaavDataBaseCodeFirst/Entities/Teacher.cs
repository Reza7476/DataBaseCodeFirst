namespace TaavDataBaseCodeFirst;

public class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public DateTime RegisterDate { get; set; }

    public string PersonalCode { get; set; }

    public decimal Salary { get; set; }

    public int GroupId { get; set; }

    public Group Group { get; set; }

    public HashSet<TeacherCourse> TeacherCourses { get; set; }

}
