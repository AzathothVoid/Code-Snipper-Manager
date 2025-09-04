using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Snippet.Validators
{
    public class ISnippetDtoValidator : AbstractValidator<ISnippetDto>
    {
        public ISnippetDtoValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters.")
            .MaximumLength(200).WithMessage("Title must be at most 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description must be at most 2000 characters.");

            RuleFor(x => x.Language)
                .NotEmpty().WithMessage("Language is required.");
                //.Must(lang => AllowedLanguages.Contains(lang.ToLowerInvariant()))
                //.WithMessage($"Language must be one of: {string.Join(", ", AllowedLanguages)}");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MinimumLength(1).WithMessage("Code cannot be empty.")
                .MaximumLength(200_000).WithMessage("Code is too long.");

            RuleFor(x => x.Tags)
                .Must(ValidateTags)
                .WithMessage("Tags must be comma-separated words (1-50 chars each), and up to 10 tags.");
        }

        private bool ValidateTags(string? tags)
        {
            if (string.IsNullOrWhiteSpace(tags)) return true;
            var parts = tags.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length > 10) return false;
            foreach (var p in parts)
            {
                if (p.Length < 1 || p.Length > 50) return false;
                // optional: regex for allowed characters
                if (!System.Text.RegularExpressions.Regex.IsMatch(p, @"^[\w\-\+]+$")) return false;
            }
            return true;
        }
    }
}
