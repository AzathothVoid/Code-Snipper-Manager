using Application.DTOs.Snippet;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Requests.Queries
{
    public class GetSnippetListCustomQuery : IRequest<CustomQueryResponse<List<SnippetDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 24;
    }
}
