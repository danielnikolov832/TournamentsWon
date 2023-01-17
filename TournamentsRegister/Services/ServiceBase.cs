using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentQuery.Core;
using FluentValidation;
using FluentValidation.Results;

namespace TournamentsRegister.Services;

internal static class ServiceHelper
{
    internal static IValidator<T>? GetValidator<T>(IValidator<T>? currentValidator = null, IValidator<T>? defaultValidator = null)
    {
        return currentValidator ?? defaultValidator;
    }
}

public class ServiceBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate, TRepository>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TPrimaryKeyUserDAO : PublicPrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndMapperAndValidationBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate>
{
    public ServiceBase(TRepository repository, IValidator<TInsert>? defaultInsertValidator = null, IValidator<TUpdate>? defaultUpdateValidator = null,
        IValidator<TPrimaryKeyUserModel>? defaultModelValidator = null, IValidator<TPrimaryKeyUserDAO>? defaultDaoValidator = null)
    {
        _repository = repository;

        _repository.getset_handleValidationOnInsertFail = HandleValidationOnInsertFail;
        _repository.getset_handleValidationOnUpdateFail = HandleValidationOnUpdateFail;
        _repository.getset_handleValidationOnModelFail = HandleValidationOnModelFail;
        _repository.getset_handleValidationOnDaoFail = HandleValidationOnDaoFail;

        _defaultInsertValidator = defaultInsertValidator;
        _defaultUpdateValidator = defaultUpdateValidator;
        _defaultModelValidator = defaultModelValidator;
        _defaultDaoValidator = defaultDaoValidator;
    }

    private readonly TRepository _repository;

    private readonly IValidator<TInsert>? _defaultInsertValidator;
    private readonly IValidator<TUpdate>? _defaultUpdateValidator;
    private readonly IValidator<TPrimaryKeyUserModel>? _defaultModelValidator;
    private readonly IValidator<TPrimaryKeyUserDAO>? _defaultDaoValidator;

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
    protected virtual void HandleValidationOnModelFail(ValidationResult result, IValidator<TPrimaryKeyUserModel> validator, TPrimaryKeyUserModel validatedObject)
    {
    }

    protected virtual void HandleValidationOnDaoFail(ValidationResult result, IValidator<TPrimaryKeyUserDAO> validator, TPrimaryKeyUserDAO validatedObject)
    {
    }

    public virtual TPrimaryKeyUserModel Insert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null,
        IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        return _repository.Insert(insert, ServiceHelper.GetValidator(currentInsertValidator, _defaultInsertValidator),
            ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator), ServiceHelper.GetValidator(currentDaoValidator, _defaultDaoValidator));
    }

    public virtual TPrimaryKeyUserModel? TryInsert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null,
        IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        return _repository.TryInsert(insert, ServiceHelper.GetValidator(currentInsertValidator, _defaultInsertValidator),
            ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator), ServiceHelper.GetValidator(currentDaoValidator, _defaultDaoValidator));
    }

    public virtual void Update(TUpdate update, IValidator<TUpdate>? currentUpdateValidator = null,
       IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        _repository.Update(update, ServiceHelper.GetValidator(currentUpdateValidator, _defaultUpdateValidator),
            ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator), ServiceHelper.GetValidator(currentDaoValidator, _defaultDaoValidator));
    }

    public void Remove(TPrimaryKeyUserModel model)
    {
        _repository.Remove(model);
    }

    public virtual void Remove(int id)
    {
        _repository.Remove(id);
    }
}

