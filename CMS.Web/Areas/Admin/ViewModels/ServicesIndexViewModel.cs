using System.Collections.Generic;

namespace CMS.Web.Areas.Core.ViewModels
{
    public class ServicesIndexViewModel
    {
        public List<ServicesDetailModel> service_details { get; set; }
    }



public class ServicesDetailModel
{

    public long service_id { get; set; }
    public long service_category_id { get; set; }
    public string service_category_name { get; set; }

    public string title { get; set; }
    public string description { get; set; }
    public string image_name { get; set; }
    public string image_name_two { get; set; }

    public bool is_enabled { get; set; }


}
}

