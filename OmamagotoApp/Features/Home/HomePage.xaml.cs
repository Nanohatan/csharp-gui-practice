using OmamagotoApp.Features.Products;

namespace OmamagotoApp.Features.Home;

public partial class HomePage : ContentPage
{
    int _count = 0;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        _count++;

        if (_count == 1)
            CounterBtn.Text = $"Clicked {_count} time";
        else
            CounterBtn.Text = $"Clicked {_count} times";
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
