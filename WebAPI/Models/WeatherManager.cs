using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebAPI.Models
{
    public class WeatherManager
    {
        public object GetCityPollution(string latitute, string longitute, string dateTime)
        {
            try
            {
                string apiKey = GetApiKey();
                string webRequestURL =
                    string.Format("http://api.openweathermap.org/pollution/v1/co/{0},{1}/{2}Z.json?appid={3}",
                    latitute, longitute, dateTime.ToString(), apiKey);
                WebResponse response = new WebResponse(webRequestURL);
                return response.GetWebResponse();
            }
            catch (APIExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new APIExceptions(ex);
            }
        }

        public string GetApiKey()
        {
            return "1234"; // Fake Api key
        }
    }
}