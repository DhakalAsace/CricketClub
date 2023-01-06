using CMS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Entity
{
   public class Designing
    {
        private string _title;

        [Key]
        public long designing_id { get; set; }
        public string title
        {
            get => _title;
            set
            {
                if( string.IsNullOrWhiteSpace(value))
                {
                    throw new NonEmptyValueException("Title is Required");
                }
                _title = value;
            }
        }
        [Required]
        [MaxLength(60)]
        public string slug { get; set; }
        [MaxLength(70)]
        public string image_name { get; set; }
        [MaxLength(70)]
        public string image_name_two { get; set; }
        public string description { get; set; }
        public bool is_enabled { get; set; } = true;
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
