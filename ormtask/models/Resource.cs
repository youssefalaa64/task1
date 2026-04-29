using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;
using System.Text;

namespace ormtask.models

{
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Unicode(true)]
        public string Name { get; set; }
        [Unicode(true)]
        public string Url { get; set; }
      
        public ResourceType ResourceType  { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }


    }
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
}
