using BookHub.Repository;
using WafiSolutionAssignment.Domain;

namespace BookHub.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.Getall();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.Get(c => c.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {

            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.Get(c => c.Id == id);
            _employeeRepository.Remove(employee);
        }
    }
}
