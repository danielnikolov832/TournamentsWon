using Mapster;
using System.ComponentModel.DataAnnotations;

namespace TournamentsRegister.Models.Requests;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class TeamInsert
{
    [Required(AllowEmptyStrings = false)]
    [AdaptMember(nameof(Team.Name))]
    public string Name { get; set; }
    [AdaptIgnore]
    public List<string>? PlayerNames { get; set; }
}

public class TeamUpdate
{
    [Required(AllowEmptyStrings = false)]
    [AdaptMember("ID")]
    public int ID { get; set; }

    [Required(AllowEmptyStrings = false)]
    [AdaptMember(nameof(Team.Name))]
    public string Name { get; set; }
    [AdaptIgnore]
    public List<string> NewPlayersNames { get; set; }
    [AdaptIgnore]
    public List<string> RemovedPlayersNames { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.