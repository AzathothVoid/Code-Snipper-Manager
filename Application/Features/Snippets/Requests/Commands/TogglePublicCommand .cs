using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Requests.Commands
{
    public class TogglePublicCommand : IRequest<CustomCommandResponse>
    {
        public Guid Id { get; set; }
        public bool IsPublic { get; set; }
    }

}
