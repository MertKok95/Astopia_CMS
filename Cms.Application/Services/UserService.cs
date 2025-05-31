using Mapster;
using Cms.Application.Interfaces;
using Cms.Domain.Repositories;
using Cms.Application.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace Cms.Application.Services
{
    public class UserService(IUserRepository userRepository, IMemoryCache cache, IContentService contentService) : IUserService
    {
        private readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(15);

        public async Task<UserDto?> GetUserByIdAsync(Guid userId)
        {
            string cacheKey = $"User_{userId}";

            if (cache.TryGetValue(cacheKey, out UserDto? cachedUser))
                return cachedUser;

            var user = await userRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            var userDto = user.Adapt<UserDto>();
            cache.Set(cacheKey, userDto, CacheDuration);
            return userDto;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            const string cacheKey = "AllUsers";

            if (cache.TryGetValue(cacheKey, out List<UserDto>? cachedUsers))
                return cachedUsers ?? new();

            var users = await userRepository.GetAllAsync();

            if (users == null || users.Count == 0)
                return new();

            var userDtos = users.Adapt<List<UserDto>>();
            cache.Set(cacheKey, userDtos, CacheDuration);
            return userDtos;
        }

        public async Task<List<ContentDto>?> GetUserContentsAsync(Guid userId, Guid? categoryId = null)
        {
            return await contentService.GetContentsByUserAsync(userId, categoryId);
        }
    }
}
