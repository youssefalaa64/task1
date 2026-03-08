 using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace tasks_studentmanager
{
    class StudentManager
    {
        public List<Course> courses { get; set; }
        public List<Student> students { get; set; }
        public List<Instructor> instructors { get; set; }

        public StudentManager()
        {
            courses = new List<Course>();
            students = new List<Student>();
            instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (studentId == students[i].StudentId)
                    return students[i];
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructorId == instructors[i].InstructortId)
                    return instructors[i];
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courseId == courses[i].CourseId)
                    return courses[i];
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
                return student.Enroll(course);
            return false;
        }

        public bool UpdateStudent(int studentId, string newName, int newAge)
        {
            Student student = FindStudent(studentId);
            if (student == null) return false;
            student.Name = newName;
            student.Age = newAge;
            return true;
        }

        public bool DeleteStudent(int studentId)
        {
            Student student = FindStudent(studentId);
            if (student == null) return false;
            return students.Remove(student);
        }

        public List<Student> FindStudentsByName(string name)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name)
                    result.Add(students[i]);
            }
            return result;
        }
    }

    class Student
    {
        public Student(int studentId, string name, int age, List<Course> courses)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            this.courses = courses;
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> courses { get; set; }

        public bool Enroll(Course course)
        {
            courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return $"students name is {Name} \nstudents id is {StudentId} \nstudents age is {Age}";
        }
    }

    class Instructor
    {
        public Instructor(int instructortId, string name, string specialization)
        {
            InstructortId = instructortId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructortId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return $"instructors name is {Name} \ninstructors id is {InstructortId} \ninstructors specialization is {Specialization}";
        }
    }

    class Course
    {
        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            
            return $"courses title is {Title} \ncourses id is {CourseId} \ncourses instructor is {Instructor.Name}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool exit = false;

            while (!exit)
            {
                
                Console.WriteLine("1- Add Student");
                Console.WriteLine("2- Add Instructor");
                Console.WriteLine("3- Add Course");
                Console.WriteLine("4- Enroll Student in Course");
                Console.WriteLine("5- Show All Students");
                Console.WriteLine("6- Show All Courses");
                Console.WriteLine("7- Show All Instructors");
                Console.WriteLine("8- Find the student by id or name");
                Console.WriteLine("9- Find the course");
                Console.WriteLine("10- Exit");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(manager);
                        break;
                    case "2": AddInstructor(manager);
                        break;
                    case "3": AddCourse(manager);
                        break;
                    case "4": EnrollStudent(manager); 
                        break;
                    case "5": ShowAllStudents(manager);
                        break;
                    case "6": ShowAllCourses(manager);
                        break;
                    case "7": ShowAllInstructors(manager);
                        break;
                    case "8": FindStudentMenu(manager);
                        break;
                    case "9": FindCourseMenu(manager);
                        break;
                    case "10": exit = true;
                        break;
                    default: Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        static void AddStudent(StudentManager manager)
        {
            Console.Write("enter Students ID ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter students Name: ");
            string name = Console.ReadLine();
            Console.Write("enter students Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Student student = new Student(id, name, age, new List<Course>());
            manager.AddStudent(student);
        }

        static void AddInstructor(StudentManager manager)
        {
            Console.Write("enter instructors ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter instructors name: ");
            string name = Console.ReadLine();
            Console.Write("enter instructors Specialization: ");
            string spec = Console.ReadLine();

            Instructor instructor = new Instructor(id, name, spec);
            manager.AddInstructor(instructor);
        }

        static void AddCourse(StudentManager manager)
        {
            Console.Write("enter Courses ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter Courses Title: ");
            string title = Console.ReadLine();

            Console.Write("enter Instructor ID for this course: ");
            int instructorId = Convert.ToInt32(Console.ReadLine());
            Instructor instructor = manager.FindInstructor(instructorId);
            if (instructor == null) return;

            Course course = new Course(id, title, instructor);
            manager.AddCourse(course);
        }

        static void EnrollStudent(StudentManager manager)
        {
            Console.Write("enter students ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter courses ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            manager.EnrollStudentInCourse(studentId, courseId);
        }

        static void ShowAllStudents(StudentManager manager)
        {
            for (int i = 0; i < manager.students.Count; i++)
            {
                Console.WriteLine(manager.students[i].PrintDetails());
            }
        }

        static void ShowAllCourses(StudentManager manager)
        {
            for (int i = 0; i < manager.courses.Count; i++)
            {
                Console.WriteLine(manager.courses[i].PrintDetails());
            }
        }

        static void ShowAllInstructors(StudentManager manager)
        { 
            for (int i = 0; i < manager.instructors.Count; i++)
            {
                Console.WriteLine(manager.instructors[i].PrintDetails());
            }
        }

        static void FindStudentMenu(StudentManager manager)
        {
            Console.WriteLine("Search by: 1-ID  2-Name  ");
            string x = Console.ReadLine();
            if (x == "1")
            {
                Console.Write("enter student ID  ");
                int id = Convert.ToInt32(Console.ReadLine());
                Student student = manager.FindStudent(id);
                if (student != null)
                    Console.WriteLine(student.PrintDetails());
            }
            else if (x == "2")
            {
                Console.Write("enter name  ");
                string name = Console.ReadLine();
                List<Student> students = manager.FindStudentsByName(name);
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine(students[i].PrintDetails());
                }
            }
        }

        static void UpdateStudent(StudentManager manager, Student student)
        {
            Console.Write("enter new name  ");
            string newName = Console.ReadLine();
            Console.Write("enter new age  ");
            int newAge = Convert.ToInt32(Console.ReadLine());

            manager.UpdateStudent(student.StudentId, newName, newAge);
        }

        static void FindCourseMenu(StudentManager manager)
        {
            Console.Write("enter courses ID  ");
            int id = Convert.ToInt32(Console.ReadLine());
            Course course = manager.FindCourse(id);
            if (course != null)
                Console.WriteLine(course.PrintDetails());
        }
    }
}