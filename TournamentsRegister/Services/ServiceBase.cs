using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentQuery.Core;
using FluentValidation;
using FluentValidation.Results;

namespace TournamentsRegister.Services;

public class ServiceBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate, TRepository>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TPrimaryKeyUserDAO : PublicPrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate>
{
    public ServiceBase(TRepository repository)
    {
        _repository = repository;
    }

    private readonly TRepository _repository;

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserModel>? query = null)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserDAO> query)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual TPrimaryKeyUserModel? GetById(int id)
    {
        return _repository.GetById(id);
    }

    protected virtual void HandleValidationOnInsertFail(ValidationResult result, IValidator<TInsert> validator, TInsert validatedObject)
    {
    }

    protected virtual void HandleValidationOnUpdateFail(ValidationResult result, IValidator<TUpdate> validator, TUpdate validatedObject)
    {
    }

    public virtual TPrimaryKeyUserModel? Insert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null,
        IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        return _repository.Insert(insert, currentInsertValidator, currentModelValidator, currentDaoValidator);
    }

    public virtual void Update(TUpdate update, IValidator<TUpdate>? currentUpdateValidator = null,
       IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        _repository.Update(update, currentUpdateValidator, currentModelValidator, currentDaoValidator);
    }

    public void Remove(TPrimaryKeyUserModel tournament)
    {
        _repository.Remove(tournament);
    }

    public virtual void Remove(int id)
    {
        _repository.Remove(id);
    }
}

public class ServiceBase<TPrimaryKeyUserModel, TInsert, TUpdate, TRepository>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndMapperBase<TPrimaryKeyUserModel, TInsert, TUpdate>
{
    public ServiceBase(TRepository repository)
    {
        _repository = repository;
    }

    private readonly TRepository _repository;

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserModel>? query = null)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual TPrimaryKeyUserModel? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public virtual TPrimaryKeyUserModel Insert(TInsert insert, IValidator<TInsert>? insertValidator = null)
    {
        insertValidator?.ValidateAndThrow(insert);

        return _repository.Insert(insert);
    }

    public virtual void Update(TUpdate update, IValidator<TUpdate>? updateValidator = null)
    {
        updateValidator?.ValidateAndThrow(update);

        _repository.Update(update);
    }

    public void Remove(TPrimaryKeyUserModel tournament)
    {
        _repository.Remove(tournament);
    }

    public virtual void Remove(int id)
    {
        _repository.Remove(id);
    }
}

public class ServiceBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TRepository>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TPrimaryKeyUserDAO : PublicPrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO>
{
    public ServiceBase(TRepository repository)
    {
        _repository = repository;
    }

    private readonly TRepository _repository;

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserModel>? query = null)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserDAO> query)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual TPrimaryKeyUserModel? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public virtual void Insert(TPrimaryKeyUserModel model, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        _repository.Insert(model, currentModelValidator, currentDaoValidator);
    }

    public virtual void Update(TPrimaryKeyUserModel model, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        _repository.Update(model, currentModelValidator, currentDaoValidator);
    }

    public void Remove(TPrimaryKeyUserModel tournament)
    {
        _repository.Remove(tournament);
    }

    public virtual void Remove(int id)
    {
        _repository.Remove(id);
    }
}