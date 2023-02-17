using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using System.IO;

namespace Application.Features.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCandidateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = await _unitOfWork.Repository<Candidate>().GetByIdAsync(request.Id);

            if (candidateEntity == null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            _mapper.Map(request, candidateEntity, typeof(UpdateCandidateCommand), typeof(Candidate));

            _unitOfWork.Repository<Candidate>().UpdateEntity(candidateEntity);

            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
