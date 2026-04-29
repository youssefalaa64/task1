using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ormtask.models;

namespace ormtask.P01_StudentSystem
{
    public class P01_StudentSystemdbcontext :DbContext

    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;initial catalog=P01_StudentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }


    }

   

namespace P01_StudentSystem.Data
    {
        public static class DbInitializer
        {
            public static void Seed(P01_StudentSystemdbcontext context)
            {
                

               
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student { Name = "John Doe", RegisteredOn = DateTime.Now, BirthDay = new DateTime(1995, 5, 20) },
                        new Student { Name = "Jane Smith", RegisteredOn = DateTime.Now, PhoneNumber = 01234561589 }
                    );
                }

                
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course { Name = "C# DB Fundamentals", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Price = 100.00m },
                        new Course { Name = "EF Core Advanced", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(3), Price = 150.00m }
                    );
                }
                context.SaveChanges(); 

                
                if (!context.Resources.Any())
                {
                    var courseId = context.Courses.First().CourseId;
                    context.Resources.AddRange(
                        new Resource { Name = "Intro Video", Url = "http://course.com", ResourceType = ResourceType.Video, CourseId = courseId },
                        new Resource { Name = "Documentation", Url = "http://course.com", ResourceType = ResourceType.Document, CourseId = courseId }
                    );
                }

                
                if (!context.HomeWorks.Any())
                {
                    var studentId = context.Students.First().StudentId;
                    var courseId = context.Courses.First().CourseId;
                    context.HomeWorks.Add(new HomeWork
                    {
                        Content = "Task1_Final.zip",
                        ContentType = ContentType.Zip,
                        SubmissionTime = DateTime.Now,
                        StudentId = studentId,
                        CourseId = courseId
                    });
                }

                context.SaveChanges();
            }
        }
    }




}

