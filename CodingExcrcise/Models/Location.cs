using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        public Coordinate Coordinate { get; set; }
    }
}