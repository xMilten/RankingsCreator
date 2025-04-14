using System.Collections.ObjectModel;
using System.ComponentModel;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.ViewModels;
public class EvaluationViewModel {
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<Participant> Participants { get; } = new();

    public EvaluationViewModel(ObservableCollection<Participant> participants) {
        Participants = participants;
        Participants = new ObservableCollection<Participant>(Participants.OrderByDescending(participant => participant.Score));
    }

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}