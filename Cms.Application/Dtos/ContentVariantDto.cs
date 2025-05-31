namespace Cms.Application.Dtos
{
    public class ContentVariantDto
    {
        public Guid Id { get; set; }
        public string VariantName { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public Guid ContentId { get; set; }  // Bu önemli!

    }
}