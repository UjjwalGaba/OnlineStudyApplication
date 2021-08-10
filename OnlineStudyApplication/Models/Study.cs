using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudyApplication.Models
{
    public class Study
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Chapter Name")]
        public string ChapterName { get; set; }

        [Required]
        [Display(Name = "Chapter Description")]
        [StringLength(50, MinimumLength = 45)]
        public string ChapterDescription { get; set; }

        [Display(Name = "Image")]
        public string FileUpload { get; set; }

        // fk fields
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        // navigation properties so we don't have to join
        
        public Course Course { get; set; }


    }
}
