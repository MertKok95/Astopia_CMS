namespace Cms.Domain.Entities
{
    public class Content
    { 
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }               // Navigation property

        public ICollection<ContentVariant> Variants { get; set; } = new List<ContentVariant>();
    }

}
