namespace TechBlogAPI.Entities
{
    public class BlogPost:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        //public int ViewCount { get; set; } = 0;
    }
}
