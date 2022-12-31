using FluentValidation;
using Mapster;
using System.ComponentModel.DataAnnotations;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Validators.ForRequests;

public class TeamInsertValidator : AbstractValidator<TeamInsert>
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