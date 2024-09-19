using AutoMapper;
using Data.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Interfaces.Department.Dto;
using Service.Interfaces.Employee.Dto;

namespace Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{ 
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreatedAt = DateTime.Now,
            //};
            var mappedDepartment = _mapper.Map<DepartmentDto>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<DepartmentDto>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(departmentDto);
            _unitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            IEnumerable<DepartmentDto> mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

           
            return mappedDepartments; 
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is  null)
                return null;

            var mappedDepartment = _mapper.Map<DepartmentDto>(department);

            return mappedDepartment;
        }

        public void Update(DepartmentDto department)
        {
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();

        }



    }

}
