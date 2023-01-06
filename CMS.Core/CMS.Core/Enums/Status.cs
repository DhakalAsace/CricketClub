using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Enums
{
    public enum Status
    {
        [Display(Name = "Playing")]

        Playing = 1,

        [Display(Name = "Not Playing")]
        Not_Playing
    }
}
