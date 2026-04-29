using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ormtask.models
{
    public class Course
    {
        public int CourseId { get; set; }
        [MaxLength(50)]
        [Unicode(true)]
        public string Name{ get; set; }
        [Unicode(true)]
        public string? Description{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Price { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<HomeWork> HomeWork { get; set; }

    }
}
