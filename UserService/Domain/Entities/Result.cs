namespace UserService.Domain.Entities
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; } = 200;
    }

}
