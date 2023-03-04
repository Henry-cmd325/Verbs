namespace VerbsAPI.Models.Responses
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public string Error { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
