using CMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.ViewModels
{
    public class PlayersIndexViewModel
    {
        public List<PlayersDetail> players { get; set; }
    }
    public class PlayersDetail
    {
        public long player_profile_id { get; set; }




        public string name { get; set; }


        public string birth_place { get; set; }

        public string height { get; set; }

        public string contact { get; set; }
        [Display(Name = "Facebook Url")]
        public string fb_url { get; set; }
        [Display(Name = "Web Url")]
        public string web_url { get; set; }
        [Display(Name = "Youtube Url")]
        public string youtube_url { get; set; }

        public Role role { get; set; }
        [Display(Name="Batting Style")]
        public string batting_style { get; set; }
        [Display(Name = "Bowling Style")]

        public string bowling_style { get; set; }

        public Status status { get; set; }

        public string carrier_info { get; set; }

        public string description { get; set; }

        public string image { get; set; }

        public bool is_enabled { get; set; } = true;
        public CMS.Core.Enums.PlayerProfile playerProfile { get; set; }
        public string slug { get; set; }

    }
}
