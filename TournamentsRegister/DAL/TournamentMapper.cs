using MapsterMapper;
using TournamentsRegister.Models;
using TournamentsRegister.Models.MiddleModelsForDAL;

namespace TournamentsRegister.DAL;

public class TournamentMapper : Mapper
{
	public TournamentMapper()
	{
		Config.NewConfig<TeamMiddleModelInsert, Team>()
			.Map(team => team.get_players,
				insert => from string playerName in insert.PlayerNames
						  select new Player()
						  {
							  Name = playerName
						  });
    }
}