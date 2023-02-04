namespace TournamentValidator.Models;

public class StandardTournamentValidationData
{
    public MinMaxRange<int> NumberOfTeamsRange { get; init; } = new();
    public MinMaxRange<int> LengthOfNameRange { get; init; } = new();
    public MinMaxRange<int> LengthOfDescriptionRange { get; init; } = new();
    public StandardTeamValidationData? SharedTeamValidation { get; init; }
}