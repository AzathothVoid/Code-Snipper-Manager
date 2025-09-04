using Application.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class CustomQueryResponse<T> : BaseResponse where T : class
    {
        public T? Data { get; set; }
    }
}
