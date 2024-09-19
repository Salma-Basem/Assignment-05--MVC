using AutoMapper;
using Data.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Interfaces.Employee.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Reflection.Metadata;


namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
       

        public void Add(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address=employeeDto.Address,
            //    Age=employeeDto.Age,
            //    DepartmentId=employeeDto.DepartmentId,
            //    Email= employeeDto.Email,
            //    HiringDate=employeeDto.HiringDate,
            //    Name= employeeDto.Name


            //};
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image,"Images");
            Employee employee= _mapper.Map<EmployeeDto>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

       
        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name


            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }




        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Address = x.Address,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Salary = x.Salary,
            //    ImageUrl = x.ImageUrl,
            //    PhoneNumber = x.PhoneNumber,
            //    Id = x.Id

            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }
      
        public void Update(EmployeeDto employee)
        {
            //_unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }

        IEnumerable<EmployeeDto> IEmployeeService.GetAll()
        {
           var employees= _unitOfWork.EmployeeRepository.GetAll();

            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{ 
            //DepartmentId=x.DepartmentId,
            //Name=x.Name,
            //Address=x.Address,
            //Email=x.Email,
            //HiringDate=x.HiringDate,
            //Salary=x.Salary,
            //ImageUrl=x.ImageUrl,
            //PhoneNumber=x.PhoneNumber,
            //Id=x.Id
            
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        EmployeeDto IEmployeeService.GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name
            //};
            EmployeeDto employee1 = _mapper.Map<EmployeeDto>(employee);
            return employee1;
        }

    }
}
