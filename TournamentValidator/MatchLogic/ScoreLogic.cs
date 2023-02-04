using System.Reflection;
using TournamentsRegister.Models;

namespace TournamentValidator.MatchLogic;

public class ScoreData<T>
    where T : notnull
{
    public ScoreData(T score, Team team)
    {
        Score = score;
        get_team = team;
    }

    protected ScoreData()
    {
    }

    public T Score { get; set; }

    public Team get_team { get; private set; }

    internal void Populate(T score, Team team)
    {
        Score = score;
        get_team = team;
    }
}

public interface IScoreChanger<TScore, TChanger>
    where TScore : notnull
{
    TScore ChangeScore(TScore score, TChanger changer);
}

public static class ScoreLogic
{
    public static void 
}