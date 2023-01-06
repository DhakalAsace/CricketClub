using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Dto
{
    public class ServicesDto
    {
        public long service_id { get; set; }


        [Display(Name = "Service Category")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose a category")]
        public long service_category_id { get; set; }


        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title")]
        [MaxLength(60, ErrorMessage = "Title cannot be more than 60 letters.")]
         public string title { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        public string image_name { get; set; }
        public string image_name_two { get; set; }

        [Display(Name = "Status")]
        public bool is_enabled { get; set; } = true;



    }
}
