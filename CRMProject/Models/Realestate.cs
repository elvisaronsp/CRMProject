﻿using CRMProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.Models
{
    public class Realestate
    {

        public int RealestateId { get; set; }

        public string Type { get; set; }

        public decimal BasePrice { get; set; }

        public decimal DetailPrice { get; set; }

        public DateTime RealeseDate { get; set; }

        public bool Available { get; set; }

        public int Rooms { get; set; }

        public SaleType SaleType { get; set; }

        public string Description { get; set; }
    }
}