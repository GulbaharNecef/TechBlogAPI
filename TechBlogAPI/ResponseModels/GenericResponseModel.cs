namespace TechBlogAPI.ResponseModels
{
    public class GenericResponseModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
    }
}
