using TournamentsRegister.Models;

namespace TournamentValidator.MatchLogic;

public static class MatchMakerLogic
{
    public static void MakeBrackets(IEnumerable<Team> teams, int teamsPerMatch)
    {
        List<List<Team>> matches = new()
        {
            new()
        };

        int teamsInCurrentMatch = 0;
        int indexOfCurrentMatch = 0;

        foreach (Team team in teams)
        {
            if (teamsInCurrentMatch < teamsPerMatch)
            {
                matches[indexOfCurrentMatch].Add(team);

                teamsInCurrentMatch++;

                continue;
            }

            matches.Add(new());

            indexOfCurrentMatch++;

            teamsInCurrentMatch = 0;
        }
    }

    public static List<TScoreData> CreateScoreDatas<TScore, TScoreData>(List<Team> teams, TScore startingScore)
        where TScore : notnull
        where TScoreData : ScoreData<TScore>, new()
    {
        List<TScoreData> output = new();

        foreach (Team team in teams)
        {
            TScoreData scoreData = new();

            scoreData.Populate(startingScore, team);

            output.Add(scoreData);
        }

        return output;
    }
}

public interface IBracketsCreator<TScore>
    where TScore : notnull
{
    public List<Match<TScore, TScoreData>> MakeBrackets<TScoreData>(IEnumerable<Team> teams, int teamsPerMatch)
        where TScoreData : ScoreData<TScore>, new();
}

public interface IBracketsCreator<TScore, TScoreData>
    where TScore : notnull
    where TScoreData : ScoreData<TScore>, new()
{
    public List<Match<TScore, TScoreData>> MakeBrackets(IEnumerable<Team> teams, int teamsPerMatch);
}

public class Match<TScore, TScoreData>
    where TScore : notnull
    where TScoreData : ScoreData<TScore>, new()
{
    public Match(List<Team> teams, TScore startingScore)
    {
        get_scores = MatchMakerLogic.CreateScoreDatas<TScore, TScoreData>(teams, startingScore);
    }

    public List<TScoreData> get_scores { get; init; }
}