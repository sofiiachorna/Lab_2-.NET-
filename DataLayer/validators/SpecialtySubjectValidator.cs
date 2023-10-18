using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.classes;

namespace DataLayer.validators
{
    public class SpecialtySubjectValidator : AbstractValidator<SpecialtySubject>
    {
        public SpecialtySubjectValidator() 
        {
            RuleFor(x => x.SpecialtyId).InclusiveBetween(1, 300).WithMessage("Invalid specialty id");
            RuleFor(x => x.SubjectId).LessThan(30).WithMessage("Invalid subject id");

        }
    }
}
