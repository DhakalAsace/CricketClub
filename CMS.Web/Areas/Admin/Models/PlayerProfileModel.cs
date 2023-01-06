using CMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Areas.Core.Models
{
    public class PlayerProfileModel
    {
        
        public long player_profile_id { get; set; }


        [Display(Name = "Full Name")]
       
        public string name { get; set; }
        [Display(Name = "Birth Place")]
       
        public string birth_place { get; set; }
        [Display(Name = "Height")]
        public string height { get; set; }
        [Display(Name = "Contact")]
        public string contact { get; set; }
        [Display(Name = "Facebook Url")]
        public string fb_url { get; set; }
        [Display(Name = "Web Url")]
        public string web_url { get; set; }
        [Display(Name = "Youtube Url")]
        public string youtube_url { get; set; }
        [Display(Name = "Role")]
        public Role role { get; set; }
        [Display(Name = "Batting Style")]
        public string batting_style { get; set; }
        [Display(Name = "Bowling Style")]
        public string bowling_style { get; set; }
        [Display(Name = "Playing Status")]
        public Status status { get; set; }
        [Display(Name = "Carrier Information")]
        public string carrier_info { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Image")]
        public string image { get; set; }
        [Display(Name = "Status")]
        public bool is_enabled { get; set; } = true;
        public CMS.Core.Enums.PlayerProfile playerProfile { get; set; }

    }
}
