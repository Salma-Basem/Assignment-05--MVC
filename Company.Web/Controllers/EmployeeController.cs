using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Interfaces.Employee.Dto;
using Service.Services;

namespace Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
         //   ViewBag.Message = "Hello From employee index(ViewBag)";
         //   ViewData["TextMessage"] = "Hello From employee index(ViewData)";
         //   TempData["TextTempMessage"] = "Hello From employee index(TempData)";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
            {
                 employees = _employeeService.GetAll();
               
            }
            else
            {
                 employees = _employeeService.GetEmployeeByName(searchInp);
              
            }

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Departments = _departmentService.GetAll() ;
            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return View(employee);
            }

        }
    }
}
