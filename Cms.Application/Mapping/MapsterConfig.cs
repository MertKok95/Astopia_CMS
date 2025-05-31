using Cms.Application.Dtos;
using Cms.Domain.Entities;
using Mapster;

namespace Cms.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Content, ContentDto>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.Variants, src => src.Variants.Adapt<List<VariantDto>>());
        }
    }
}

