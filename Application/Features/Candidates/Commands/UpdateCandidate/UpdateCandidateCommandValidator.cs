
using FluentValidation;

namespace Application.Features.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommandValidator :AbstractValidator<UpdateCandidateCommand>
    {
        public UpdateCandidateCommandValidator() {
            RuleFor(p => p.Name)
              .NotEmpty()
              .WithMessage("{Name} campo obligatorio")
              .NotNull()
              .MaximumLength(50).WithMessage("{Name} has max 50 characters");

            RuleFor(p => p.Surname)
                  .MaximumLength(150).WithMessage("{Surname} has max 150 characters");

            RuleFor(p => p.Email)
                   .MaximumLength(250).WithMessage("{Email} has max 250 characters");

        }
    }
}
