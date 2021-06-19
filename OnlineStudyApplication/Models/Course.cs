using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudyApplication.Models
{
    public class Course
    {

        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string InstructorName { get; set; }

        public string InstructorEmail { get; set; }

        [Range (1,12)]
        public int CourseDuration { get; set; }

        // navigation property to child Study object
        public List<Study> Studies { get; set; }



    }
}
