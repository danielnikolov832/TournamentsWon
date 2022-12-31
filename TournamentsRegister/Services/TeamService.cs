using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models;
using TournamentsRegister.DAL.Repositories;
using TournamentsRegister.Models.MiddleModelsForDAL;
using FluentQuery.Core;
using TournamentsRegister.DAL.DAOs;

namespace TournamentsRegister.Services;

public class TeamService : ServiceBase<Team, TeamDAO, TeamMiddleModelInsert, TeamUpdate, ITeamRepository>
{
    public TeamService(ITeamRepository repository) : base(repository)
    {
    }

    public List<Team> GetAllFromTournament(int tournamentID)
    {
        QueryBase<TeamDAO> query = new();

        query.RuleFor(team => team.TournamentDAOID, tournamentDAOID => tournamentDAOID == tournamentID);

        return GetAll(query);
    }
}