using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Mocks
{

    public static class MockCandidateRepository
    {
        public static void AddDataCandidateRepository(CandidateDbContext candidateDbContextFake)
        {
            List<Candidate> candidates = new List<Candidate> {
                new Candidate("Irene", "Carchano", "irenecrdz@gmail.com", new DateTime(1988, 01, 23)),
                new Candidate("Marta", "Rio", "rioga@gmail.com", new DateTime(1981, 01, 22)),
                new Candidate("Gerard", "Pique", "pique@gmail.com", new DateTime(1987, 02, 22)),
            };
            candidateDbContextFake.Candidates!.AddRange(candidates);
            candidateDbContextFake.SaveChanges();

        }
    }
}
