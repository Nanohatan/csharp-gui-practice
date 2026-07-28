
using OmamagotoApp.Services.Dialogs;

namespace OmamagotoApp.ViewModels;

public partial class MainViewModel : PageViewModel
{
    public MainViewModel(IDialogService dialogService)
        : base(dialogService)
    {
    }
}
