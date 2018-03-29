using CRMProject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.BusinessLogic
{
    public class IndividualCustomerValidation : AbstractValidator<IndividualCustomer>
    {
        public  IndividualCustomerValidation()
        {
            RuleFor(x => x.Adress)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");
        }

       
    }
}