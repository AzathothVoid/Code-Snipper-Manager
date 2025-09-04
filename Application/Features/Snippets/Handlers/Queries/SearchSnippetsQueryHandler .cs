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
    public class SearchSnippetsQueryHandler : IRequestHandler<SearchSnippetsQuery, CustomQueryResponse<List<SnippetDto>>>
    {
        private readonly ISnippetRepository _repo;
        private readonly IMapper _mapper;

        public SearchSnippetsQueryHandler(ISnippetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<SnippetDto>>> Handle(SearchSnippetsQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SnippetDto>>();

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                response.Success = true;
                response.Message = "Empty query";
                response.Data = new List<SnippetDto>();
                return response;
            }

            var list = await _repo.SearchAsync(request.Query, request.Limit, cancellationToken);

            response.Success = true;
            response.Message = "Search successful";
            response.Data = _mapper.Map<List<SnippetDto>>(list);
            return response;
        }
    }

}
