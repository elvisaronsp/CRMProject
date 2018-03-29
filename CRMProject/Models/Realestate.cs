using CRMProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMProject.Models
{
    public class Realestate
    {

        public int RealestateId { get; set; }

        public string Type { get; set; }

        public double BasePrice { get; set; }

        public double DetailPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime RealeseDate { get; set; }

        public bool Available { get; set; }

        public int Rooms { get; set; }

        public SaleType SaleType { get; set; }

        public string Description { get; set; }
    }
}