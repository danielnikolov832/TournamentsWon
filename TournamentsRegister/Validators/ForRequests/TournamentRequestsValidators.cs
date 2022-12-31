using FluentValidation;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Validators.ForRequests;

public class TournamentInsertValidator : AbstractValidator<TournamentInsert>
{
    public TournamentInsertValidator()
    {
        RuleFor(insert => insert.Name).NotNull().NotEmpty().Length(1, 300);
        RuleFor(insert => insert.Description).NotNull().NotEmpty().Length(1, 1000);
    }
}

public class TournamentUpdateValidator : AbstractValidator<TournamentUpdate>
{
    public TournamentUpdateValidator()
    {
        RuleFor(update => update.Name).NotNull().NotEmpty().Length(1, 300);
        RuleFor(update => update.Description).NotNull().NotEmpty().Length(1, 1000);
    }
}