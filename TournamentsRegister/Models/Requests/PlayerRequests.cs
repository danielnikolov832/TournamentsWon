using Mapster;
using System.ComponentModel.DataAnnotations;

namespace TournamentsRegister.Models.Requests;

public class PlayerInsert
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Required(AllowEmptyStrings = false)]
    [AdaptIgnore]
    public int TeamID { get; set; }

    [Required]
    [AdaptMember(nameof(Team.Name))]
    public string PlayerName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

public class PlayerUpdate
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Required(AllowEmptyStrings = false)]
    [AdaptIgnore]
    public int TeamID { get; set; }

    [Required(AllowEmptyStrings = false)]
    [AdaptIgnore]
    public string OldPlayerName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [AdaptMember(nameof(Player.Name))]
    public string NewPlayerName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

public class PlayerDelete
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Required(AllowEmptyStrings = false)]
    [AdaptIgnore]
    public int TeamID { get; set; }

    [Required(AllowEmptyStrings = false)]
    [AdaptMember(nameof(Player.Name))]
    public string PlayerName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}