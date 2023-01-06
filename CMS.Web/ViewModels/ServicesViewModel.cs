using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.ViewModels
{
    public class ServicesViewModel
    {
        public List<ServicesDetail> products { get; set; }
    }
    public class ServicesDetail
    {
        public long service_id { get; set; }
        public long service_category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image_name { get; set; }
    }
}
