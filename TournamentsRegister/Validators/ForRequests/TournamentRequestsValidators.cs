using FluentValidation;
using TournamentsRegister.Constants;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Validators.ForRequests;

public class TournamentInsertValidator : AbstractValidator<TournamentInsert>
{
    public TournamentInsertValidator()
    {
        RuleFor(insert => insert.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentNameMaxLength);
        RuleFor(insert => insert.Description).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentDescriptionMaxLength);
    }
}

public class TournamentUpdateValidator : AbstractValidator<TournamentUpdate>
{
    public TournamentUpdateValidator()
    {
        RuleFor(insert => insert.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentNameMaxLength);
        RuleFor(insert => insert.Description).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentDescriptionMaxLength);
    }
}