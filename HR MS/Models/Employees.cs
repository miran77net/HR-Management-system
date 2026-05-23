using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR_MS.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
       
        public string Department { get; set; }

        public DateTime Joiningdate { get; set; }


    }
}