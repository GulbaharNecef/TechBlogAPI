using System.ComponentModel.DataAnnotations.Schema;

namespace TechBlogAPI.Entities
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        [NotMapped]
        public override string CreatedBy { get; set; }

    }
}
