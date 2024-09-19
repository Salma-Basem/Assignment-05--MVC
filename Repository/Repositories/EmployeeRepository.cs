﻿using Data.Contexts;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeViewModel> ,IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context):base(context)  
        {
           _context = context;
        }

        public IEnumerable<EmployeeViewModel> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeViewModel> GetEmployeeByName(string name)

            => _context.Employees.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();
        
    }
}
