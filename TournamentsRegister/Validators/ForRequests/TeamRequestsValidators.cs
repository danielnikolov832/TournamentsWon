using FluentValidation;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Validators.ForRequests;

public class TeamInsertValidator : AbstractValidator<TeamMiddleModelInsert>
{
    public TeamInsertValidator()
    {
        RuleFor(insert => insert.Name).NotNull().NotEmpty().MaximumLength(300);

        RuleForEach(insert => insert.PlayerNames).NotEmpty().MaximumLength(300);
    }
}

public class TeamUpdateValidator : AbstractValidator<TeamUpdate>
{
    public TeamUpdateValidator()
    {
        RuleFor(update => update.Name).NotNull().NotEmpty().MaximumLength(300);

        RuleForEach(update => update.NewPlayersNames).NotEmpty().MaximumLength(300);
        RuleForEach(update => update.RemovedPlayersNames).NotEmpty().MaximumLength(300);
    }
}