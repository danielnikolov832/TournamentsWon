using Mapster;

namespace TournamentsRegister.Models.Responses;

public class TeamResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [AdaptMember(nameof(Team.Name))]
    public string Name { get; set; }

    [AdaptMember(nameof(Team.get_players))]
    public List<PlayerResponse> Players { get; set; } = new();
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
