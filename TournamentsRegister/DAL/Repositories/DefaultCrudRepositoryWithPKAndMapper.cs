using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace TournamentsRegister.DAL.Repositories;

public abstract class DefaultCrudRepositoryWithPKAndMapper<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate, TRepository>
    : CrudRepositoryWithPKAndMapperAndValidationBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TPrimaryKeyUserDAO : PublicPrimaryKeyUser
    where TRepository : DefaultCrudRepositoryWithPKAndMapper<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate, TRepository>
{
    protected DefaultCrudRepositoryWithPKAndMapper(DbContext dbContext, IMapper mapper,
        IValidator<TPrimaryKeyUserModel>? defaultIModelValidator = null, IValidator<TPrimaryKeyUserDAO>? defaultDaoValidator = null,
        IValidator<TInsert>? defaultInsertValidator = null, IValidator<TUpdate>? defaultUpdateValidator = null)
        : base(dbContext, mapper, defaultIModelValidator, defaultDaoValidator, defaultInsertValidator, defaultUpdateValidator)
    {
    }
}