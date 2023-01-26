using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentQuery.Core;
using FluentValidation;
using Mapster;
using MapsterMapper;
using TournamentsRegister.DAL.DAOs;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.DAL.Repositories
{
    public interface IPlayerRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<Player, PlayerDAO, PlayerInsert, PlayerUpdate>
    {
    }

    public class PlayerRepository : CrudRepositoryWithPKAndMapperAndValidationBase<Player, PlayerDAO, PlayerInsert, PlayerUpdate>, IPlayerRepository
    {
        public PlayerRepository(TournamentContext dbContext, IMapper mapper,
            IValidator<Player>? defaultIModelValidator = null, IValidator<PlayerDAO>? defaultDaoValidator = null,
            IValidator<PlayerInsert>? defaultInsertValidator = null, IValidator<PlayerUpdate>? defaultUpdateValidator = null)
            : base(dbContext, mapper, defaultIModelValidator, defaultDaoValidator, defaultInsertValidator, defaultUpdateValidator)
        {
        }

        protected override Player? InsertInternal(PlayerInsert insert, IValidator<Player>? modelValidator = null, IValidator<PlayerDAO>? daoValidator = null)
        {
            Player player = insert.Adapt<Player>();

            if (!ValidateModel(player, modelValidator)) return null;

            PlayerDAO entity = Adapt(player);

            if (!ValidateDAO(entity, daoValidator)) return null;

            entity.TeamDAOID = insert.TeamID;

            _table.Add(entity);

            _dbContext.SaveChanges();

            return player;
        }

        protected override void UpdateInternal(PlayerUpdate update, IValidator<Player>? modelValidator = null, IValidator<PlayerDAO>? daoValidator = null)
        {
            QueryBase<PlayerDAO> query = new();

            query.RuleFor(dao => dao.TeamDAOID, teamDaoID => teamDaoID == update.TeamID);
            query.RuleFor(dao => dao.Name, name => name == update.OldPlayerName);

            IEnumerable<PlayerDAO> filteredTable = _table.Query(query, this);

            PlayerDAO entity = filteredTable.Single();

            entity.Name = update.NewPlayerName;

            if (!ValidateDAO(entity, daoValidator)) return;

            _table.Update(entity);

            _dbContext.SaveChanges();
        }
    }
}
