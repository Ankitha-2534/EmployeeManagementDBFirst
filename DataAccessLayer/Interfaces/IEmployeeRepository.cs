using DomainModelLayer.Views;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeView emp);
        List<EmployeeView> GetAllEmployees();
        List<EmployeeView> GetEmployee(string empId);
        void Update(EmployeeView emp);
        void Delete(string empId);

    }
}
