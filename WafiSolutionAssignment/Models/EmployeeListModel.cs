namespace WafiSolutionAssignment.Models
{
    public class EmployeeListModel
    {
        public EmployeeListModel()
        {
            EmployeeModel = new List<EmployeeModel>();
        }

        public IList<EmployeeModel> EmployeeModel { get; set; }
    }
}
