namespace TournamentValidator.Models;

public class StandardPlayerValidationData
{
    public MinMaxRange<int> LengthOfNameRange { get; init; } = new();
}