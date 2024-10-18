using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Tests
{
    public class DepartmentTests
    {
        [Fact]
        public void IsValidDepartmentEstablishment_True()
        {
            //arrange
            var testDepartment = new Department
            {
                DepartmentEstablishment = new DateOnly(2000, 11, 02)
            };

            //act
            var result = testDepartment.IsValidDepartmentEstablishment();

            //assert
            Assert.True(result);
        }
    }
}