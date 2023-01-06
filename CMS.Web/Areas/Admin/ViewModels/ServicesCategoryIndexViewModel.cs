using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Admin.ViewModels
{
    public class ServicesCategoryIndexViewModel
    {
        public List<ServicesCategoryDetailModel> service_category_details { get; set; }
    }

    public class ServicesCategoryDetailModel
    {
        public long service_category_id { get; set; }
        public string title { get; set; }
        public bool is_enabled { get; set; }
        
    }
}
