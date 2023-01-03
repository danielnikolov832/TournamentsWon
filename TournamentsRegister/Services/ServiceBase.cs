using EFCoreRepositoriesLib;
using EFCoreRepositoriesLib.FluentValidation;
using FluentQuery.Core;
using FluentValidation;
using FluentValidation.Results;

namespace TournamentsRegister.Services;

public class ServiceBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate, TRepository>
    where TPrimaryKeyUserModel : PrivatePrimaryKeyUser
    where TPrimaryKeyUserDAO : PublicPrimaryKeyUser
    where TRepository : ICrudRepositoryWithPKAndMapperBase<TPrimaryKeyUserModel, TPrimaryKeyUserDAO, TInsert, TUpdate>
{
    public ServiceBase(TRepository repository,
        IValidator<TInsert>? defaultInsertValidator = null, IValidator<TUpdate>? defaultUpdateValidator = null)
    {
        _repository = repository;
        _defaultInsertValidator = defaultInsertValidator;
        _defaultUpdateValidator = defaultUpdateValidator;
    }

    private readonly TRepository _repository;
    private readonly IValidator<TInsert>? _defaultInsertValidator;
    private readonly IValidator<TUpdate>? _defaultUpdateValidator;

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

    private static bool Validate<T>(Action<ValidationResult, IValidator<T>, T> handleFailAction,
        T objectToValidate, IValidator<T>? defaultValidator = null, IValidator<T>? currentValidator = null)
    {
        IValidator<T>? validator = currentValidator ?? defaultValidator;

        if (validator is null) return true;

        ValidationResult result = validator.Validate(objectToValidate);

        if (!result.IsValid)
        {
            handleFailAction(result, validator, objectToValidate);
        }

        return result.IsValid;
    }

    private bool ValidateInsert(TInsert objectToValidate, IValidator<TInsert>? currentValidator = null) => Validate(HandleValidationOnInsertFail, objectToValidate, _defaultInsertValidator, currentValidator);
    private bool ValidateUpdate(TUpdate objectToValidate, IValidator<TUpdate>? currentValidator = null) => Validate(HandleValidationOnUpdateFail, objectToValidate, _defaultUpdateValidator, currentValidator);

    protected virtual void HandleValidationOnInsertFail(ValidationResult result, IValidator<TInsert> validator, TInsert validatedObject)
    {
    }

    protected virtual void HandleValidationOnUpdateFail(ValidationResult result, IValidator<TUpdate> validator, TUpdate validatedObject)
    {
    }

    public virtual TPrimaryKeyUserModel? Insert(TInsert insert, IValidator<TInsert>? currentInsertValidator = null)
    {
        bool isValidInsert = ValidateInsert(insert, currentInsertValidator);

        TPrimaryKeyUserModel? output = null;

        if (isValidInsert)
        {
            output = _repository.Insert(insert);
        }

        return output;
    }

    public virtual void Update(TUpdate update, IValidator<TUpdate>? currentUpdateValidator = null)
    {
        bool isValidInsert = ValidateUpdate(update, currentUpdateValidator);

        if (isValidInsert)
        {
            _repository.Update(update);
        }
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
    public ServiceBase(TRepository repository,
        IValidator<TPrimaryKeyUserModel>? defaultModelValidator = null, IValidator<TPrimaryKeyUserDAO>? defaultDaoValidator = null)
    {
        _repository = repository;
        _defaultInsertValidator = defaultModelValidator;
        _defaultUpdateValidator = defaultDaoValidator;
    }

    private readonly TRepository _repository;
    private readonly IValidator<TPrimaryKeyUserModel>? _defaultInsertValidator;
    private readonly IValidator<TPrimaryKeyUserDAO>? _defaultUpdateValidator;

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