

using Microsoft.Identity.Client;
using TaavDataBaseCodeFirst;
using TaavDataBaseCodeFirst.Entities;

while (true)
{
    try
    {
        int run = Operation.Run();
        switch (run)
        {
            case 0:
                {

                    Environment.Exit(0);
                    break;

                }

            case 1:
                {


                    var groupName = Operation.GetString("enter group name");
                    Operation.AddNewGroup(groupName);

                    break;
                }

            case 2:
                {

                    Operation.DisplayGroups();
                    break;
                }

            case 3:
                {
                    CreditType creditType;
                    var groupName = Operation.GetString("enter groupName");
                    var courseName = Operation.GetString("enter courseName");
                    var creditCourse = Operation.GetInteger("enter credit of course");
                    var getCreditType = Operation.GetInteger("select credit Type of course as below\n" +
                        "\t1:  tehorical\n" +
                        "\t2:  practical ");
                    if (getCreditType == 1)
                    {
                        creditType = CreditType.theorical;
                    }
                    else if (getCreditType == 2)
                    {

                        creditType = CreditType.practical;
                    }
                    else
                    {
                        throw new Exception("enter correct value");
                    }
                    Operation.AddNewCourse(courseName, creditCourse, creditType, groupName);


                    break;
                }
            case 4:
                {

                    Operation.DisplayCourses();
                    break;
                }
            case 5:
                {

                    Gender studentGender;
                    var studentName = Operation.GetString("enter student name");
                    var studentLastName = Operation.GetString("enter student last name");
                    var studentBirthDay = Operation.GetDateTime("enter student birth day in correct format (year/month/day:1999/11/2)");
                    var getGender = Operation.GetInteger("select student gender as bellow\n" +
                        "\t 1: male\n" +
                        "\t 2: female");
                    if (getGender == 1)
                    {

                        studentGender = Gender.male;
                    }
                    else if (getGender == 2)
                    {
                        studentGender = Gender.female;
                    }
                    else
                    {
                        throw new Exception("enter correct value");
                    }
                    var groupName = Operation.GetString("enter  student major ");
                    Operation.AddNewStudent(studentName, studentLastName, studentBirthDay, studentGender, groupName);
                    break;
                }
            case 6:
                {
                    Operation.DisplayStudent();
                    break;
                }
            case 7:
                {
                    var teacherName = Operation.GetString("enter teacher name");
                    var lastName = Operation.GetString("enter last name");
                    var personalCode = Operation.GetInteger("enter personal code");
                    var salary = Operation.GetDecimal("enter teacher salary");
                    var getGroupName = Operation.GetString("enter group name");

                    Operation.AddNewTeacher(teacherName, lastName, personalCode.ToString(), salary, getGroupName);

                    break;
                }



            case 8:
                {
                    Operation.DisplayTeachers();
                    break;
                }
            case 9:
                {

                    var teacherName = Operation.GetString("enter teacher's personal code");
                    var courseName = Operation.GetString("enter course name");
                    Operation.GiveCourseToTeacher(courseName, teacherName);
                    break;
                }

            case 10:
                {
                    var studentName = Operation.GetString("enter student name");
                    var courseName = Operation.GetString("enter course name");
                    Operation.GiveCourseToStudent(studentName, courseName);

                    break;
                }
        }

    }
    catch (Exception ex)
    {


        Operation.Error(ex.Message);
    }
}
