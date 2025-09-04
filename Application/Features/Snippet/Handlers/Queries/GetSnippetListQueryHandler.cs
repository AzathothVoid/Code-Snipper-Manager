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
    public class GetSnippetListQueryHandler : IRequestHandler<GetSnippetListQuery, CustomQueryResponse<List<SnippetDto>>>
    {
        Task<CustomQueryResponse<List<SnippetDto>>> IRequestHandler<GetSnippetListQuery, CustomQueryResponse<List<SnippetDto>>>.Handle(GetSnippetListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
