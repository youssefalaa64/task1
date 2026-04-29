using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ormtask.models
{
    public class Student
    {
        public int StudentId { get; set; }
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        [Unicode(false)]
        public int?  PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }

        public DateTime? BirthDay  {get; set;}
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<HomeWork> HomeWork { get; set; }

    }
}
