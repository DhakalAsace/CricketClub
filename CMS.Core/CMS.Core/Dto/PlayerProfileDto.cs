using CMS.Core.Entity;
using CMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Dto
{
   public class PlayerProfileDto
    {
        [Key]
        public long player_profile_id { get; set; }

        
        [Display(Name = "Full Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please write the name")]
        public string name { get; set; }
        [Display(Name = "Birth Place")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please write the birth place")]
        public string birth_place { get; set; }
        [Display(Name = "Height")]
        public string height { get; set; }
        [Display(Name = "Contact")]
        public string contact { get; set; }
        [Display(Name = "Facebook Url")]
        public string fb_url { get; set; }
        [Display(Name = "Twitter")]
        public string web_url { get; set; }
        [Display(Name = "Instagram")]
        public string youtube_url { get; set; }
        public Role role { get; set; }
      
        [Display(Name ="Gender")]
        public Enums.PlayerProfile playerProfile { get; set; }

        [Display(Name = "Status")]
        public Enums.Status status { get; set; }

        [Display(Name = "Carrier Information")]
        public string carrier_info { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Image")]
        public string image { get; set; }
        [Display(Name = "Status")]
        public bool is_enabled { get; set; } = true;

        public string slug { get; set; }

    }
}
