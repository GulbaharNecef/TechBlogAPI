namespace TechBlogAPI.Exceptions
{
    public class InvalidIdFormatException: Exception
    {
        public InvalidIdFormatException() { }

        public InvalidIdFormatException(string id) : base($"Invalid id: {id}") { }

        public InvalidIdFormatException(string message, Exception inner) : base(message, inner) { }
    }
}
