using Cms.Application.Dtos;
using Cms.Application.Interfaces;

namespace Cms.Application.Services
{
    public class StatefulVariantSelector : IVariantSelector
    {
        private readonly Dictionary<string, Guid> _userVariantCache = new();

        public ContentVariantDto Select(List<ContentVariantDto> variants, Guid? userId)
        {
            if (variants == null || variants.Count == 0)
                return null;

            var contentId = variants.First().ContentId;
            var cacheKey = userId != null ? $"{userId}_{contentId}" : contentId.ToString();

            if (_userVariantCache.TryGetValue(cacheKey, out var variantId))
            {
                var cachedVariant = variants.FirstOrDefault(v => v.Id == variantId);
                if (cachedVariant != null)
                    return cachedVariant;
            }

            var selected = variants.First(); // Gelişmiş seçim yapılabilir
            _userVariantCache[cacheKey] = selected.Id;

            return selected;
        }
    }
}
