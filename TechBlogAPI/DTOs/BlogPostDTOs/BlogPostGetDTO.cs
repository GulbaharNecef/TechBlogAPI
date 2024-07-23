namespace TechBlogAPI.DTOs.BlogPostDTOs
{
    public class BlogPostGetDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverPhotoUrl { get; set; } 
        public string User { get; set; }//mean who writed the post
        public DateTime CreatedAt { get; set; }
    }
}
