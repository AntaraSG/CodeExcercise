using CodingExcrcise.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CodingExcrcise.Helper
{
    public static class ApiRequestHelper
    {
        public static object PostWebResponse(string method, string apiMethod)
        {
            try
            {                
                string _webRequestURL = string.Format("http://localhost/WEBAPI/{0}", apiMethod);

                WebRequest myWebRequest = WebRequest.Create(_webRequestURL);
                WebProxy myProxy = new WebProxy();
                myWebRequest.Proxy = myProxy;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "POST";
                myWebRequest.Timeout = 100000;

                HttpWebResponse myWebResponse = (HttpWebResponse)(myWebRequest.GetResponse());
                if (myWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    var encoding = ASCIIEncoding.UTF8;
                    using (var reader = new StreamReader(myWebResponse.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();

                        ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(responseText);
                        switch (response.ErrorCode)
                        {
                            case 0:
                                return response.Data;
                            case 2:
                                return null;
                            default:
                                throw new Exception(response.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(ex.Message);
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}