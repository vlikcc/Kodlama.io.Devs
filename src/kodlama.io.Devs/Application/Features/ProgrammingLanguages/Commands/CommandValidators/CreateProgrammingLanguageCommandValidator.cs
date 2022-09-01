using Application.Features.ProgrammingLanguages.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.CommandValidators
{
    public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguage>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
        }
    }
}
