using Backend.Core.Modell.Entities;
using FluentValidation;

namespace Backend.Validation
{
    public class PlayerValidation : AbstractValidator<Player>
    {
        public PlayerValidation()
        {
            RuleFor(x => x.Id).NotEmpty()
                              .NotNull()
                              .GreaterThan(0).WithMessage("Nem megfelelő az objektum azonosítójja!");

            RuleFor(x => x.Birthday).NotEmpty()
                                    .NotNull();

            RuleFor(x => x.BirthPlace).NotEmpty()
                                      .NotNull();

            RuleFor(x => x.Club).NotEmpty()
                                .NotNull();

            RuleFor(x => x.Description).NotEmpty()
                                       .NotNull();

            RuleFor(x => x.Height).NotEmpty()
                                  .NotNull()
                                  .GreaterThan(0);

            RuleFor(x => x.Weight).NotEmpty()
                                  .NotNull()
                                  .GreaterThan(0);

            RuleFor(x => x.ImageLink).NotEmpty()
                                     .NotNull()
                                     .Must(CustomValidators.ValidateUri).WithMessage("Nem valós URL adott meg!");
        }
    }
}
