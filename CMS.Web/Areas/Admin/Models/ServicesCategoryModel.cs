using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Core.Models
{
    public class ServicesCategoryModel
    {
        public long service_category_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Service Category name is required")]
        [Display(Name = "Name")]
        public string title { get; set; }

        [Display(Name = "Status")]
        public bool is_enabled { get; set; }
    }
}
