using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models;
using FluentQuery;
using TournamentsRegister.DAL.Repositories;
using FluentQuery.Core;
using TournamentsRegister.DAL.DAOs;

namespace TournamentsRegister.Services;

public class TournamentService : ServiceBase<Tournament, TournamentDAO, TournamentInsert, TournamentUpdate, ITournamentRepository>
{
	public TournamentService(ITournamentRepository tournamentRepository) : base(tournamentRepository)
	{
	}
}