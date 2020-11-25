using CodingExcrcise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExcrcise.Repository
{
    public interface ILocationRepository
    {
        Pollution GetCityPolution(Location city, DateTime dateTime);

        IList<Location> GetCityListFromCSV();
    }
}