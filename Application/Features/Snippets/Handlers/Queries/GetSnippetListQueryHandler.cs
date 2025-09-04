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
    public class GetSnippetListQueryHandler : IRequestHandler<GetSnippetListQuery, CustomQueryResponse<List<SnippetDto>>>
    {
        private readonly ISnippetRepository _snippetRepository;
        private readonly IMapper _mapper;

        public GetSnippetListQueryHandler(ISnippetRepository urlTokenRepository, IMapper mapper)
        {
            _snippetRepository = urlTokenRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<SnippetDto>>> Handle(GetSnippetListQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SnippetDto>>();
            var snippetDetail = await _snippetRepository.GetAllAsync();

            if (snippetDetail == null)
            {
                response.Success = false;
                response.Message = "Snippets not found";
                return response;
            }
            
            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<SnippetDto>>(snippetDetail);

            return response;
        }
    }
}
