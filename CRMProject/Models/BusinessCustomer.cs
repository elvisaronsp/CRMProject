using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRMProject.Models
{
    public class BusinessCustomer
    {
        public int BusinessCustomerId { get; set; }

        public string CompanyName { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmail { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public int SalesAgentId { get; set; }
        [ForeignKey("SalesAgentId")]
        public virtual SalesAgent SalesAgent { get; set; }
    }
}