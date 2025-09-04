using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Snippet.Validators
{
    public class CreateSnippetDtoValidator : AbstractValidator<CreateSnippetDto>
    {
        public CreateSnippetDtoValidator() {
            Include(new ISnippetDtoValidator());
            RuleFor(x => x.OwnerId).MaximumLength(200);
        }
    }
}
