namespace TaavDataBaseCodeFirst.Entities;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }


    public int GroupId { get; set; }
    public Group Group { get; set; }

         
   public HashSet<StudentCourse> StudentCourses { get; set; }
}
