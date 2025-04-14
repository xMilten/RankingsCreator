using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ThisVsThisRanking.Tournaments;
using static ThisVsThisRanking.ViewModels.CreateVsListViewModel;

namespace ThisVsThisRanking.ViewModels;
public class PlayViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    private string _participantName;
    private string _opponentsName;
    private string _participantImageSource;
    private string _opponentsImageSource;
    private int _currentEncounter;
    private int _maxEncounters;

    private Random _random;
    private List<(Participant, Participant)> _participantEncounters;

    public Participant Participant { get; private set; }
    public Participant Opponent { get; private set; }

    /// <summary>
    /// Der Anzeigename des Teilnehmers
    /// </summary>
    public string ParticipantName {
        get {
            return _participantName;
        }
        set {
            if (_participantName != value) {
                _participantName = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Der Anezigename des Gegners
    /// </summary>
    public string OpponentsName {
        get {
            return _opponentsName;
        }
        set {
            if (_opponentsName != value) {
                _opponentsName = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Die Bildquelle des Teilnehmers
    /// </summary>
    public string ParticipantImageSource {
        get {
            return _participantImageSource;
        }
        set {
            if (_participantImageSource != value) {
                _participantImageSource = value;
                OnPropertyChanged();
            }
        }
    }
    
    /// <summary>
    /// Die Bildquelle des Gegners
    /// </summary>
    public string OpponentsImageSource {
        get {
            return _opponentsImageSource;
        }
        set {
            if (_opponentsImageSource != value) {
                _opponentsImageSource = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Die aktuelle Begegnung
    /// </summary>
    public int CurrentEncounter {
        get {
            return _currentEncounter;
        }
        set {
            if (_currentEncounter != value) {
                _currentEncounter = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Die maximalen Begegnungen
    /// </summary>
    public int MaxEncounters {
        get {
            return _maxEncounters;
        }
        set {
            if (_maxEncounters != value) {
                _maxEncounters = value;
                OnPropertyChanged();
            }
        }
    }

    public PlayViewModel(ObservableCollection<Participant> participants, byte tournamentChoice) {
        _random = new Random();
        _participantEncounters = new List<(Participant, Participant)>();
        CreateTournament(participants, tournamentChoice);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void CreateTournament(ObservableCollection<Participant> participants, byte tournamentChoice) {
        _participantEncounters.Clear();

        if (tournamentChoice == 0)
            _participantEncounters = new RoundRobin().GetEncounters(participants);
        if (tournamentChoice == 1)
            _participantEncounters = new SwissSystem().GetEncounters(participants);

        MaxEncounters = _participantEncounters.Count;
        NextEncounter();
    }

    private void NextEncounter() {
        CurrentEncounter++;
        var pair = _participantEncounters[_random.Next(_participantEncounters.Count)];
        _participantEncounters.Remove(pair);
        List<Participant> pairParticipants = new List<Participant>() {
            pair.Item1,
            pair.Item2
        };

        // Das Paar per Zufall auf link und rechts verteilen.
        byte randomIndex = (byte)_random.Next(pairParticipants.Count);

        Participant = pairParticipants[randomIndex];
        pairParticipants.RemoveAt(randomIndex);

        ParticipantName = Participant.Name;
        ParticipantImageSource = Participant.ImageSource;

        Opponent = pairParticipants[0];

        OpponentsName = Opponent.Name;
        OpponentsImageSource = Opponent.ImageSource;
    }

    public void DetermineWinner(byte winner) {
        if (winner == 0) {
            Participant.Score++;
        } else {
            Opponent.Score++;
        }

        NextEncounter();
    }
}