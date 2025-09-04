using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Snippet.Validators
{
    public class UpdateSnippetDtoValidator : AbstractValidator<UpdateSnippetDto>
    {
        public UpdateSnippetDtoValidator() {
            Include(new ISnippetDtoValidator());
        }
    }
}
