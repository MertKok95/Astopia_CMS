using Microsoft.AspNetCore.Mvc;
using Cms.Application.Interfaces;

namespace Cms.Web.Controllers
{
    public class UserController(IUserService userService, IContentService contentService) : Controller
    {
        // Kullanıcı listesi
        public async Task<IActionResult> GetUserList()
        {
            var users = await userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet("User/Profile/{userId}")]
        public async Task<IActionResult> Profile(Guid userId)
        {
            var user = await userService.GetUserByIdAsync(userId);
            if (user == null) return NotFound();

            var contents = await contentService.GetContentsByUserAsync(userId);
            ViewBag.Contents = contents;

            return View(user); // model: UserDto
        }

        [HttpGet("User/Contents/{userId}")]
        public async Task<IActionResult> Contents(Guid userId, Guid? categoryId = null)
        {
            var contents = await userService.GetUserContentsAsync(userId, categoryId);
            var categories = await contentService.GetAllCategoriesAsync();

            ViewBag.UserId = userId;
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = categoryId;

            return View(contents);
        }

    }
}
