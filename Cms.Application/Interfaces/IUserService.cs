using Cms.Application.Dtos;

namespace Cms.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(Guid userId);
        Task<List<UserDto>> GetAllUsersAsync();

        Task<List<ContentDto>?> GetUserContentsAsync(Guid userId, Guid? categoryId = null);
    }
}


