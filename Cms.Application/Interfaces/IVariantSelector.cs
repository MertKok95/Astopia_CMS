using Cms.Application.Dtos;

namespace Cms.Application.Interfaces
{
    public interface IVariantSelector
    {
        ContentVariantDto Select(List<ContentVariantDto> variants, Guid? userId);
    }
}