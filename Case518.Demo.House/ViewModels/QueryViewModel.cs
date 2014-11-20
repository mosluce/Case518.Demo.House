using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case518.Demo.House.ViewModels
{
    public class QueryViewModel
    {
        public int[] Price { get; set; }
        public int[] Ground { get; set; }
        public int[] Parking { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public SortViewModel Sort { get; set; }
        public PagingViewModel Paging { get; set; }
    }

    public class SortViewModel
    {
        public string Field { get; set; }
        public string Type { get; set; }
    }

    public class PagingViewModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}