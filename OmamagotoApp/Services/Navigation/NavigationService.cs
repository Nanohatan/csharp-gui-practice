
namespace OmamagotoApp.Services.Navigation;

public sealed class NavigationService : INavigationService
{
    public Task GoToAsync(string route)
    {
        return Shell.Current.GoToAsync(route);
    }
}