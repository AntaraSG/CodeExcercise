using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        [Route("CityPollution/{latitude}/{longitude}/{dateTime}")]
        public HttpResponseMessage GetCityPollution(string latitude, string longitude, string dateTime)
        {
            try
            {
                WeatherManager record = new WeatherManager();
                
                HttpResponseMessage returnResponseModel = new ResponseModel(
                    record.GetCityPollution(latitude, latitude, dateTime), null).toJsonMessage();
                return returnResponseModel;
            }
            catch (APIExceptions ex)
            {
                return (new ResponseModel(string.Empty, ex)).toJsonMessage();
            }
        } 
    }
}
