using CRMProject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.BusinessLogic
{
    public class SalesAgentValidation : AbstractValidator<SalesAgent>
    {

        public SalesAgentValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");


            RuleFor(x => x.Rank)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");


            RuleFor(x => x.HireDate)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");


            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");

            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress()
               .WithMessage("This Cannot Be Empty");

            //TODO finish and do other validations




        }
    }
}