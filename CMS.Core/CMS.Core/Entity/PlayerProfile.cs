using CMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CMS.Core.Entity
{
    public class PlayerProfile
    {
        [Key]
        public long player_profile_id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string birth_place { get; set; }
        [Required]
        public string height { get; set; }
        public string contact { get; set; }
        public string fb_url { get; set; }
        public string web_url { get; set; }
        public string youtube_url { get; set; }
        
       
        public Role role { get; set; }
     
       
        public Enums.PlayerProfile playerProfile { get; set; }
        public Enums.Status status { get; set; }
        public string carrier_info { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public bool is_enabled { get; set; } = true;
       
        public void enable()
        {
            is_enabled = true;
        }

        public void disable()
        {
            is_enabled = false;
        }

        public string slug { get; set; }

    }
    //public static class EnumExtensions
    //{
    //    public static string GetDisplayName(this Enum enumValue)
    //    {
    //        return enumValue.GetType()
    //            .GetMember(enumValue.ToString())
    //            .First()
    //            .GetCustomAttribute<DisplayAttribute>()
    //            .GetName();

    //    }
    //}
}
