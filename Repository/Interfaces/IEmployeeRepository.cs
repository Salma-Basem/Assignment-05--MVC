using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface  IEmployeeRepository:IGenericRepository<EmployeeViewModel>
    {
        IEnumerable<EmployeeViewModel> GetEmployeeByName(string name);
     IEnumerable<EmployeeViewModel> GetEmployeeByAddress(string address);

    }
}
