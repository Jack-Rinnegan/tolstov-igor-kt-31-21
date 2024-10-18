using System.ComponentModel.DataAnnotations;

namespace TolstovIgorKt_31_21.Models
{
    public enum PositionNameType
    {
        [Display(Name = "Преподаватель")]
        Lecturer,

        [Display(Name = "Старший преподаватель")]
        HeadLecturer,

        [Display(Name = "Доцент")]
        Docent,

        [Display(Name = "Профессор")]
        Professor,
    }

    public class Position
    {
        public int PositionId { get; set; }
        public PositionNameType PositionName { get; set; }
    }
}
