using System.ComponentModel.DataAnnotations;

namespace HR_MS.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string DepartmentID { get; set; }


        [Required]
        public string DepartmentName { get; set; }
    }
}
