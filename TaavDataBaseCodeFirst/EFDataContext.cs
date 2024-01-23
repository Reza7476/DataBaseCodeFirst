using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaavDataBaseCodeFirst.Entities;

namespace TaavDataBaseCodeFirst;
public class EFDataContext:DbContext
{


    public DbSet<Student> Students { get; set; }    
    public DbSet<Teacher> Teachers { get; set; } 
    public DbSet<Group> Groups { get; set; } 
    public DbSet<Course> Courses { get; set; } 
    public DbSet<StudentCourse> StudentCourses { get; set; } 
    public DbSet<TeacherCourse> TeacherCourses { get; set; } 
    public DbSet<GroupManager> GroupManagers { get; set; } 

    //public DbSet<StudentCource> StudentCources { get; set; } 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Data Source=DESKTOP-9PR0IFL\\SQLREZA;Initial Catalog=TaavDbCodeFirst_FluentAPI;Integrated Security=True");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
    }
}
