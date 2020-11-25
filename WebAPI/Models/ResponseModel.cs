using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace WebAPI.Models
{
    public class ResponseModel
    {
        public object Data { get; private set; }
        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ResponseModel(object returnObj, APIExceptions exception)
        {
            Data = returnObj;
            ErrorCode = getErrorCode(exception);
            ErrorMessage = exception != null ? exception.Message : string.Empty;
        }
        private int getErrorCode(APIExceptions exception)
        {
            return exception != null ? Convert.ToInt32(exception.ErrorCode) : 0;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public HttpResponseMessage toJsonMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(
                        JsonConvert.SerializeObject(this),
                        Encoding.UTF8,
                        "application/json"
                    )
            };

            return response;
        }
    }
}
