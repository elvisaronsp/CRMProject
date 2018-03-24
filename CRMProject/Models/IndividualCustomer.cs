using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRMProject.Models
{
    public class IndividualCustomer
    {
        public int IndividualCustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public int SalesAgentId { get; set; }
        [ForeignKey("SalesAgentId")]
        public virtual SalesAgent SalesAgent { get; set; }


    }
}