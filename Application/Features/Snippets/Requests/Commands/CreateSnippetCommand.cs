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
    public class CreateSnippetCommand : IRequest<CustomCommandResponse>
    {
        public CreateSnippetDto snippetDto { get; set; } = null!;
    }
}
