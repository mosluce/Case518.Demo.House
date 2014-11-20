using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Case518.Demo.House.Models;

namespace Case518.Demo.House.Controllers.WebAPI
{
    public class CitiesController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            using (var db = new HouseModel())
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Success = true,
                    Data = db.Cities.Include("Regions").ToList()
                });
            }
        }
    }
}
