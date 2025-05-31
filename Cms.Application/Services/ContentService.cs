using Cms.Application.Dtos;
using Cms.Application.Interfaces;
using Cms.Domain.Repositories;
using Mapster;
using Microsoft.Extensions.Caching.Memory;

namespace Cms.Application.Services;

public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMemoryCache _cache;
    private readonly IVariantSelector _variantSelector;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(15);

    public ContentService(
        IContentRepository contentRepository,
        ICategoryRepository categoryRepository,
        IMemoryCache cache,
        IVariantSelector variantSelector)
    {
        _contentRepository = contentRepository;
        _categoryRepository = categoryRepository;
        _cache = cache;
        _variantSelector = variantSelector;
    }

   public async Task<List<ContentDto>?> GetAllContentsAsync(Guid? categoryId = null, string? language = null)
    {
        var contents = await _contentRepository.GetAllWithVariantsAsync();

        var contentDtos = new List<ContentDto>();

        foreach (var content in contents)
        {
            var dto = content.Adapt<ContentDto>();
            dto.Variants = content.Variants.Adapt<List<ContentVariantDto>>();
            dto.SelectedVariant = _variantSelector.Select(dto.Variants, content.User.Id);

            contentDtos.Add(dto);
        }

        if (categoryId.HasValue && contentDtos != null && contentDtos.Count > 0)
            contentDtos = contentDtos.Where(x => x.CategoryId == categoryId.Value).ToList();

        if (!string.IsNullOrWhiteSpace(language) && contentDtos != null && contentDtos.Count > 0)
            contentDtos = contentDtos.Where(x => x.Language?.ToLower() == language?.ToLower()).ToList();

        return contentDtos;
    }



    public async Task<List<CategoryDto>?> GetAllCategoriesAsync()
    {
        const string cacheKey = "AllCategories";

        if (!_cache.TryGetValue(cacheKey, out List<CategoryDto> categoryDtos))
        {
            var categories = await _categoryRepository.GetAllAsync();
            categoryDtos = categories.Adapt<List<CategoryDto>>();
            _cache.Set(cacheKey, categoryDtos, CacheDuration);
        }

        return categoryDtos;
    }

    
    public async Task<List<ContentDto>?> GetContentsByUserAsync(Guid userId, Guid? categoryId = null, string? language = null)
    {
        string cacheKey = $"UserContents_{userId}";
        List<ContentDto> contentDtos;

        if (!_cache.TryGetValue(cacheKey, out contentDtos))
        {
            var contents = await _contentRepository.GetByUserGuidWithVariantsAsync(userId);

            contentDtos = new List<ContentDto>();

            foreach (var content in contents)
            {
                var dto = content.Adapt<ContentDto>();
                dto.Variants = content.Variants.Adapt<List<ContentVariantDto>>();
                dto.SelectedVariant = _variantSelector.Select(dto.Variants, content.User?.Id);

                contentDtos.Add(dto);
            }

            _cache.Set(cacheKey, contentDtos, CacheDuration);
        }

        if (categoryId.HasValue && contentDtos != null && contentDtos.Count > 0)
            contentDtos = contentDtos.Where(x => x.CategoryId == categoryId.Value).ToList();

        if (!string.IsNullOrWhiteSpace(language) && contentDtos != null && contentDtos.Count > 0)
            contentDtos = contentDtos.Where(x => x.Language?.ToLower() == language?.ToLower()).ToList();

        return contentDtos;
    }



    public async Task<ContentDetailDto?> GetContentDetailForUserAsync(Guid contentId, Guid? userId)
    {
        string cacheKey = $"ContentDetail_{contentId}_{userId}";

        if (!_cache.TryGetValue(cacheKey, out ContentDetailDto dto))
        {
            var content = (await _contentRepository.GetByGuidWithVariantsAsync(contentId)) ?? throw new Exception("İçerik bulunamadı");

            dto = content.Adapt<ContentDetailDto>();

            if (content.Variants.Count != 0)
            {
                var variantDtos = content.Variants.Adapt<List<ContentVariantDto>>();
                var selectedVariant = _variantSelector.Select(variantDtos, userId);
                dto.SelectedVariantId = selectedVariant?.Id ?? Guid.Empty;
                dto.ImageUrl = selectedVariant?.ImageUrl ?? "";
            }

            _cache.Set(cacheKey, dto, CacheDuration);
        }
        return dto;
    }
}
