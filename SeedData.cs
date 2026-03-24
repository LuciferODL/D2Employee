using D2Employee.Models;

namespace D2Employee.Data
{
    public class SeedData
    {
        //Simulation of seeding data to the database
        public static List<Employee>Employees = new List<Employee>()
        {
            new Employee()
            {
                EmployeeId = 1,
                Name = "John Doe",
                BirthDate = new DateTime(1990, 5, 15),
                Salary = 50000,
                Position = "Software Engineer",
                Experience = "5 years"
            },
            new Employee()
            {
                EmployeeId = 2,
                Name = "Jane Smith",
                BirthDate = new DateTime(1985, 8, 20),
                Salary = 60000,
                Position = "Project Manager",
                Experience = "10 years"
            },
            new Employee()
            {
                EmployeeId = 3,
                Name = "Alice Johnson",
                BirthDate = new DateTime(1992, 3, 10),
                Salary = 45000,
                Position = "QA Engineer",
                Experience = "3 years"
            }
        };  
    }
}
