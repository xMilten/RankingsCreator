using System.Collections.ObjectModel;
using System.Windows.Controls;
using ThisVsThisRanking.ViewModels;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.UserControls;
/// <summary>
/// Interaktionslogik für EvaluationUserControl.xaml
/// </summary>
public partial class EvaluationUserControl : UserControl {
    private EvaluationViewModel _viewModel;
    private ObservableCollection<Participant> _participants;
    private Action<ContentControl> _SwitchContent;

    public EvaluationUserControl(ObservableCollection<Participant> participants, Action<ContentControl> switchContent) {
        _participants = participants;
        _SwitchContent = switchContent;
        InitializeComponent();
        _viewModel = new EvaluationViewModel(_participants);
        DataContext = _viewModel;
    }

    private void NewListButton_Click(object sender, System.Windows.RoutedEventArgs e) {
        _SwitchContent(new CreateVsListUserControl(_SwitchContent));
    }
}