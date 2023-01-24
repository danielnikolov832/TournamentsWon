using FluentQuery.Core;
using FluentValidation;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.DAL.Repositories;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Services;

public class PlayerService : ServiceBase<Player, PlayerDAO, PlayerInsert, PlayerUpdate, IPlayerRepository>
{
    public PlayerService(IPlayerRepository repository,
        IValidator<PlayerInsert>? defaultInsertValidator = null, IValidator<PlayerUpdate>? defaultUpdateValidator = null,
        IValidator<Player>? defaultModelValidator = null, IValidator<PlayerDAO>? defaultDaoValidator = null)
        : base(repository, defaultInsertValidator, defaultUpdateValidator, defaultModelValidator, defaultDaoValidator)
    {
    }

    public List<Player> GetAllFromTeam(int teamID)
    {
        QueryBase<PlayerDAO> query = new();

        query.RuleFor(dao => dao.TeamDAOID, teamDAOID => teamDAOID == teamID);

        return GetAll(query);
    }

    public void RemoveFromRequest(PlayerDelete delete)
    {
        List<Player> playersFromTeam = GetAllFromTeam(delete.TeamID);

        Player player = playersFromTeam.Single(childPlayer => childPlayer.Name == delete.PlayerName);

        Remove(player);
    }
}
