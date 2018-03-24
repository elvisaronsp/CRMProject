using CRMProject.Interfaces;
using CRMProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.Repository
{
    public class GenericBusinessCustomerRepository: AbstractRepository<BusinessCustomer>, IGenericBusinessCustomerRepository
    {
    }
}