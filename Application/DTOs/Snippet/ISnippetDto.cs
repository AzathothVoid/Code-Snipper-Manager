using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Snippet
{
    public interface ISnippetDto
    {
        public string Title { get;  set; }
        public string? Description { get;  set; }
        public string Language { get;  set; } 
        public string Code { get; set; }
        public string? Tags { get;  set; }
        public bool IsPublic { get;  set; }
        public string? OwnerId { get;  set; }
    }
}
