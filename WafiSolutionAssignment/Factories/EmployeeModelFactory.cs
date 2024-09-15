using BookHub.Services;
using WafiSolutionAssignment.Domain;
using WafiSolutionAssignment.Models;

namespace BookHub.Factories
{
    public class EmployeeModelFactory : IEmployeeModelFactory
    {
        #region Fields

        private readonly IEmployeeService _employeeService;

        #endregion

        #region Ctor
        public EmployeeModelFactory(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion


        #region Methods
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
            model.FullName = employee.FullName;
            return model;
        }


        public EmployeeListModel PrepareEmployeeListModel(EmployeeSearchModel searchModel)
        {

            var name = searchModel.Name;
            var dob = searchModel.DateOfBirth;
            var email = searchModel.Email;
            var mobile = searchModel.MobileNumber;

            var employees = _employeeService.GetAllEmployees();

            if (name != null)
                employees = employees.Where(x => x.FullName.Contains(name)).ToList();

            if (dob != DateTime.MinValue)
                employees = employees.Where(x => x.DateOfBirth == dob).ToList();

            if (email != null)
                employees = employees.Where(x => x.Email == email).ToList();

            if (mobile != null)
                employees = employees.Where(x => x.MobileNumber == mobile).ToList();

            EmployeeListModel employeeListModel = new EmployeeListModel();

            if (employees.Count() == 0)
                return employeeListModel;
            employees = employees.Skip(searchModel.Start).Take(searchModel.Length).ToList();

            foreach (var employee in employees)
            {
                var model = PrepareEmployeeModel(employee);
                model.Id = employee.Id;
                model.DateOfBirth.ToString("yyyy-MM-dd");
                employeeListModel.EmployeeModel.Add(model);
            }

            return employeeListModel;
        }

        public Employee PrepareEmployee(EmployeeModel model)
        {
            var entity = new Employee();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.FullName = model.FirstName + " " + model.LastName;
            entity.Email = model.Email;
            entity.MobileNumber = model.MobileNumber;
            entity.ImageUrl = model.ImageUrl;
            entity.DateOfBirth = model.DateOfBirth;


            return entity;
        }


        #endregion
    }
}
