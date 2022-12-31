using EFCoreRepositoriesLib;
using FluentQuery;
using FluentQuery.Core;
using FluentQuery.SQLSupport;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.Models;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.DAL.Repositories;

public interface ITeamRepository : ICrudRepositoryWithPKAndMapperBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate>
{
    public List<Team> GetAllFromTournament(int TournamentID);
}

public class TeamRepository : CrudRepositoryWithPKAndMapperBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate>, ITeamRepository
{
    public TeamRepository(TournamentContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public List<Team> GetAllFromTournament(int TournamentID)
    {
        QueryBase<TeamDAO> query = new();

        query.RuleFor(teamDao => teamDao.TournamentDAOID, TournamentDAOID => TournamentDAOID == TournamentID);

        return GetAll(query);
    }

    public override Team Insert(TeamMiddleModelInsert model)
    {
        Team team = _mapper.Map<Team>(model);

        TeamDAO teamDao = _mapper.Map<TeamDAO>(team);

        teamDao.TournamentDAOID = model.TournamentID;

        _table.Add(teamDao);

        _dbContext.SaveChanges();

        return team;
    }

    public override void Update(TeamUpdate model)
    {
        TeamDAO? teamDao = _table.Where(x => x.ID == model.ID).Include(teamDao => teamDao.get_players).First();

        if (teamDao is null)
        {
            throw new ArgumentException("the model must have a valid TournamentDAOID", nameof(model));
        }

        teamDao.Name = model.Name;

        foreach (string removedPlayerName in model.RemovedPlayersNames)
        {
            teamDao.get_players.RemoveAll(player => player.Name == removedPlayerName);
        }

        foreach (string newPlayerName in model.NewPlayersNames)
        {
            teamDao.get_players.Add(new PlayerDAO() { Name = newPlayerName });
        }

        _table.Update(teamDao);

        _dbContext.SaveChanges();
    }

    public override IQueryable<TeamDAO> ApplyTransformations(IQueryable<TeamDAO> entities)
    {
         return entities.Include(dao => dao.get_players);
    }
}