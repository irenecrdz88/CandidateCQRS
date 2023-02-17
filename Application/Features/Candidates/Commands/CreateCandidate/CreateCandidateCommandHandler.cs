using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCandidateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = _mapper.Map<Candidate>(request);
            _unitOfWork.Repository<Candidate>().AddEntity(candidateEntity);

            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                throw new Exception($"No se pudo insertar el candidato");
            }

            return candidateEntity.Id;
        }
    }
}
