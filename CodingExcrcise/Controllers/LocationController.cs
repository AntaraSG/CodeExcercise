using CodingExcrcise.Models;
using CodingExcrcise.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingExcrcise.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pollution(Location model)
        {
            Pollution cp = new Pollution();
            try
            {
                cp = locationRepository.GetCityPolution(model, DateTime.Now);
                if (cp != null)
                    return View(cp);
            }
            catch (Exception ex)
            {
            }
            return View(cp);
        }

        public ActionResult CityList()
        {
            IList<Location> cities = locationRepository.GetCityListFromCSV();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}