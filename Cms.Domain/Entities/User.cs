namespace Cms.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<Content> Contents { get; set; } = new List<Content>();
    }
}

