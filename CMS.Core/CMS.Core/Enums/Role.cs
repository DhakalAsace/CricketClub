using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Core.Enums
{
    public enum Role
    {
        [Display(Name = "Batsman")]
        Batsman = 1,
        [Display(Name = "Bowler")]
        Bowler,
        [Display(Name = "Bating All Rounder")]
        Batting_All_Rounder,
        [Display(Name = "Bowling All Rounder")]
        Bowling_All_Rounder
    }
}
