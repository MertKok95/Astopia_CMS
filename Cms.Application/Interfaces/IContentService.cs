using Cms.Application.Dtos;

namespace Cms.Application.Interfaces
{
    public interface IContentService
    {
        Task<List<ContentDto>?> GetAllContentsAsync(Guid? categoryId = null, string? language = null);
        Task<List<CategoryDto>?> GetAllCategoriesAsync();
        Task<List<ContentDto>?> GetContentsByUserAsync(Guid userId, Guid? categoryId = null, string? language = null);
        Task<ContentDetailDto?> GetContentDetailForUserAsync(Guid contentId, Guid? userId);
    } 
}


