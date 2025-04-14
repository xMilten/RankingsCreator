using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using ThisVsThisRanking.ViewModels;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.UserControls;
/// <summary>
/// Interaktionslogik für PlayUserControl.xaml
/// </summary>
public partial class PlayUserControl : UserControl {
    private PlayViewModel _viewModel;
    private ObservableCollection<Participant> _participants;
    private Action<ContentControl> _SwitchContent;

    public PlayUserControl(ObservableCollection<Participant> participants, Action<ContentControl> switchContent, byte tournamentChoice) {
        InitializeComponent();
        _participants = participants;
        _SwitchContent = switchContent;
        _viewModel = new PlayViewModel(_participants, tournamentChoice);
        DataContext = _viewModel;
    }

    private void LeftButton_Click(object sender, RoutedEventArgs e) {
        if (SwitchContent()) { return; }
        _viewModel.DetermineWinner(0);
    }

    private void RightButton_Click(object sender, RoutedEventArgs e) {
        if (SwitchContent()) { return; }
        _viewModel.DetermineWinner(1);
    }

    private bool SwitchContent() {
        if (_viewModel.CurrentEncounter == _viewModel.MaxEncounters) {
            _SwitchContent(new EvaluationUserControl(_participants, _SwitchContent));
            return true;
        }

        return false;
    }
}
