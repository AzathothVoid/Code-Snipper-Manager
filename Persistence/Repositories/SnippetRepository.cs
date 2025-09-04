using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SnippetRepository : Repository<Snippet>, ISnippetRepository
    {
    }
}
