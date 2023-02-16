namespace Domain
{
    public class Candidate: BaseDomainModel
    {
        public string? Name { get; private set; }    
        public string? Surname { get; private set; }    
        public string? Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public virtual ICollection<CandidateExperience>? CandidateExperiences { get; set; }
    }
}