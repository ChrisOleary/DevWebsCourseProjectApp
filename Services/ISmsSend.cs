using System.Threading.Tasks;

namespace DevWebsCourseProjectApp.Services
{
   public interface ISmsSend
    {
        Task SendSmsAsync(string number, string message);
    }
}
