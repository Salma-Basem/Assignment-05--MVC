using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Interfaces.Department.Dto;
using Service.Services;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            TempData.Keep("TextTempMessage");
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    TempData["TextTempMessage"] = "Hello From employee index(TempData)";
  
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");

                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError",ex.Message);
                return View(department);
            }

        }
   
        public IActionResult Details(int? id,string viewName="Details")
        {
            var department = _departmentService.GetById(id);
            if(department is null)
                return RedirectToAction("NotFoundPage",null,"Home"); 
            return View(viewName,department);
        }

        public IActionResult Update(int? id, DepartmentDto department)
        {
            if(department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));

        }

        
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
