using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Department : BaseEntity
    {
        [DisplayName("DepartmentName")]
        public string Name { get; set; }
        public string? Code { get; set; }

        public ICollection<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
