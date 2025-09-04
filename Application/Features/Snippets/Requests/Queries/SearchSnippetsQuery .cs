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
    public class SearchSnippetsQuery : IRequest<CustomQueryResponse<List<SnippetDto>>>
    {
        public string Query { get; set; } = "";
        public int Limit { get; set; } = 50;
    }
}
