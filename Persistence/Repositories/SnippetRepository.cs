using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    public class SnippetRepository : Repository<Snippet>, ISnippetRepository
    {
        private readonly CodeSnipperManagerDbContext _dbContext;
        private readonly DbSet<Snippet> _dbSet;

        public SnippetRepository(CodeSnipperManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Snippet>();
        }

        public async Task AddTagAsync(Guid id, string tag, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(tag)) return;
            var e = await _dbSet.FindAsync(new object[] { id }, ct);
            if (e == null) return;
            var list = (e.Tags ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            if (!list.Contains(tag, StringComparer.OrdinalIgnoreCase))
            {
                list.Add(tag);
                e.Tags = string.Join(",", list);
                e.UpdatedAt = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync(ct);
            }
        }

        public async Task<int> CountAsync(CancellationToken ct = default)
        {
            return await _dbSet.CountAsync(ct);
        }

        public async Task<List<Snippet>> ListByLanguageAsync(string language, int limit = 50, CancellationToken ct = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(s => EF.Functions.ILike(s.Language, language))
                .OrderByDescending(s => s.CreatedAt)
                .Take(limit)
                .ToListAsync(ct);
        }

        public async Task<List<Snippet>> ListByOwnerAsync(string ownerId, int page = 1, int pageSize = 20, CancellationToken ct = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(s => s.OwnerId == ownerId)
                .OrderByDescending(s => s.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<List<Snippet>> ListByTagAsync(string tag, int limit = 50, CancellationToken ct = default)
        {
            var tagLower = tag.ToLowerInvariant();
            return await _dbSet
                .AsNoTracking()
                .Where(s => EF.Functions.ILike(s.Tags ?? "", $"%{tagLower}%"))
                .OrderByDescending(s => s.CreatedAt)
                .Take(limit)
                .ToListAsync(ct);
        }

        public async Task RemoveTagAsync(Guid id, string tag, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(tag)) return;
            var e = await _dbSet.FindAsync(new object[] { id }, ct);
            if (e == null) return;
            var list = (e.Tags ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(t => !string.Equals(t, tag, StringComparison.OrdinalIgnoreCase)).ToList();
            e.Tags = list.Count == 0 ? null : string.Join(",", list);
            e.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<List<Snippet>> SearchAsync(string query, int limit = 50, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<Snippet>();

            var q = $"%{query}%";
            return await _dbSet
                .AsNoTracking()
                .Where(s =>
                    EF.Functions.ILike(s.Title, q) ||
                    EF.Functions.ILike(s.Tags ?? "", q) ||
                    EF.Functions.ILike(s.Code, q))
                .OrderByDescending(s => s.CreatedAt)
                .Take(limit)
                .ToListAsync(ct);
        }

        public async Task TogglePublicAsync(Guid id, bool isPublic, CancellationToken ct = default)
        {
            var e = await _dbSet.FindAsync(new object[] { id }, ct);
            if (e == null) return;
            e.IsPublic = isPublic;
            e.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
        {
            var e = await _dbSet.FindAsync(new object[] { id }, ct);

            if (e == null) return false;

            return true;
        }

        public async Task<List<Snippet>> ListByPageAsync(int page, int pageSize, CancellationToken ct = default)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            return await _dbSet
                .OrderByDescending(s => s.CreatedAt) 
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }
    }
}
