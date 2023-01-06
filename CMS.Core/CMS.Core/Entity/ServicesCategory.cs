using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Entity
{
   public class ServicesCategory
    {
        [Key] 
        public long service_category_id { get; set; }

        [Required]
        [MaxLength(60)]
        public string title { get; set; }
        [Required]
        [MaxLength(70)]
        public string slug { get; set; }
        public bool is_enabled { get; set; } = true;
        public virtual List< Services > services { get; set; }
        public bool hasServices() => services.Count > 0;
        public void enable()
        {
            this.is_enabled = true;
            services.ForEach(c => c.is_enabled = true);
        }

        public void disable()
        {
            this.is_enabled = false;
            services.ForEach(c => c.is_enabled = false);
        }










    }
}
