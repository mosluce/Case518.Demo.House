using Case518.Demo.House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Case518.Demo.House.Controllers.WebAPI
{
    public class HouseController : ApiController
    {
        public bool Create(HouseCreateViewModel model)
        {
            using (var db = new HouseModel())
            {
                var region = db.Regions.FirstOrDefault(c => c.Id == model.RegionId);
                var city = db.Cities.FirstOrDefault(c => c.Regions.Any(d => d.Id == model.RegionId));
                var photo = db.Photos.FirstOrDefault();

                var house = new Models.House()
                {
                    Region = region,
                    City = city,
                    Ground = model.Ground,
                    Lat = model.Lat,
                    Lng = model.Lng,
                    Parking = model.Parking,
                    Photos = new List<Photo> { photo },
                    Price = model.Price
                };

                db.Houses.Add(house);
                db.SaveChanges();
            }

            return true;
        }
    }

    public class HouseCreateViewModel
    {
        public int RegionId { get; set; }
        public Parking Parking { get; set; }
        public int Price { get; set; }
        public int Ground { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
