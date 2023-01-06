using CMS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Core.Models
{
    public class PictureModel
    {
        public long picture_id { get; set; }

        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }



        public string image_name { get; set; }

        public bool is_enabled { get; set; } = true;

        public bool is_slider_image { get; set; } = false;
        public bool is_male { get; set; } = false;
        public bool is_female { get; set; } = false;

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
        public string title { get; set; }
        public string slug { get; set; }
    }
}
