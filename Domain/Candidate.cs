namespace Domain
{
    public class Candidate: BaseDomainModel
    {
        public string Name { get; private set; }    
        public string Surname { get; private set; }    
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public virtual ICollection<CandidateExperience>? CandidateExperiences { get; set; }

        public Candidate(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }
    }
}