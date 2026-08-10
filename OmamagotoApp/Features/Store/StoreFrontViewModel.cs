
using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.ViewModels;
using OmamagotoApp.Services.Navigation;

using System.Collections.ObjectModel;
using OmamagotoApp.Features.Products.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OmamagotoApp.Features.Store;

public partial class StoreFrontViewModel : PageViewModel
{
    public StoreFrontViewModel(
        IDialogService dialogService,
        INavigationService navigationService)
        : base(dialogService, navigationService)
    {
    }

    public ObservableCollection<Product> Products { get; } = new()
    {
        new Product
        {
            Name = "りんご",
            Price = 200,
        },
        new Product
        {
            Name = "ぎゅうにゅう",
            Price = 180,
            ImageSource = "milk.jpg"
        },
        new Product
        {
            Name = "パン",
            Price = 150,
            ImageSource = "bread.jpg"
        },
        new Product
        {
            Name = "バナナ",
            Price = 120,
            ImageSource = "banana.jpg"
        }
    };
}