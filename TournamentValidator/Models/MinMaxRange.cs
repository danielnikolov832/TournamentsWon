namespace TournamentValidator.Models;

public readonly struct MinMaxRange<T>
    where T : IComparable<T>
{
    public MinMaxRange(T? min = default, T? max = default)
    {
        Min = min;
        Max = max;
    }

    public T? Min { get; init; }
    public T? Max { get; init; }
}