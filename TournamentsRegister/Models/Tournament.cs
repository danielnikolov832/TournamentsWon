using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Tournament : ReadOnlyPrimaryKeyUser
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Team> get_teams { get; set; } = new();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}