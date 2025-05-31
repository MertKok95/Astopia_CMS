using Cms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistence;
using Cms.Domain.Repositories;

namespace Cms.Infrastructure.Repositories;

public class ContentRepository : IContentRepository
{
    private readonly AppDbContext _context;

    public ContentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Content>> GetByUserGuidWithVariantsAsync(Guid userId)
    {
        // Burada userId ile ilişkilendirilen içerikler çekilir,
        // içeriklerin varyantları ve kategori bilgileri de dahil edilir.

        return await _context.Contents
            .Include(c => c.Variants)     // Varyantlar
            .Include(c => c.Category)     // Kategori
            .Where(c => c.User.Id == userId)  // UserGuid’e göre filtre
            .ToListAsync();
    }

    public async Task<Content?> GetByGuidWithVariantsAsync(Guid contentId)
    {
        return await _context.Contents
            .Include(x => x.Category)
            .Include(c => c.Variants)
            .FirstOrDefaultAsync(c => c.Id == contentId);
    }

    public async Task<List<Content>> GetAllWithVariantsAsync()
    {
        return await _context.Contents
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Variants)
            .ToListAsync();
    }

}

