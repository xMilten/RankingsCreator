using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ThisVsThisRanking.ViewModels;
public class CreateVsListViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<Participant> Participants { get; } = new();
    public List<string> Tournaments { get; }

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public CreateVsListViewModel() {
        Tournaments = new List<string>() {
            "Round Robin (Jeder gegen Jeden)",
            "Swiss System (Kurz & Fair)"
        };
    }

    public void AddParticipant(string name, string imageSource) {
        Participants.Add(new Participant(name, imageSource));
    }

    public class Participant {
        /// <summary>
        /// Der Name des Teilnehmers
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Die Bildquelle des Teilnehmers
        /// </summary>
        public string ImageSource { get; }
        /// <summary>
        /// Die Punkte des Teilnehmers
        /// </summary>
        public byte Score { get; set; }
        /// <summary>
        /// Die Liste der bisherigen Gegner
        /// </summary>
        public List<string> PreviousOpponents { get; }

        public Participant(string name, string imageSource) {
            Name = name;
            ImageSource = imageSource;
            Score = 0;
            PreviousOpponents = new List<string>();
        }
    }
}