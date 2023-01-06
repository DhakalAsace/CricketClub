using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Core.Models
{
    public class ServicesModel
    {
        public long service_id { get; set; }
        [Display(Name = "Category")]
        public long service_category_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Service title is required")]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Image")]
        public string image_name { get; set; }
        public string image_name_two { get; set; }

        [Display(Name = "Status")]
        public bool is_enabled { get; set; } = true;
    }
}