public class ServiceBase<TPrimaryKeyUserModel, TInsert, TUpdate, TRepository>
    where TPrimaryKeyUserModel : ReadOnlyPrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndValidationBase<TPrimaryKeyUserModel, TInsert, TUpdate>
{
    public ServiceBase(TRepository repository, IValidator<TInsert>? currentInsertValidator = null,
        IValidator<TUpdate>? currentUpdateValidator = null, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null)
    {
        _repository = repository;
        _defaultInsertValidator = currentInsertValidator;
        _defaultUpdateValidator = currentUpdateValidator;
        _defaultModelValidator = currentModelValidator;

        repository.getset_handleValidationOnInsertFail = HandleValidationOnInsertFail;
        repository.getset_handleValidationOnUpdateFail = HandleValidationOnUpdateFail;
        repository.getset_handleValidationOnModelFail = HandleValidationOnModelFail;
    }

    private readonly TRepository _repository;

    private readonly IValidator<TInsert>? _defaultInsertValidator;
    private readonly IValidator<TUpdate>? _defaultUpdateValidator;
    private readonly IValidator<TPrimaryKeyUserModel>? _defaultModelValidator;

    protected virtual void HandleValidationOnInsertFail(ValidationResult result, IValidator<TInsert> validator, TInsert validatedObject)
    {
    }

    protected virtual void HandleValidationOnUpdateFail(ValidationResult result, IValidator<TUpdate> validator, TUpdate validatedObject)
    {
    }

    protected virtual void HandleValidationOnModelFail(ValidationResult result, IValidator<TPrimaryKeyUserModel> validator, TPrimaryKeyUserModel validatedObject)
    {
    }

    public virtual List<TPrimaryKeyUserModel> GetAll(IQuery<TPrimaryKeyUserModel>? query = null)
    {
        return (query is null) ? _repository.GetAll() : _repository.GetAll(query);
    }

    public virtual TPrimaryKeyUserModel? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public virtual TPrimaryKeyUserModel Insert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null)
    {
        return _repository.Insert(insert, ServiceHelper.GetValidator(currentInsertValidator, _defaultInsertValidator), ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator));
    }

    public virtual TPrimaryKeyUserModel? TryInsert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null)
    {
        return _repository.TryInsert(insert, ServiceHelper.GetValidator(currentInsertValidator, _defaultInsertValidator), ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator));
    }

    public virtual void Update(TUpdate update, IValidator<TUpdate>? currentUpdateValidator = null, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null)
    {
        _repository.Update(update, ServiceHelper.GetValidator(currentUpdateValidator, _defaultUpdateValidator), ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator));
    }

    public void Remove(TPrimaryKeyUserModel model)
    {
        _repository.Remove(model);
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
    public ServiceBase(TRepository repository, IValidator<TPrimaryKeyUserModel>? defaultModelValidator = null, IValidator<TPrimaryKeyUserDAO>? defaultDaoValidator = null)
    {
        _repository = repository;
        _defaultModelValidator = defaultModelValidator;
        _defaultDaoValidator = defaultDaoValidator;

        repository.getset_handleValidationOnModelFail = HandleValidationOnModelFail;
        repository.getset_handleValidationOnDaoFail = HandleValidationOnDaoFail;
    }

    private readonly TRepository _repository;

    private readonly IValidator<TPrimaryKeyUserModel>? _defaultModelValidator;
    private readonly IValidator<TPrimaryKeyUserDAO>? _defaultDaoValidator;

    protected virtual void HandleValidationOnModelFail(ValidationResult result, IValidator<TPrimaryKeyUserModel> validator, TPrimaryKeyUserModel validatedObject)
    {
    }

    protected virtual void HandleValidationOnDaoFail(ValidationResult result, IValidator<TPrimaryKeyUserDAO> validator, TPrimaryKeyUserDAO validatedObject)
    {
    }

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
        _repository.Insert(model, ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator), ServiceHelper.GetValidator(currentDaoValidator, _defaultDaoValidator));
    }

    public virtual void Update(TPrimaryKeyUserModel model, IValidator<TPrimaryKeyUserModel>? currentModelValidator = null, IValidator<TPrimaryKeyUserDAO>? currentDaoValidator = null)
    {
        _repository.Update(model, ServiceHelper.GetValidator(currentModelValidator, _defaultModelValidator), ServiceHelper.GetValidator(currentDaoValidator, _defaultDaoValidator));
    }

    public void Remove(TPrimaryKeyUserModel model)
    {
        _repository.Remove(model);
    }

    public virtual void Remove(int id)
    {
        _repository.Remove(id);
    }
}