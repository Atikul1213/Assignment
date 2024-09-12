using BookHub.Factories;
using BookHub.Services;
using Microsoft.AspNetCore.Mvc;
using WafiSolutionAssignment.Models;

namespace WafiSolutionAssignment.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployeeModelFactory _employeeModelFactory;
        public EmployeeController(IEmployeeService employeeService,
            IWebHostEnvironment webHostEnvironment,
            IEmployeeModelFactory employeeModelFactory
            )
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            _employeeModelFactory = employeeModelFactory;
        }


        public IActionResult Index()
        {
            var model = _employeeModelFactory.PrepareEmployeeListModel();
            return View(model);
        }


        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeModel employeeModel, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\employee");

                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    employeeModel.ImageUrl = @"\images\employee\" + fileName;
                }

                var entity = _employeeModelFactory.PrepareEmployee(employeeModel);

                _employeeService.AddEmployee(entity);

                TempData["success"] = "Created Successfully";

                return RedirectToAction("Index");
            }
            return View();

        }


    }
}
