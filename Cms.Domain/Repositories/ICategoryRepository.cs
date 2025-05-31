using Cms.Domain.Entities;

namespace Cms.Domain.Repositories
{
    public interface ICategoryRepository
    {
           Task<List<Category>> GetAllAsync();
    }
}
