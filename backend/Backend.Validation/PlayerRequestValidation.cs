using Backend.Core.Modell.Request;
using FluentValidation;

namespace Backend.Validation
{
    public class PlayerRequestValidation : AbstractValidator<PlayerRequest>
    {
        public PlayerRequestValidation()
        {
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

            RuleFor(x => x.Position).NotEmpty()
                                    .NotNull();

            RuleFor(x => x.ImageLink).NotEmpty()
                                     .NotNull()
                                     .Must(CustomValidators.ValidateUri).WithMessage("Nem valós URL adott meg!");
        }
    }
}
