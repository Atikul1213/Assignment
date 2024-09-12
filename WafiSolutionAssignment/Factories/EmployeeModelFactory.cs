using BookHub.Services;
using WafiSolutionAssignment.Domain;
using WafiSolutionAssignment.Models;

namespace BookHub.Factories
{
    public class EmployeeModelFactory : IEmployeeModelFactory
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeModelFactory(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        public EmployeeModel PrepareEmployeeModel(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException();

            EmployeeModel model = new EmployeeModel();
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.Email = employee.Email;
            model.MobileNumber = employee.MobileNumber;
            model.ImageUrl = employee.ImageUrl;
            model.DateOfBirth = employee.DateOfBirth;
            return model;
        }


        public EmployeeListModel PrepareEmployeeListModel()
        {

            var employees = _employeeService.GetAllEmployees();
            EmployeeListModel employeeListModel = new EmployeeListModel();

            foreach (var employee in employees)
            {
                var model = PrepareEmployeeModel(employee);
                employeeListModel.EmployeeModel.Add(model);
            }

            return employeeListModel;
        }

        public Employee PrepareEmployee(EmployeeModel model)
        {
            var entity = new Employee();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.MobileNumber = model.MobileNumber;
            entity.ImageUrl = model.ImageUrl;
            entity.DateOfBirth = model.DateOfBirth;

            return entity;
        }
    }
}
