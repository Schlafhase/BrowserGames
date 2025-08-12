namespace BrowserGames.Games.Pretender;

public class PretenderGame
{
    public int PlayerCount { get; private set; }
    public int CurrentPlayer { get; private set; }

    public PretenderMode Mode { get; private init; }
    public string Word { get; private init; }
    public string? PretendersWord { get; private init; }
    public int Pretender;

    public PretenderState State { get; private set; } = PretenderState.Submitting;

    public readonly string[] Submissions;
    
    public PretenderGame(PretenderMode mode, string word, string? pretendersWord = null, int playerCount = 1)
    {
        Mode = mode;
        Word = word;
        PlayerCount = playerCount;
        Submissions = new string[playerCount];
    }

    public void Submit(string word)
    {
        if (State != PretenderState.Submitting)
        {
            throw new InvalidOperationException("Currently not accepting submissions");
        }
        Submissions[CurrentPlayer] = word;
        CurrentPlayer++;
        
        if (CurrentPlayer == PlayerCount)
        {
            State = PretenderState.Voting;
        }
    }
    
    public void Vote()
}

public enum PretenderMode
{
    Confusing,
    Hard
}

public enum PretenderState
{
    Submitting,
    Voting
}