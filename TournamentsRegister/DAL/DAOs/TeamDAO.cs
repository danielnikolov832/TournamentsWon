using EFCoreRepositoriesLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TournamentsRegister.Constants;

namespace TournamentsRegister.DAL.DAOs;

#pragma warning disable S101 // Types should be named in PascalCase
public class TeamDAO : PublicPrimaryKeyUser
#pragma warning restore S101 // Types should be named in PascalCase
{
    [MaxLength(ModelAttributesConstants.TeamNameMaxLength)]
    public string? Name { get; set; }
    public List<PlayerDAO> get_players { get; set; } = new();
    public int TournamentDAOID { get; set; }
}