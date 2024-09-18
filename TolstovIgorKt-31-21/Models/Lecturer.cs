namespace TolstovIgorKt_31_21.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public int PositionId { get; set; }
        public Position Position {  get; set; }
        public List<Disciplin> Disciplines { get; set; } = new List<Disciplin>();
        public int HourlyLoadId { get; set; }
        public HourlyLoad HourlyLoad { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
