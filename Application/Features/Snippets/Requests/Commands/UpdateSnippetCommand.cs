using Application.DTOs.Snippet;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Requests.Commands
{
    public class UpdateSnippetCommand : IRequest<CustomCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateSnippetDto snippetDto { get; set; } = null!;
    }
}
