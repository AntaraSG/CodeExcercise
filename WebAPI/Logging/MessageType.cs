using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Logging
{
    public enum MessageType
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
        Off
    }
}