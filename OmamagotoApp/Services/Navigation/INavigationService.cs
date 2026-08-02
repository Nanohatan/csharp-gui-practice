
namespace OmamagotoApp.Services.Navigation;

public interface INavigationService
{
    Task GoToAsync(string route);
}