using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Case518.Demo.House.Models;
using Case518.Demo.House.ViewModels;

namespace Case518.Demo.House.Controllers.WebAPI
{
    public class QueryController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetHourses(QueryViewModel model)
        {
            using (var db = new HouseModel())
            {
                IQueryable<Models.House> query = db.Houses.Include("Region").Include("City").Where(c=>true);

                #region 篩選縣市
                
                if (model.CityId != null)
                {
                    query = query.Where(c => c.City.Id == model.CityId);
                }
                #endregion

                #region 篩選行政區
                
                if (model.RegionId != null)
                {
                    query = query.Where(c => c.Region.Id == model.RegionId);
                }
                #endregion

                #region 篩選坪數
                
                if (model.Ground != null)
                {
                    var min = model.Ground[0];
                    var max = model.Ground[1];
                    query = query.Where(c => c.Ground >= min && c.Ground <= max);
                }
                #endregion

                #region 篩選總價
                
                if (model.Price != null)
                {
                    if (model.Price[1] > 0)
                    {
                        var max = model.Price[1];
                        query = query.Where(c => c.Price <= max);
                    }
                    var min = model.Price[0];
                    query = query.Where(c => c.Price >= min);
                }
                #endregion

                #region 篩選停車位
                
                if (model.Parking != null)
                {
                    if (model.Parking.Contains(0) && model.Parking.Contains(1))
                    {
                        query = query.Where(c => c.Parking == Parking.Plane || c.Parking == Parking.Mechanical);
                    }
                    else
                    {
                        if (model.Parking.Contains(0))
                        {
                            query = query.Where(c => c.Parking == Parking.Plane);
                        }

                        if (model.Parking.Contains(1))
                        {
                            query = query.Where(c => c.Parking == Parking.Mechanical);
                        }

                    }
                }
                #endregion

                #region 排序
                if (model.Sort != null)
                {
                    var field = model.Sort.Field;
                    var type = model.Sort.Type;

                    if (type.Equals("asc"))
                    {
                        //小 >>> 大
                        if (field.Equals("ground"))
                        {
                            query = query.OrderBy(c => c.Ground);
                        }
                        else
                        {
                            query = query.OrderBy(c => c.Price);
                        }
                    }
                    else
                    {
                        //大 >>> 小
                        if (field.Equals("ground"))
                        {
                            query = query.OrderByDescending(c => c.Ground);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.Price);
                        }
                    }
                }
                #endregion

                #region 分頁

                if (model.Paging != null)
                {
                    var paging = model.Paging;
                    query = query.Skip((paging.Page - 1)*paging.Limit).Take(paging.Limit);
                }

                #endregion

                var houses = query.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, houses);
            }
        }
    }
}
