using Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Candidates.Queries
{
    public class CandidatesVm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [MaxLength(150)]
        [DisplayName("Apellido")]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(250)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Fecha Nacim.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime BirthDate { get; set; }

        public ICollection<CandidateExperience>? CandidateExperiences { get; set; }
    }
}
