using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CounterApp.ViewModels;

public partial class CounterViewModel : ObservableObject
{
    [ObservableProperty]
    private int _count;

    [RelayCommand]
    private void Increment()
    {
        Count++;
    }

    [RelayCommand]
    private void Reset()
    {
        Count = 0;
    }
}