using System.ComponentModel;
using System.Windows.Controls;
using ThisVsThisRanking.UserControls;

namespace ThisVsThisRanking.ViewModels;
public class MainViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    private ContentControl _contenControl;

    public ContentControl ContentControl {
        get { 
            return _contenControl; 
        } 
        set {
            if (_contenControl != value) {
                _contenControl = value;
                OnPropertyChanged(nameof(ContentControl));
            }
        }
    }

    public MainViewModel() {
        ContentControl = new CreateVsListUserControl(SwitchContent);
    }

    public void SwitchContent(ContentControl contentControl) {
        ContentControl = contentControl;
    }

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
