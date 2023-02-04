using Mapster;

namespace TournamentsRegister.Models.Responses;

public class TournamentResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [AdaptMember(nameof(Tournament.ID))]
    public int ID { get; set; }

    [AdaptMember(nameof(Tournament.Name))]
    public string Name { get; set; }

    [AdaptMember(nameof(Tournament.Description))]
    public string Description { get; set; }

    [AdaptMember(nameof(Tournament.get_teams))]
    public List<TeamResponse> Teams { get; set; } = new();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
