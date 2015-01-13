using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Case518.Demo.House.Models;
using Case518.Demo.House.ViewModels;
using System.Web.Configuration;

namespace Case518.Demo.House.Controllers
{
    public class HomeController : Controller
    {
        #region 初始化資料

        public static void InitData()
        {
            using (var db = new HouseModel())
            {
                #region 初始化地區資料

                if (!db.Regions.Any())
                {
                    db.Cities.Add(new City
                    {
                        Name = "台北市",
                        Regions = new List<Region>
                        {
                            new Region("信義區"),
                            new Region("大安區"),
                            new Region("文山區")
                        }
                    });

                    db.Cities.Add(new City
                    {
                        Name = "高雄市",
                        Regions = new List<Region>
                        {
                            new Region("鼓山區"),
                            new Region("新興區"),
                            new Region("苓雅區")
                        }
                    });

                    db.SaveChanges();
                }

                #endregion

                #region 初始化照片資料
                if (!db.Photos.Any())
                {
                    db.Photos.Add(new Photo()
                    {
                        Path = "/Assets/1487051.png"
                    });

                    db.SaveChanges();
                }
                #endregion

                #region 初始化房屋資料

                //if (!db.Houses.Any())
                //{
                //    Region[] regions = db.Regions.ToArray();
                //    Photo photo = db.Photos.FirstOrDefault();

                //    for (int i = 0; i < 300; i++)
                //    {
                //        var rnd = new Random(DateTime.Now.Millisecond);
                //        int idx = rnd.Next(0, regions.Length - 1);
                //        Region region = regions[idx];
                //        int ground = rnd.Next(5, 30);
                //        int price = rnd.Next(300, 3000);

                //        db.Houses.Add(new Models.House
                //        {
                //            Ground = ground,
                //            Price = price,
                //            Parking = (ground % 2 == 0) ? Parking.Plane : Parking.Mechanical,
                //            Region = region,
                //            City = region.City
                //        });

                //        db.SaveChanges();
                //    }
                //}

                #endregion
            }
        }

        #endregion

        // GET: Home
        #region 查詢頁面

        public ActionResult Index()
        {
            //初始化資料
            InitData();

            using (var db = new HouseModel())
            {
                //取出縣市、行政區資料供給View使用
                var cities = db.Cities.Include("Regions").ToList();

                ViewBag.DefaultLat = WebConfigurationManager.AppSettings["MapDefaultCenterLat"];
                ViewBag.DefaultLng = WebConfigurationManager.AppSettings["MapDefaultCenterLng"];
                
                return View(cities);
            }
        }

        #endregion
    }
}