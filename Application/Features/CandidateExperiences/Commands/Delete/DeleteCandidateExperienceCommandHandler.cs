using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Candidates.Commands.DeleteCandidateExperience
{
    public class DeleteCandidateExperienceCommandHandler : IRequestHandler<DeleteCandidateExperienceCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCandidateExperienceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var candidateExperience = await _unitOfWork.Repository<CandidateExperience>().GetByIdAsync(request.Id);
            if (candidateExperience == null)
            {
               
                throw new NotFoundException(nameof(CandidateExperience), request.Id);
            }
            _unitOfWork.Repository<CandidateExperience>().DeleteEntity(candidateExperience);

            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
