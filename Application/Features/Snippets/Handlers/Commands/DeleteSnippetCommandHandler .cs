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
    public class DeleteSnippetCommandHandler : IRequestHandler<DeleteSnippetCommand, CustomCommandResponse>
    {
        private readonly ISnippetRepository _repo;

        public DeleteSnippetCommandHandler(ISnippetRepository repo)
        {
            _repo = repo;
        }

        public async Task<CustomCommandResponse> Handle(DeleteSnippetCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();

            var exists = await _repo.ExistsAsync(request.Id, cancellationToken);
            if (!exists)
            {
                response.Success = false;
                response.Message = "Delete failed";
                response.Errors = "Snippet not found";
                return response;
            }

            await _repo.DeleteAsync(request.Id, cancellationToken);

            response.Success = true;
            response.Message = "Deleted";
            response.Id = request.Id;
            return response;
        }
    }

}
