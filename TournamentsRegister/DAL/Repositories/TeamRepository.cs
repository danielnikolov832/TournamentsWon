using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentQuery.Core;
using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.Models;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.DAL.Repositories;

public interface ITeamRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate>
{
    public List<Team> GetAllFromTournament(int TournamentID);
}

public class TeamRepository : CrudRepositoryWithPKAndMapperAndValidationBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate>, ITeamRepository
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

    protected override Team? InsertInternal(TeamMiddleModelInsert insert, IValidator<Team>? modelValidator = null, IValidator<TeamDAO>? daoValidator = null)
    {
        Team team = _mapper.Map<Team>(insert);

        bool isModelValid = ValidateModel(team, modelValidator);

        if (!isModelValid) return null;

        TeamDAO teamDao = _mapper.Map<TeamDAO>(team);

        bool isDaoValid = ValidateDAO(teamDao, daoValidator);

        if (!isDaoValid) return null;

        teamDao.TournamentDAOID = insert.TournamentID;

        _table.Add(teamDao);

        _dbContext.SaveChanges();

        return team;
    }

    protected override void UpdateInternal(TeamUpdate update, IValidator<Team>? modelValidator = null, IValidator<TeamDAO>? daoValidator = null)
    {
        TeamDAO? teamDao = _table.Where(x => x.ID == update.ID).Include(teamDao => teamDao.get_players).First();

        if (teamDao is null)
        {
            throw new ArgumentException("the update must have a valid TournamentDAOID", nameof(update));
        }

        UpdateFromRequest(update, teamDao);

        bool isDaoValid = ValidateDAO(teamDao, daoValidator);

        if (!isDaoValid) return;

        _table.Update(teamDao);

        _dbContext.SaveChanges();

        static void UpdateFromRequest(TeamUpdate update, TeamDAO teamDao)
        {
            teamDao.Name = update.Name;

            foreach (string removedPlayerName in update.RemovedPlayersNames)
            {
                foreach (PlayerDAO playerDAO in teamDao.get_players)
                {
                    if (playerDAO.Name == removedPlayerName)
                    {
                        teamDao.get_players.Remove(playerDAO);
                    }
                }
            }

            foreach (string newPlayerName in update.NewPlayersNames)
            {
                teamDao.get_players.Add(new PlayerDAO() { Name = newPlayerName });
            }
        }
    }

    public override IQueryable<TeamDAO> ApplyTransformations(IQueryable<TeamDAO> entities)
    {
         return entities.Include(dao => dao.get_players);
    }
}