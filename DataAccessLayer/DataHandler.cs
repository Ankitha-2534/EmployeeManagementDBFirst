using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;
using DomainModelLayer.Views;

namespace DataAccessLayer
{
    public class DataHandler:IDataHandler
    {
        private readonly IDropDown _dropDown;
        public DataHandler(IDropDown dropDown)
        {
            _dropDown = dropDown;
        }

        public Employee MapEmployeeViewToEmployee(EmployeeView employeeView)
        {
            Employee employee = new Employee
            {
                Uid = employeeView.Uid,
                FirstName = employeeView.FirstName,
                LastName = employeeView.LastName,
                DateOfBirth = employeeView.DateOfBirth,
                Email = employeeView.Email,
                MobileNumber = employeeView.MobileNumber,
                JoinDate = employeeView.JoinDate,
                RoleId = _dropDown.GetRoleId(employeeView.Department!, employeeView.Location!),
                ManagerId = _dropDown.GetManager(employeeView.Manager!).Id,
                ProjectId = _dropDown.GetProject(employeeView.Project!).Id
            };
            return employee;
        }

        public EmployeeView GetAllEmployeeView(Employee employee)
        {
            EmployeeView employeeView = new EmployeeView
            {
                Uid = employee.Uid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                JoinDate = employee.JoinDate,
                JobTitle = _dropDown.GetRoleFromId((int)employee.RoleId!),
                Location = _dropDown.GetLocationFromId(),
                Department = _dropDown.GetDepartmentFromId(),
                Manager = _dropDown.GetManagerByID((int)employee.ManagerId!)?.Name,
                Project = _dropDown.GetProjectByID((int)employee.ProjectId!)?.Name
            };
            return employeeView;
        }
    }
}
