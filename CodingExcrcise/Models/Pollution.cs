using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Models
{
    public class Pollution
    {
        [Display(Name = "Pollution Level")]
        string Level { get; set; }

        [Display(Name = "Air Quality Index")]
        int AQI { get; set; }

        [Display(Name = "City")]
        String City { get; set; }
    }
}