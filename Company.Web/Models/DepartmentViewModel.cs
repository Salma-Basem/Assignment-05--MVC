using Data.Entities;

namespace Web.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public DateTime CreatedAt { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();

    }
}
