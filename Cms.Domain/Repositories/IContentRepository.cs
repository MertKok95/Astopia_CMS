using Cms.Domain.Entities;

namespace Cms.Domain.Repositories
{
    public interface IContentRepository
    {
        Task<List<Content>> GetByUserGuidWithVariantsAsync(Guid userId);
        Task<Content?> GetByGuidWithVariantsAsync(Guid contentId);
        Task<List<Content>> GetAllWithVariantsAsync();
    }
}
