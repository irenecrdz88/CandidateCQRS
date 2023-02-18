using Application.Features.Candidates.Commands.CreateCandidate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CandidateExperiences.Commands.Create
{

    public class CreateCandidateExperienceCommandValidator : AbstractValidator<CreateCandidateExperienceCommand>
    {
        public CreateCandidateExperienceCommandValidator()
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
