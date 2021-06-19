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
        public string ChapterName { get; set; }

        [Required]
        public string ChapterDescription { get; set; }


        public string FileUpload { get; set; }

        // fk fields
        public int CourseId { get; set; }

        // navigation properties so we don't have to join
        public Course Course { get; set; }


    }
}
