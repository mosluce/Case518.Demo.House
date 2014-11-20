using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Case518.Demo.House.Models
{
    public class Region
    {
        public int Id { get; set; }

        /// <summary>
        /// 所在縣市
        /// </summary>
        [JsonIgnore]
        public City City { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        public Region()
        {
            
        }

        public Region(string name)
        {
            Name = name;
        }
    }
}