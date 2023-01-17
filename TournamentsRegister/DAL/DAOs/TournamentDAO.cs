using EFCoreRepositoriesLib;
using System.ComponentModel.DataAnnotations;
using TournamentsRegister.Constants;

namespace TournamentsRegister.DAL.DAOs;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable S101 // Types should be named in PascalCase
public class TournamentDAO : PublicPrimaryKeyUser
#pragma warning restore S101 // Types should be named in PascalCase
{
    [MaxLength(ModelAttributesConstants.TournamentNameMaxLength)]
    public string? Name { get; set; }

    [MaxLength(ModelAttributesConstants.TournamentDescriptionMaxLength)]
    public string? Description { get; set; }
    public List<TeamDAO> Teams { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
