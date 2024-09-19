using Data.Entities;

namespace Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public String Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public DepartmentViewModel Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
