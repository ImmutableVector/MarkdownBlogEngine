namespace ProgrammingLexicon.Dal.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
    }
}
