using BookHub.Factories;
using BookHub.Services;
using Microsoft.AspNetCore.Mvc;
using WafiSolutionAssignment.Models;

namespace WafiSolutionAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields

        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployeeModelFactory _employeeModelFactory;

        #endregion

        #region Ctor
        public EmployeeController(IEmployeeService employeeService,
            IWebHostEnvironment webHostEnvironment,
            IEmployeeModelFactory employeeModelFactory
            )
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            _employeeModelFactory = employeeModelFactory;
        }

        #endregion


        #region Index GetAll Create Edit Delete

        public IActionResult Index()
        {

            return View(new EmployeeSearchModel());
        }



        [HttpPost]
        public IActionResult GetAll(EmployeeSearchModel searchModel)
        {

            var employees = _employeeModelFactory.PrepareEmployeeListModel(searchModel);

            return Json(new { data = employees.EmployeeModel });
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



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();

            var model = _employeeModelFactory.PrepareEmployeeModel(employee);

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(EmployeeModel employeeModel, IFormFile? file)
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

                entity.Id = employeeModel.Id;
                _employeeService.UpdateEmployee(entity);

                TempData["success"] = "Edited Successfully";

                return RedirectToAction("Index");
            }

            return View();
        }






        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();
            var model = _employeeModelFactory.PrepareEmployeeModel(employee);

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            if (id == null || id == 0)
                return NotFound();


            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();

            _employeeService.DeleteEmployee(employee);

            TempData["success"] = "Delete Successfully";

            return RedirectToAction("Index");
        }

        #endregion

    }

}
