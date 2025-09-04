using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Snippet
{
    public class SnippetDto : BaseDto, ISnippetDto
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string Language { get; set; } = "text";
        public string Code { get; set; } = "";
        public string? Tags { get; set; }
        public bool IsPublic { get; set; } = true;
        public string? OwnerId { get; set; }
    }
}
