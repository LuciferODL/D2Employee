using System.ComponentModel.DataAnnotations;
namespace D2Employee.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(0.1,100000000)]
        public int Salary { get; set; }
        public string? Position { get; set; }
        public string? Experience { get; set; }
        
    }
}
