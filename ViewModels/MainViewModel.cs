using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace maui_glass.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _statusText = "Status from VM";
    public string StatusText
    {
        get => _statusText;
        set
        {
            if (_statusText != value)
            {
                _statusText = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}