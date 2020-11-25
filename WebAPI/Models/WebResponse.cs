using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
using System.Net;
using System.Text;
using WebAPI.Logging;
using WebAPI.Models;

namespace WebAPI
{
    public class WebResponse
    {
        string _webRequestURL { get; set; }

        public WebResponse(string url)
        {
            _webRequestURL = url;
        }
        public object GetWebResponse()
        {
            try
            {
                WebRequest myWebRequest = WebRequest.Create(_webRequestURL);
                WebProxy myProxy = new WebProxy();
                myWebRequest.Proxy = myProxy;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "GET";
                myWebRequest.Timeout = 100000;

                HttpWebResponse myWebResponse = (HttpWebResponse)(myWebRequest.GetResponse());
                if (myWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    var encoding = ASCIIEncoding.UTF8;
                    using (var reader = new StreamReader(myWebResponse.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();
                        ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(responseText);
                        if (response.cod == 200)
                            return response.data;
                        else
                            throw new Exception(response.message);
                    }
                }
            }
            catch(WebException e)
            {
                using (HttpWebResponse response = (HttpWebResponse)e.Response)
                {
                    throw new APIExceptions(e, response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}