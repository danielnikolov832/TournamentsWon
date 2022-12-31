using Mapster;

namespace TournamentsRegister.Models.MiddleModelsForDAL;

public class TeamMiddleModelInsert
{
    public int TournamentID { get; set; }

    [AdaptMember(nameof(Team.Name))]
    public string Name { get; set; }
    public List<string> PlayerNames { get; set; }
}
