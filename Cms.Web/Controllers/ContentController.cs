using Microsoft.AspNetCore.Mvc;
using Cms.Application.Interfaces;

namespace Cms.Web.Controllers
{
    public class ContentController(IContentService contentService) : Controller
    {
        // Tüm içerikler (opsiyonel filtre)
        [HttpGet("Content/All/{userId?}")]
        public async Task<IActionResult> All(Guid? userId, Guid? categoryId = null, string? language = null)
        {
            if (!userId.HasValue)
            {
                // userId yoksa tüm içerikleri getirebilirsin ya da farklı davran
                var contents = await contentService.GetAllContentsAsync(categoryId, language);
                ViewBag.Categories = await contentService.GetAllCategoriesAsync();
                ViewBag.UserId = null;
                ViewBag.SelectedCategory = categoryId;
                ViewBag.SelectedLanguage = language;
                return View(contents);
            }

            var userContents = await contentService.GetContentsByUserAsync(userId.Value, categoryId, language);
            ViewBag.Categories = await contentService.GetAllCategoriesAsync();
            ViewBag.UserId = userId;
            ViewBag.SelectedCategory = categoryId;
            ViewBag.SelectedLanguage = language;
            return View(userContents);
        }

        // İçerik detay (seçilen varyant dahil)
        [HttpGet("Content/Detail")]
        public async Task<IActionResult> Detail(Guid id, Guid? userId=null)
        {
            var content = await contentService.GetContentDetailForUserAsync(id, userId);
            if (content == null) return NotFound();

            return View(content);
        }
    }
}
