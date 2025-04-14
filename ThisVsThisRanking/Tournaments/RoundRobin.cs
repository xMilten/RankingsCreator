using System.Collections.ObjectModel;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.Tournaments;
public class RoundRobin {
    public List<(Participant, Participant)> GetEncounters(ObservableCollection<Participant> participants) {
        List<(Participant, Participant)> participantEncounters = new();


        for (byte i = 0; i < participants.Count; i++) {
            for (byte j = (byte)(i + 1); j < participants.Count; j++) {
                participantEncounters.Add((participants[i], participants[j]));
            }
        }

        return participantEncounters;
    }
}