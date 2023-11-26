using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVClab3.Models
{
    public class Company //principal Entity
    {
   
        public int Id { get; set; } // Unique key

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } // Minimum length 3 characters, maximum 100 characters

        [Required]
        [StringLength(5)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Zipcode must contain only digits")]
        public string Zipcode { get; set; } // Cannot be null, exactly 5 characters, only digits allowed

        [StringLength(50)]
        public string City { get; set; } // Maximum length is 50

        [StringLength(60)]
        public string Country { get; set; } // Maximum length is 60


        //-------------------Navigation property------------------------
         public ICollection<Employee> Employees { get; set; }

    }
}
