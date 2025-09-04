using Application.Contracts.Persistence.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ISnippetRepository : IRepository<Snippet>
    {
        Task<List<Snippet>> SearchAsync(string query, int limit = 50, CancellationToken ct = default); 
        Task<List<Snippet>> ListByOwnerAsync(string ownerId, int page = 1, int pageSize = 20, CancellationToken ct = default);
        Task<List<Snippet>> ListByTagAsync(string tag, int limit = 50, CancellationToken ct = default);
        Task<List<Snippet>> ListByLanguageAsync(string language, int limit = 50, CancellationToken ct = default);
        Task<List<Snippet>> ListByPageAsync(int page, int pageSize, CancellationToken ct = default);
        Task<int> CountAsync(CancellationToken ct = default);
        Task TogglePublicAsync(Guid id, bool isPublic, CancellationToken ct = default);
        Task AddTagAsync(Guid id, string tag, CancellationToken ct = default);
        Task RemoveTagAsync(Guid id, string tag, CancellationToken ct = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
    }
}
