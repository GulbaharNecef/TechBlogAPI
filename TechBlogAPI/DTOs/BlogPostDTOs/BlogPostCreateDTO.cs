namespace TechBlogAPI.DTOs.BlogPostDTOs
{
    public class BlogPostCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile CoverPhoto { get; set; }
    }
}
