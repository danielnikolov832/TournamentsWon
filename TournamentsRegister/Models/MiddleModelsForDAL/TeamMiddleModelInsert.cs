using Mapster;

namespace TournamentsRegister.Models.MiddleModelsForDAL;

public class TeamMiddleModelInsert
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public int TournamentID { get; set; }

    [AdaptMember(nameof(Team.Name))]
    public string Name { get; set; }
    public List<string> PlayerNames { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
