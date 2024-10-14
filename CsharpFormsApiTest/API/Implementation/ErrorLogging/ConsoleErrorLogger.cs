using API.Application.Dto;
using API.Application.Interfaces;
using System.Text;

namespace API.Implementation.ErrorLogging
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Log(AppError error)
        {
            DateTime timestamp = DateTime.UtcNow;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Id: " + error.ErrorId);
            stringBuilder.AppendLine("Timestamp: " + timestamp.ToString());
            stringBuilder.AppendLine("Exception Message: " + error.Exception.Message);
            stringBuilder.AppendLine("Exception Stack Trace: ");
            stringBuilder.AppendLine(error.Exception.StackTrace);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
