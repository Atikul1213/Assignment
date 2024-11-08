﻿using WafiSolutionAssignment.Domain;

namespace BookHub.Services
{
    public interface IEmployeeService
    {

        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
