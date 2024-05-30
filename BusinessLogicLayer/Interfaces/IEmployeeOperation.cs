using DomainModelLayer.Views;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeOperation
    {
        EmployeeView StoreData(string employeeId, string firstName, string lastName, DateTime dateOfBirth, string email, DateTime joinDate, string location, string jobTitle, string department, string manager, string project);
        void Add(EmployeeView emp);
        List<EmployeeView> GetAllEmployees();
        List<EmployeeView> GetEmployee(string empId);
        void Update(EmployeeView emp);
        void Delete(string empId);
    }
}
