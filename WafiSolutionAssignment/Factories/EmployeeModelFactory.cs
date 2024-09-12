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
            model.Name = category.Name;
            model.Id = category.Id;
            return model;
        }


        public EmployeeListModel PrepareEmployeeListModel()
        {

            return _employeeService.GetAllEmployees()
                  .Select(emp => new EmployeeModel { Name = cat.Name, Id = cat.Id })
                  .ToList();

        }





    }
}
