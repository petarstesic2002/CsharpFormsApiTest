namespace API.Application.Dto
{
    public class AppError
    {
        public Exception Exception { get; set; }
        public Guid ErrorId {  get; set; }
    }
}
