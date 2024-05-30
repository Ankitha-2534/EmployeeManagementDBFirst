using DomainModelLayer.Models;
using DomainModelLayer.Views;

namespace DataAccessLayer.Interfaces
{
    public interface IDataHandler
    {
        Employee MapEmployeeViewToEmployee(EmployeeView employeeView);
        EmployeeView GetAllEmployeeView(Employee employee);

    }
}
