using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ApiResponse
    {
        public object data { get; set; }
        public int cod { get; set; }
        public string message { get; set; }
    }
}