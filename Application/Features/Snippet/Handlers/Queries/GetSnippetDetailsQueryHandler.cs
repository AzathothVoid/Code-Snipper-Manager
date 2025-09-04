using Application.DTOs.Snippet;
using Application.Features.Snippet.Requests.Queries;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippet.Handlers.Queries
{
    public class GetSnippetDetailsQueryHandler : IRequestHandler<GetSnippetDetailsQuery, CustomQueryResponse<SnippetDto>>
    {
        public GetSnippetDetailsQueryHandler()
        {
                
        }

        public Task<CustomQueryResponse<SnippetDto>> Handle(GetSnippetDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
