namespace WafiSolutionAssignment.Models
{
    public class EmployeeListModel
    {
        public EmployeeListModel()
        {
            EmployeeModels = new List<EmployeeModel>();
        }

        public IList<EmployeeModel> EmployeeModels { get; set; }
    }
}
