using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Features.CandidateExperiences
{
    public class CandidateExperiencesVm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCandidate { get; set; }

        [MaxLength(100)]
        [Required]
        [DisplayName("Company")]
        public string Company { get; set; }

        [MaxLength(100)]
        [DisplayName("Job")]
        [Required]
        public string Job { get; set; }

        [MaxLength(4000)]
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Salary")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Begin Date")]
        public DateTime BeginDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}
