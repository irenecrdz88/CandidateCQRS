using Application.Features.CandidateExperiences.Commands.Update;
using FluentValidation;

namespace Application.Features.CandidateExperiences.Commands.Create
{

    public class UpdateCandidateExperienceCommandValidator : AbstractValidator<UpdateCandidateExperienceCommand>
    {
        public UpdateCandidateExperienceCommandValidator()
        {
            RuleFor(p => p.Job)
                    .NotEmpty()
                    .WithMessage("{Job} campo obligatorio")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{Job} has max 100 characters");

            RuleFor(p => p.Company)
                    .NotEmpty()
                    .WithMessage("{Company} campo obligatorio")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{Company} has max 100 characters");

            RuleFor(p => p.Description)
                    .NotEmpty()
                    .WithMessage("{Description} campo obligatorio")
                    .NotNull()
                    .MaximumLength(4000).WithMessage("{Description} has max 4000 characters");

            RuleFor(c => c.BeginDate)
                    .NotEmpty().WithMessage("{BeginDate} campo obligatorio");
        }

    }
}
