using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Models
{
    public class Coordinate
    {
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
    }
}