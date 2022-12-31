using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Player : PrivatePrimaryKeyUser
{
    public string? Name { get; set; }
}