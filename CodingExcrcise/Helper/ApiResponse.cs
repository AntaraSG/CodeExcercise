using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Helper
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}