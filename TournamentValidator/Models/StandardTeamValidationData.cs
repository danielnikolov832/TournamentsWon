namespace TournamentValidator.Models;

public class StandardTeamValidationData
{
    public MinMaxRange<int> NumberOfPlayersLength { get; init; } = new();
    public MinMaxRange<int> LengthOfNameRange { get; init; } = new();
    public StandardPlayerValidationData? SharedPlayerValidation { get; init; }
}