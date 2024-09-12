using WafiSolutionAssignment.Domain;
using WafiSolutionAssignment.Models;

namespace BookHub.Factories
{
    public interface IEmployeeModelFactory
    {
        EmployeeModel PrepareEmployeeModel(Employee employee);

        Employee PrepareEmployee(EmployeeModel model);
        EmployeeListModel PrepareEmployeeListModel();
    }
}
