using EFCoreRepositoriesLib;

namespace TournamentsRegister.Models;

public class Tournament : ReadOnlyPrimaryKeyUser
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Team> Teams { get; set; }
}