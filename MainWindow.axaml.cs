using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CounterApp;

public partial class MainWindow : Window
{
    private int _count;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CountButton_Click(object? sender, RoutedEventArgs e)
    {
        _count++;
        CountText.Text = _count.ToString();
    }
}