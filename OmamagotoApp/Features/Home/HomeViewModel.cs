
using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.ViewModels;

namespace OmamagotoApp.Features.Home;

public partial class HomeViewModel : PageViewModel
{
    public HomeViewModel(IDialogService dialogService)
        : base(dialogService)
    {
    }
}
