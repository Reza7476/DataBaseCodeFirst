using Microsoft.EntityFrameworkCore;
using TaavDataBaseCodeFirst.Entities;

namespace TaavDataBaseCodeFirst;

public class Operation
{

    static EFDataContext db = new EFDataContext();



    public static int Run()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"0: Exit\n" +
            $"1: Add new Group\n" +
            $"2: Display Groups\n" +
            $"3: Add new Course\n" +
            $"4: Display Courses\n" +
            $"5: Add new Student\n" +
            $"6: Display Students\n" +
            $"7: Add new Teacher\n" +
            $"8: Display teachers\n" +
            $"9: Give course to teacher\n" +
            $"10: Give Course to student");
        Console.ResetColor();
        int result = int.Parse(Console.ReadLine()!);
        return result;
    }





    public static void GiveCourseToStudent(string studentName, string courseName)
    {
        var student = db.Students.FirstOrDefault(s => s.Name == studentName);
        if (student == null)
        {
            throw new Exception("student not registered");
        }

        var course = db.Courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
        {

            throw new Exception("course not defined");
        }
        StudentCourse studentCourse = new StudentCourse()
        {
            StudentId = student.Id,
            CourseId = course.Id,
        };
        db.Add(studentCourse);
        db.SaveChanges();
    }

    public static void DisplayStudent()
    {
        var students = db.Students
            .Include(x => x.Group)
            .ToList();

        Console.ForegroundColor= ConsoleColor.Green;
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}  {student.LastName} {student.RegisterDate.Year}   {student.BirthDay.Year}  {student.Gender} ");
            if (student.Group.Students.Count > 0)
            {
                Console.WriteLine($"{student.Group.Name}");
            }

            var courseId = db.StudentCourses.Where(x => x.StudentId == student.Id).Select(x=>x.CourseId).ToList();


            foreach (var item in courseId)
            {
                var course = db.Courses.First(x => x.Id == item);
                Console.WriteLine($"\t{course.Name} number Credit: {course.Credit}");
               
            }
            Console.WriteLine("------------");
        }
        Console.ResetColor();

    }
    public static void DisplayCourses()
    {
        var courses = db.Courses.Include(x => x.Group).ToList();

        foreach (var course in courses)
        {
            Console.WriteLine($"  {course.Name} {course.CreditType} {course.Credit}  {course.Group.Name}");
        }
    }


    public static void DisplayTeachers()
    {
        var teachers = db.Teachers
            .Include(x => x.Group)
            .ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"  {teacher.Name}  {teacher.LastName} {teacher.PersonalCode} {teacher.Group.Name}");

            var courseId = db.TeacherCourses.Where(x => x.TeacherId == teacher.Id).Select(x => x.CourseId).ToList();


            foreach (var item in courseId)
            {
                var course = db.Courses.First(x => x.Id == item);
                Console.WriteLine($"\t{course.Name}");
            }
            Console.WriteLine("------------------");
        }
        Console.ResetColor();
    }

    public static void GiveCourseToTeacher(string courseName, string teacherPeronalCode)
    {
        var course = db.Courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
        {
            throw new Exception("course not defined");
        }
        var teacher = db.Teachers.FirstOrDefault(t => t.PersonalCode == teacherPeronalCode);
        if (teacher == null)
        {
            throw new Exception("teacher not defined");
        }

        TeacherCourse teacherCourse = new TeacherCourse()
        {
            TeacherId = teacher.Id,
            CourseId = course.Id
        };
        db.Add(teacherCourse);
        db.SaveChanges();


    }


    public static void AddNewStudent(string studentName, string lastName, DateTime birthDate, Gender gender, string groupName)
    {
        var group = db.Groups.FirstOrDefault(x => x.Name == groupName);
        if (group == null)
        {

            throw new Exception("Group is not difind ");
        }
        else
        {
            var groupId = group.Id;


            var student = new Student()
            {
                Name = studentName,
                LastName = lastName,
                RegisterDate = DateTime.Now,
                BirthDay = birthDate,
                Gender = gender,
                GroupId = groupId
            };

            db.Add(student);
            db.SaveChanges();
        }
    }



    public static DateTime GetDateTime(string message)
    {
        Console.WriteLine(message);
        var value = DateTime.Parse(Console.ReadLine()!);
        return value;
    }
    public static int GetInteger(string message)
    {
        Console.WriteLine(message);
        int value = int.Parse(Console.ReadLine()!);
        return value;
    }


    public static decimal GetDecimal(string message)
    {
        Console.WriteLine(message);
        decimal value = decimal.Parse(Console.ReadLine()!);
        return value;
    }
    public static void AddNewCourse(string courseName, int credit, CreditType creditType, string groupName)
    {
        var group = db.Groups.FirstOrDefault(g => g.Name == groupName);
        if (group == null)
        {
            throw new Exception("Group is not difind ");
        }
        else
        {
            var groupId = group.Id;
            Course course = new Course
            {
                Name = courseName,
                Credit = credit,
                CreditType = creditType,
                GroupId = groupId
            };

            db.Add(course);
            db.SaveChanges();
        }


    }


    public static void AddNewTeacher(string teacherName, string lastName,
        string personalCode, decimal salary, string groupName)
    {
        var group = db.Groups.FirstOrDefault(g => g.Name == groupName);
        if (group == null)
        {
            throw new Exception("group  not defined");
        }


        Teacher newTeacher = new Teacher()
        {
            Name = teacherName,
            LastName = lastName,
            PersonalCode = personalCode,
            Salary = salary,
            RegisterDate = DateTime.Now,
            GroupId = group.Id
        };
        db.Add(newTeacher);
        db.SaveChanges();

    }
    public static void DisplayGroups()
    {
        var groups = db.Groups.ToList();
        foreach (var group in groups)
        {
            Console.WriteLine($" {group.Id} {group.Name}");
        }
    }

    public static void AddNewGroup(string groupName)
    {
        Group group = new Group(groupName);
        db.Groups.Add(group);
        db.SaveChanges();
    }
    public static string GetString(string message)
    {
        Console.WriteLine(message);

        string value = Console.ReadLine()!;
        return value;
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }



}
