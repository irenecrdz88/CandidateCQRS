using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Application.Features.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCandidateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateToDelete = await _unitOfWork.Repository<Candidate>().GetByIdAsync(request.Id);
            if (candidateToDelete == null)
            {
               
                throw new NotFoundException(nameof(Candidate), request.Id);
            }
            _unitOfWork.Repository<Candidate>().DeleteEntity(candidateToDelete);

            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
