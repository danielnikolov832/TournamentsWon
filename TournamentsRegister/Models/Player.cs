using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Player : ReadOnlyPrimaryKeyUser
{
    public string? Name { get; set; }
}