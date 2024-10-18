using System.Text.RegularExpressions;

namespace TolstovIgorKt_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateOnly DepartmentEstablishment {  get; set; }

        public bool IsValidDepartmentEstablishment()
        {
            return DepartmentEstablishment >= new DateOnly(1900, 01, 01);
        }
    }
}
