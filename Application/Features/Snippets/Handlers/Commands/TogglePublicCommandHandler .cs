using Application.Contracts.Persistence;
using Application.Features.Snippets.Requests.Commands;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Handlers.Commands
{
    // Application/Handlers/TogglePublicCommandHandler.cs
    public class TogglePublicCommandHandler : IRequestHandler<TogglePublicCommand, CustomCommandResponse>
    {
        private readonly ISnippetRepository _repo;

        public TogglePublicCommandHandler(ISnippetRepository repo)
        {
            _repo = repo;
        }

        public async Task<CustomCommandResponse> Handle(TogglePublicCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();

            var exists = await _repo.ExistsAsync(request.Id, cancellationToken);
            if (!exists)
            {
                response.Success = false;
                response.Message = "Toggle failed";
                response.Errors = "Snippet not found";
                return response;
            }

            await _repo.TogglePublicAsync(request.Id, request.IsPublic, cancellationToken);

            response.Success = true;
            response.Message = "Visibility updated";
            response.Id = request.Id;
            return response;
        }
    }

}
