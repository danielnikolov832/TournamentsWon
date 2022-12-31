using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL.DAOs;

namespace TournamentsRegister.DAL;

public class TournamentContext : DbContext
{
	public TournamentContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<TournamentDAO> TournamentDAOs { get; set; }
	public DbSet<TeamDAO> TeamDAOs { get; set; }
	public DbSet<PlayerDAO> PlayerDAOs { get; set; }
}