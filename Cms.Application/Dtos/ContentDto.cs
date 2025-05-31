namespace Cms.Application.Dtos
{
   public class ContentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }  // EKLENDİ


        public List<ContentVariantDto> Variants { get; set; } = new();
        public ContentVariantDto SelectedVariant { get; set; }
    }

}

