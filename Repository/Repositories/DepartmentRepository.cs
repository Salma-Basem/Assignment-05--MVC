using Data.Contexts;
using Data.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepository(CompanyDbContext context) : base(context)
        {
            {
                _context = context;
            }

        }
    }
}