using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Case518.Demo.House.Models
{
    public class City
    {
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 包含地區
        /// </summary>
        public ICollection<Region> Regions { get; set; }
    }
}