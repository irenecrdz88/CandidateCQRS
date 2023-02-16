using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Candidates.Queries
{
    public class CandidatesVm
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<CandidateExperience>? CandidateExperiences { get; set; }
    }
}
