using Microsoft.AspNetCore.Http;
using Service.Interfaces.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Employee.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public String Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName    { get; set; }
        public DateTime CreatedAt { get; set; }

        public DepartmentDto Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
