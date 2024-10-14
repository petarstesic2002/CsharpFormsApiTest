using API.Application.Dto;

namespace API.Application.Interfaces
{
    public interface IErrorLogger
    {
        public void Log(AppError error);
    }
}
