using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Team : PrivatePrimaryKeyUser
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
    public List<Player> get_players { get; init; } = new();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}