using EFCoreRepositoriesLib.FluentValidation;
using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.DAL.Repositories;

public interface ITournamentRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<Tournament, TournamentDAO, TournamentInsert, TournamentUpdate>
{
}

public class TournamentRepository : CrudRepositoryWithPKAndMapperAndValidationBase<Tournament, TournamentDAO, TournamentInsert, TournamentUpdate>, ITournamentRepository
{
    public TournamentRepository(TournamentContext dbContext, IMapper mapper,
        IValidator<Tournament>? defaultIModelValidator = null, IValidator<TournamentDAO>? defaultDaoValidator = null,
        IValidator<TournamentInsert>? defaultInsertValidator = null, IValidator<TournamentUpdate>? defaultUpdateValidator = null)
        : base(dbContext, mapper, defaultIModelValidator, defaultDaoValidator, defaultInsertValidator, defaultUpdateValidator)
    {
    }

    protected override Tournament? InsertInternal(TournamentInsert insert, IValidator<Tournament>? modelValidator = null, IValidator<TournamentDAO>? daoValidator = null)
    {
        Tournament tournament = _mapper.Map<Tournament>(insert);

        if(!ValidateModel(tournament, modelValidator)) return null;

        TournamentDAO entity = Adapt(tournament);

        if (!ValidateDAO(entity, daoValidator)) return null;

        _table.Add(entity);

        _dbContext.SaveChanges();

        return tournament;
    }

    protected override void UpdateInternal(TournamentUpdate update, IValidator<Tournament>? modelValidator = null, IValidator<TournamentDAO>? daoValidator = null)
    {
        Tournament tournament = _mapper.Map<Tournament>(update);

        if (!ValidateModel(tournament, modelValidator)) return;

        TournamentDAO entity = Adapt(tournament);

        if (!ValidateDAO(entity, daoValidator)) return;

        _table.Update(entity);

        _dbContext.SaveChanges();
    }

    public override IQueryable<TournamentDAO> ApplyTransformations(IQueryable<TournamentDAO> entities)
    {
        return entities.Include(dao => dao.Teams)
            .ThenInclude(team => team.get_players);
    }
}