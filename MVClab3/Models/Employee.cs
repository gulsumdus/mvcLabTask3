using System.ComponentModel.DataAnnotations;
namespace MVClab3.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MinLength(3, ErrorMessage = "Surname must be at least 3 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [MinLength(3, ErrorMessage = "Position must be at least 3 characters")]
        public string Position { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int CompanyId { get; set; }//FK

        public string? Image { get; set; } // Nullable

        //-------------------Navigation property------------------------
        public Company Company { get; set; } //1-M Rel.
        public SalaryInfo SalaryInfo { get; set; }//1-1 Rel.

    }
}
