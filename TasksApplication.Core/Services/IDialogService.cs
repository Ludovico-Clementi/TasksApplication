using System.Threading.Tasks;

namespace TasksApplication.Core.Services;

public interface IDialogService
{
    Task ShowAsync(string title, string message);
}
