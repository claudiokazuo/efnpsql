namespace Api.Models
{
    public class HttpResponseException : System.Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }
    }
}
