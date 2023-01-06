using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Dto
{
   public class ServicesCategoryDto
    {
        public long service_category_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title")]
        [MaxLength(60)]
        [Display(Name = "Title") ]
        public string title { get; set; }


        [Display(Name = "Status")]
        public bool is_enabled { get; set; }
        public List<ServicesDto> services { get; set; }

    }
}
