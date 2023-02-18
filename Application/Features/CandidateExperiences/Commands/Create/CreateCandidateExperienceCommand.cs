using Application.Features.Candidates.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.CandidateExperiences.Commands.Create
{
    public class CreateCandidateExperienceCommand :IRequest<int>
    {
        public int IdCandidate { get;  set; }
        public string Company { get;  set; }
        public string Job { get;  set; }
        public string Description { get;  set; }
        public decimal Salary { get;  set; }
        public DateTime BeginDate { get;  set; }
        public DateTime? EndDate { get;  set; }


        public CreateCandidateExperienceCommand(CandidateExperiencesVm exp)
        {
            IdCandidate = exp.IdCandidate;
            Company = exp.Company;
            Job = exp.Job;
            Description = exp.Description;
            Salary = exp.Salary;
            BeginDate = exp.BeginDate;
            EndDate = exp.EndDate;
        }
    }
}
