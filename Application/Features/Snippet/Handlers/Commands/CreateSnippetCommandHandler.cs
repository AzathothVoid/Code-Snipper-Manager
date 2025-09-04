using Application.Features.Snippet.Requests.Commands;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippet.Handlers.Commands
{
    public class CreateSnippetCommandHandler : IRequestHandler<CreateSnippetCommand, CustomCommandResponse>
    {
        public CreateSnippetCommandHandler()
        {
                
        }
        public Task<CustomCommandResponse> Handle(CreateSnippetCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
