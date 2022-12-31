using EFCoreRepositoriesLib;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.DAL.Repositories;

public interface ITournamentRepository : ICrudRepositoryWithPKAndMapperBase<Tournament, TournamentDAO, TournamentInsert, TournamentUpdate>
{
}

public class TournamentRepository : CrudRepositoryWithPKAndMapperBase<Tournament, TournamentDAO, TournamentInsert, TournamentUpdate>, ITournamentRepository
{
    public TournamentRepository(TournamentContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override Tournament Insert(TournamentInsert model)
    {
        Tournament tournament = _mapper.Map<Tournament>(model);

        _table.Add(Adapt(tournament));

        _dbContext.SaveChanges();

        return tournament;
    }

    public override void Update(TournamentUpdate model)
    {
        Tournament tournament = _mapper.Map<Tournament>(model);

        _table.Update(Adapt(tournament));

        _dbContext.SaveChanges();
    }

    public override IQueryable<TournamentDAO> ApplyTransformations(IQueryable<TournamentDAO> entities)
    {
        return entities.Include(dao => dao.Teams)
            .ThenInclude(team => team.get_players);
    }
}