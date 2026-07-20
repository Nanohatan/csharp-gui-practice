using Avalonia.Controls;

using CounterApp.ViewModels;

namespace CounterApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new CounterViewModel();
    }
}