using System.IO;
using System.Windows;
using System.Windows.Controls;
using ThisVsThisRanking.DialogWindows;
using ThisVsThisRanking.ViewModels;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.UserControls;
/// <summary>
/// Interaktionslogik für CreateVsListUserControl.xaml
/// </summary>
public partial class CreateVsListUserControl : UserControl {
    private CreateVsListViewModel _viewModel;
    private Action<ContentControl> _SwitchContent;

    public CreateVsListUserControl(Action<ContentControl> switchContent) {
        InitializeComponent();
        _SwitchContent = switchContent;
        _viewModel = new CreateVsListViewModel();
        DataContext = _viewModel;

        combobox.SelectedIndex = 0;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e) {
        var ownerWindow = Window.GetWindow(this);
        DialogAddParticipantWindow dialogAddParticipant = new();
        dialogAddParticipant.Owner = ownerWindow;
        bool? result = dialogAddParticipant.ShowDialog();

        if (result == true) {
            if (dialogAddParticipant.FileNames != null) {
                foreach (string file in dialogAddParticipant.FileNames) {
                    _viewModel.AddParticipant(Path.GetFileNameWithoutExtension(file), file);
                }
                return;
            }
            _viewModel.AddParticipant(dialogAddParticipant.inputName.Text, dialogAddParticipant.inputImage.Text);
        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        _SwitchContent(new PlayUserControl(_viewModel.Participants, _SwitchContent, (byte)combobox.SelectedIndex));
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            if (button.DataContext is Participant item) {
                _viewModel.Participants.Remove(item);
            }
        }
    }
}
