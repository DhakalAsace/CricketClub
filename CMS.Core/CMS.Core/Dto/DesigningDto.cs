using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Dto
{
   public class DesigningDto
    {

        [Key]
        public long designing_id { get; set; }
        [Display(Name = "Title")]

        public string title { get; set; }
       
        [Required]
        [MaxLength(60)]
        public string slug { get; set; }
        [MaxLength(70)]
        [Display(Name = "Image")]

        public string image_name { get; set; }
        [MaxLength(70)]
        [Display(Name = "Image")]

        public string image_name_two { get; set; }
        [Display(Name = "Description")]

        public string description { get; set; }
        public bool is_enabled { get; set; } = true;
       
    }
}

