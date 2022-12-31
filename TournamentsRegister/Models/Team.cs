using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Team : PrivatePrimaryKeyUser
{
    public string? Name { get; set; }
    public List<Player> get_players { get; init; } = new();
}
