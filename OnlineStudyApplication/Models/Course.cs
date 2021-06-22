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
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Display(Name = "Instructor Email")]
        public string InstructorEmail { get; set; }

        [Range (1,12)]
        [Display(Name = "Course Duration")]
        public int CourseDuration { get; set; }

        // navigation property to child Study object
        public List<Study> Studies { get; set; }



    }
}
