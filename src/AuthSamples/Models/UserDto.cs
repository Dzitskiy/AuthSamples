namespace AuthSamples.Models
{
    public class UserDto
    {
        public bool IsAuthenticated { get; set; }   

        public List<object> Claims { get; set; } = new List<object>();

        public string Scheme { get; set; } 

    }
}