using OmamagotoApp.Pages;
using OmamagotoApp.ViewModels;

namespace OmamagotoApp;

public partial class MainPage : ContentPage
{
	int _count = 0;

	public MainPage() : this(new MainViewModel())
	{
	}

	public MainPage(MainViewModel viewModel)
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

	private async void OnCreateProductClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ProductEditPage));
	}

}
