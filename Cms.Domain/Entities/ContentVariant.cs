namespace Cms.Domain.Entities
{
    public class ContentVariant
    {
        public Guid Id { get; set; }
        public string VariantName { get; set; }
        public string ImageUrl { get; set; }
        // Diğer özellikler...

        public Guid ContentId { get; set; }       // Foreign key
        public Content Content { get; set; }      // Navigation property
    }
}

