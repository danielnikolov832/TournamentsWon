using TournamentsRegister.Models;
using TournamentValidator.Models;

namespace TournamentValidator.ValidationLogic;

public static class ValidationLogic
{
    public static bool IsInRange<T>(this T value, MinMaxRange<T> range)
        where T : IComparable<T>
    {
        return (value.CompareTo(range.Min) > 0) && (value.CompareTo(range.Max) < 0);
    }

    public static bool IsValueInRange<T>(this MinMaxRange<T> range, T value)
        where T : IComparable<T>
    {
        return IsInRange(value, range);
    }

    public static bool ValidateTournament(this StandardTournamentValidationData tournamentValidationData, Tournament tournament)
    {
        if (!tournament.Name.Length.IsInRange(tournamentValidationData.LengthOfNameRange)) return false;
        if (!tournament.Description.Length.IsInRange(tournamentValidationData.LengthOfDescriptionRange)) return false;
        if (!tournament.get_teams.Count.IsInRange(tournamentValidationData.NumberOfTeamsRange)) return false;

        StandardTeamValidationData? sharedTeamValidation = tournamentValidationData.SharedTeamValidation;

        if (sharedTeamValidation is null) return true;

        foreach (Team team in tournament.get_teams)
        {
            if (!sharedTeamValidation.ValidateTeam(team)) return false;
        }

        return true;
    }

    public static bool ValidateTeam(this StandardTeamValidationData teamValidationData, Team team)
    {
        if (!teamValidationData.LengthOfNameRange.IsValueInRange(team.Name.Length)) return false;
        if (!teamValidationData.NumberOfPlayersLength.IsValueInRange(team.get_players.Count)) return false;

        StandardPlayerValidationData? sharedPlayerValidation = teamValidationData.SharedPlayerValidation;

        if (sharedPlayerValidation is null) return true;

        foreach (Player player in team.get_players)
        {
            if (!sharedPlayerValidation.ValidatePlayer(player)) return false;
        }

        return true;
    }

    public static bool ValidatePlayer(this StandardPlayerValidationData playerValidationData, Player player)
    {
        return playerValidationData.LengthOfNameRange.IsValueInRange(player.Name.Length);
    }
}