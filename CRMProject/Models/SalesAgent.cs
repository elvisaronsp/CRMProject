using CRMProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMProject.Models
{
    public class SalesAgent
    {
        public int SalesAgentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Rank Rank { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public decimal SaleValue { get; set; }

        public int Sales { get; set; }

        public ICollection<IndividualCustomer> IndividualCustomers { get; set; }

        public ICollection<BusinessCustomer> BusinessCustomers { get; set; }
    }
}