using Case518.Demo.House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case518.Demo.House.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Editor()
        {
            using (var db = new HouseModel())
            {
                //取出縣市、行政區資料供給View使用
                var cities = db.Cities.Include("Regions").ToList();
                return View(cities);
            }
        }
    }
}