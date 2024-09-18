using System.ComponentModel.DataAnnotations;

namespace TolstovIgorKt_31_21.Models
{
    public enum AcademicDegreeType
    {
        [Display(Name = "Кандидат наук")]
        ScienceCandidate,

        [Display(Name = "Доктор наук")]
        ScienceDoctor,
    }
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public AcademicDegreeType AcademicDegreeName { get; }
    }
}
