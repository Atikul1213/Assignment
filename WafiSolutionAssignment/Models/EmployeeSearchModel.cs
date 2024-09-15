namespace WafiSolutionAssignment.Models
{
    public class EmployeeSearchModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public int Start { get; set; }
        public int Length { get; set; }
    }
}
