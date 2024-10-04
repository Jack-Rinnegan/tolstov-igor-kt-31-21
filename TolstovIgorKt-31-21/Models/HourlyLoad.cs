namespace TolstovIgorKt_31_21.Models
{
    public class HourlyLoad
    {
        public int HourlyLoadId { get; set; }
        public int Hours { get; set; }


        public int? LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? DisciplinId { get; set; }
        public Disciplin Disciplin { get; set; }
    }
}
