using System.ComponentModel.DataAnnotations;

namespace HR_MS.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
