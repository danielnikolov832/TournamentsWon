using EFCoreRepositoriesLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentsRegister.DAL.DAOs;

#pragma warning disable S101 // Types should be named in PascalCase
public class PlayerDAO : PublicPrimaryKeyUser
#pragma warning restore S101 // Types should be named in PascalCase
{
    [MaxLength(300)]
    public string? Name { get; set; }
    public int TeamDAOID { get; set; }
}