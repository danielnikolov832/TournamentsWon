using TournamentsRegister.Models;

namespace TournamentValidator.MatchLogic;

public class MatchResultLogic
{
}

public record class MatchResult(Dictionary<Team, bool> get_teams);

public interface IMatchResultDeterminator<T>
    where T : notnull
{
    public MatchResult GetResult(IEnumerable<ScoreData<T>> scores);
}