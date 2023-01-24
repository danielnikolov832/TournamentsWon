using Mapster;
using System.ComponentModel.DataAnnotations;

namespace TournamentsRegister.Models.Requests;

public class TournamentInsert
{
    [Required(AllowEmptyStrings = false)]
    [AdaptMember(nameof(Tournament.Name))]
    public string? Name { get; set; }
    [AdaptMember(nameof(Tournament.Description))]
    public string? Description { get; set; }
}

public class TournamentUpdate
{
    [Required(AllowEmptyStrings = false)]
    public int ID { get; set; }

    [AdaptMember(nameof(Tournament.Name))]
    public string? Name { get; set; }
    [AdaptMember(nameof(Tournament.Description))]
    public string? Description { get; set; }
}
