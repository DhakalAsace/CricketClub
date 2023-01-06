using CMS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Core.ViewModels
{

    public class PictureIndexViewModel
    {
        public List<PictureDetailModel> picture_details { get; set; }
    }

    public class PictureDetailModel
    {
        public long picture_id { get; set; }


        [Display(Name = "Image")]
        public string image_name { get; set; }



        [Display(Name = "Image1")]
        public string image1 { get; set; }
        [Display(Name = "Image2")]
        public string image2 { get; set; }
        [Display(Name = "Image3")]
        public string image3 { get; set; }
        [Display(Name = "Image4")]
        public string image4 { get; set; }
        [Display(Name = "Image5")]
        public string image5 { get; set; }



        [Display(Name = "Status")]
        public bool is_enabled { get; set; } = true;
        [Display(Name = "Slider")]
        public bool is_slider_image { get; set; } = false;
        [Display(Name = "Male")]
        public bool is_male { get; set; } = false;
        [Display(Name = "Female")]
        public bool is_female { get; set; } = false;
        [Display(Name = "Name")]
        public string title { get; set; }

        public void enable()
        {
            is_enabled = true;
        }

        public void disable()
        {
            is_enabled = false;
        }

        public void markSliderImage()
        {
            is_slider_image = true;
        }

        public void removeFromSliderImage()
        {
            is_slider_image = false;
        }

        public void makeMale()
        {
            is_male = true;
        }
        public void unmakeMale()
        {
            is_male = false;
        }
        public void makefemale()
        {
            is_female = true;
        }
        public void unmakefemale()
        {
            is_female = false;
        }
        public string slug { get; set; }
    }
}
