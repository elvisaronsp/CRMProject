using CRMProject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.BusinessLogic
{
    public class RealestateValidation : AbstractValidator<Realestate>
    {

        public RealestateValidation()
        {
            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");

            RuleFor(x => x.SaleType)
                .NotEmpty()
                .WithMessage("Sale Type must be defined");


            RuleFor(x => x.Rooms)
                .NotEmpty()
                .WithMessage("This Cannot Be Empty");

            RuleFor(x => x.RealeseDate)
               .NotEmpty()
               .WithMessage("Pick the release date");

            RuleFor(x => x.BasePrice)
               .NotEmpty()
               .WithMessage("The base price has to be specified");

            RuleFor(x => x.DetailPrice)
               .NotEmpty()
               .WithMessage("The detail price has to be specified");






        }
    }
}