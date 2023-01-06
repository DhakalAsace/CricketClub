using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entity
{
   public class Services
    {
        [Key]
        public long service_id { get; set; }
        [Required]
        public long service_category_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        public string description { get; set; }
        public bool is_enabled { get; set; } = true;
        [Required]
        [MaxLength(60)]
        public string slug { get; set; }
        [MaxLength(70)]
        public string image_name { get; set; }
        [MaxLength(70)]
        public string image_name_two { get; set; }
        [ForeignKey("service_category_id")]
        public virtual ServicesCategory service_category { get; set; }
        public void enable()
        {
            is_enabled = true;
        }

        public void disable()
        {
            is_enabled = false;
        }




    }
}
