using Mapster;

namespace TournamentsRegister.Models.Responses;

public class PlayerResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [AdaptMember(nameof(Player.Name))]
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
