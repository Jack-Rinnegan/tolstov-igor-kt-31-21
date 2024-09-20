namespace TolstovIgorKt_31_21.Models
{
    public class Disciplin
    {
        public int DisciplinId { get; set; }
        public string DisciplinName { get; set; }

        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
