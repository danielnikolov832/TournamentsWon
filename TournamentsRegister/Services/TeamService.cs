using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models;
using TournamentsRegister.DAL.Repositories;
using TournamentsRegister.Models.MiddleModelsForDAL;
using FluentQuery.Core;
using TournamentsRegister.DAL.DAOs;
using FluentValidation;
using EFCoreRepositoriesLib;
using TournamentsRegister.Validators.ForModels;
using TournamentsRegister.Validators.ForRequests;

namespace TournamentsRegister.Services;

public class TeamService : ServiceBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate, ITeamRepository>
{
    public TeamService(ITeamRepository repository, ITournamentRepository tournamentRepo) : base(repository)
    {
        _tournamentRepo = tournamentRepo;
    }

    private readonly ITournamentRepository _tournamentRepo;

    public List<Team> GetAllFromTournament(int tournamentID)
    {
        QueryBase<TeamDAO> query = new();

        query.RuleFor(team => team.TournamentDAOID, tournamentDAOID => tournamentDAOID == tournamentID);

        return GetAll(query);
    }

    public override Team? TryInsert(TeamMiddleModelInsert insert, IValidator<TeamMiddleModelInsert>? currentInsertValidator = null,
        IValidator<Team>? currentModelValidator = null, IValidator<TeamDAO>? currentDaoValidator = null)
    {
        Tournament? parentTournament = _tournamentRepo.GetById(insert.TournamentID);

        if (parentTournament is null)
        {
            return null;
        }

        IValidator<TeamMiddleModelInsert> teamValidator = new TeamInsertValidatorForParentTournament(parentTournament);

        if (teamValidator.Validate(insert).IsValid)
        {
            return base.Insert(insert, currentInsertValidator, currentModelValidator, currentDaoValidator);
        }

        return null;
    }
}