using DataLayer.classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.validators
{
    public class SpecialtyValidator: AbstractValidator<Specialty>
    {
        public SpecialtyValidator()
        {
            RuleFor(x => x.SpecialtyName).MinimumLength(10).WithMessage("There is no such a specialty");
            RuleFor(x => x.SpecialtyId).InclusiveBetween(1,300).WithMessage("Invalid specialty id");
            
        }
    
    }
}
