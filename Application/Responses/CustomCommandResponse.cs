using Application.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class CustomCommandResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}
