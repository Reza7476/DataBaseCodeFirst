using TaavDataBaseCodeFirst.Entities;

namespace TaavDataBaseCodeFirst;

public class Group
{
    public Group(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public GroupManager GroupManager { get; set; }

    public HashSet<Student> Students { get; set; }

    public HashSet<Teacher> Teachers { get; set; }

    public HashSet<Course> Courses { get; set; }

}




