using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.classes;
using FluentValidation;

namespace DataLayer.validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator() 
        {
            RuleFor(x => x.SubjectName).MaximumLength(100).WithMessage("There is no subject with such a name");
            RuleFor(x => x.SubjectId).LessThan(30).WithMessage("Invalid subject id");
            RuleFor(x => x.TeacherId).LessThan(100).WithMessage("Invalid teacher id");
            RuleFor(x => x.Hours).LessThan(150).WithMessage("Wromg amount of hours");
            RuleFor(x => x.SpecialtyId).InclusiveBetween(100, 300).WithMessage("There is no specilaty with such an id");

        }
    }
}
