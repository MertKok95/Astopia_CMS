namespace Cms.Application.Dtos;

public class ContentDetailDto
{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public Guid SelectedVariantId { get; set; }
}
