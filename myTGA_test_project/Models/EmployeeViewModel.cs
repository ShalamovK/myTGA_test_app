namespace myTGA_test_project.Models {
    public class EmployeeViewModel : BaseEntityViewModel<int> {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NameFormatted => $"{FirstName} {LastName}";
    }
}
