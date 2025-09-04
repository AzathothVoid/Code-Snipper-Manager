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
    public class GetSnippetDetailsQueryHandler : IRequestHandler<GetSnippetDetailsQuery, CustomQueryResponse<SnippetDto>>
    {
        private readonly ISnippetRepository _snippetRepository;
        private readonly IMapper _mapper;

        public GetSnippetDetailsQueryHandler(ISnippetRepository urlTokenRepository, IMapper mapper)
        {
            _snippetRepository = urlTokenRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<SnippetDto>> Handle(GetSnippetDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<SnippetDto>();
            var snippetDetail = await _snippetRepository.GetByIdAsync(request.Id);

            if (snippetDetail == null)
            {
                response.Success = false;
                response.Message = "Snippet not found";
                return response;
            }

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<SnippetDto>(snippetDetail);

            return response;
        }
    }
}
