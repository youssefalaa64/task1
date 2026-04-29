using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ormtask.models
{
    public class HomeWork
    {
        public int HomeWorkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        //
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }




    }
    public enum ContentType
    {
        Application,
        Pdg,
        Zip
        
    }
}
