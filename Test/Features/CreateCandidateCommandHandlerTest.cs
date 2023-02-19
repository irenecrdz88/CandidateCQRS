using Application.Features.Candidates.Commands.CreateCandidate;
using Application.Features.Candidates.Queries;
using Application.Mappings;
using AutoMapper;
using CleanArchitecture.Application.UnitTests.Mock;
using Infraestructure.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Mocks;
using Xunit;

namespace Test.Features
{
    public class CreateCandidateCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateCandidateCommandHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            MockCandidateRepository.AddDataCandidateRepository(_unitOfWork.Object.CandidateDbContext);
        }

        [Fact]
        public void Handle_Should_ReturnFailureResult_WhenNameIsNotGiven()
        {
            CandidatesVm cand = new CandidatesVm() {
                Surname = "Skywalker",
                Email = "luke_skywalker@gmail.com",
                BirthDate = new DateTime(1000, 04, 12)
            };
            var command = new CreateCandidateCommand(cand);
            var handler = new CreateCandidateCommandHandler(_mapper, _unitOfWork.Object);
            var result = handler.Handle(command, CancellationToken.None);
           
            result.IsFaulted.ShouldBeTrue();
        }


        [Fact]
        public void Handle_Should_ReturnNumber()
        {
            CandidatesVm cand = new CandidatesVm()
            {
                Name = "Luke",
                Surname = "Skywalker",
                Email = "luke_skywalker@gmail.com",
                BirthDate = new DateTime(1000, 04, 12)
            };
            var command = new CreateCandidateCommand(cand);
            var handler = new CreateCandidateCommandHandler(_mapper, _unitOfWork.Object);
            var result = handler.Handle(command, CancellationToken.None);

            result.IsCompletedSuccessfully.ShouldBeTrue();
        }
    }
}
