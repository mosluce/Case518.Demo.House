﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case518.Demo.House.Models
{
    public enum Parking
    {
        Plane,
        Mechanical
    }

    public class House
    {
        public int Id { get; set; }

        /// <summary>
        /// 縣市
        /// </summary>
        public  City City { get; set; }

        /// <summary>
        /// 行政區
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// 車位
        /// </summary>
        public Parking Parking { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 坪數
        /// </summary>
        public int Ground { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// 緯度
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 經度
        /// </summary>
        public double Lng { get; set; }
    }
}