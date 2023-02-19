namespace Domain
{
    public class CandidateExperience : BaseDomainModel
    {
        public int IdCandidate { get; set; }
        public string Company { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public double Salary { get; private set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Candidate? Candidate { get; set; }   

        public CandidateExperience(int idCandidate, string company, string job, string description, double salary, DateTime beginDate, DateTime? endDate)
        {
            IdCandidate = idCandidate;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
