using DataLayer.classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.validators
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator() 
        {
            RuleFor(x => x.TeacherName).Length(6, 30).NotEqual("Name Name").NotEqual("Name");
            RuleFor(x => x.TeacherId).LessThan(100).WithMessage("Invalid teacher id");

        }
    }
}
