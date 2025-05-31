namespace Cms.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Content> Contents { get; set; } = new List<Content>();
    }
}

