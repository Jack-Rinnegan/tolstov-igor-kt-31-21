namespace TolstovIgorKt_31_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }

        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
