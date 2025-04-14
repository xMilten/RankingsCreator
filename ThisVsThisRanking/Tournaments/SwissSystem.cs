using System.Collections.ObjectModel;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.Tournaments;
public class SwissSystem {
    public List<(Participant, Participant)> GetEncounters(ObservableCollection<Participant> participants) {
        List<(Participant, Participant)> participantEncounters = new();

        // TODO Swiss System

        return participantEncounters;
    }
}