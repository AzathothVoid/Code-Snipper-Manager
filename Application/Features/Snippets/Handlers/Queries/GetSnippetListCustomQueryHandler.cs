using Application.Contracts.Persistence;
using Application.DTOs.Snippet;
using Application.Features.Snippets.Requests.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Handlers.Queries
{
    public class GetSnippetListCustomQueryHandler : IRequestHandler<GetSnippetListCustomQuery, CustomQueryResponse<List<SnippetDto>>>
    {
        private readonly ISnippetRepository _repo;
        private readonly IMapper _mapper;

        public GetSnippetListCustomQueryHandler(ISnippetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<SnippetDto>>> Handle(GetSnippetListCustomQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SnippetDto>>();
            var list = await _repo.ListByPageAsync(request.Page, request.PageSize, cancellationToken);

            response.Success = true;
            response.Message = "List fetched";
            response.Data = _mapper.Map<List<SnippetDto>>(list);
            return response;
        }
    }
}
