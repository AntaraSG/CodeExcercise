using CodingExcrcise.Helper;
using CodingExcrcise.Logging;
using CodingExcrcise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public Pollution GetCityPolution(Location city, DateTime dateTime)
        {
            try
            {
                string url = string.Format("CityPollution/{0}/{1}/{2}", city.Coordinate.Latitude, city.Coordinate.Longitude, Uri.EscapeUriString(dateTime.ToString("MM/dd/yyyy hh:mm:ss")));
                Logger.Instance.LogMessage(url, MessageType.Info);
                Pollution pollution = (Pollution)ApiRequestHelper.PostWebResponse("GET", url);
                return pollution;
            }
            catch(Exception e)
            {
                Logger.Instance.LogMessage(e.Message, MessageType.Error);
                return null;
            }
        }

        public IList<Location> GetCityListFromCSV()
        {
            string csvFile = @"myfile.csv";
            string[] lines = File.ReadAllLines(csvFile);

            return new List<Location>();
        }
    }
}