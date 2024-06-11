using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;
using DomainModelLayer.Views;

namespace DataAccessLayer
{
    public class DataHandler : IDataHandler
    {
        private readonly IRenderOptions _renderOptions;
        public DataHandler(IRenderOptions renderOptions)
        {
            _renderOptions = renderOptions;
        }

        public Employee MapEmployeeViewToEmployee(EmployeeView employeeView)
        {
            Employee employee = new Employee();
            
            if(employeeView.Uid != null)
            {
                employee.Uid = employeeView.Uid;
            }
            if(employeeView.FirstName != null )
            {
                employee.FirstName = employeeView.FirstName;
            }
            if(employeeView.LastName != null )
            {
                employee.LastName = employeeView.LastName;
            }
            if(employeeView.DateOfBirth != null)
            {
                employee.DateOfBirth = employeeView.DateOfBirth;
            }
            if(employeeView.Email != null )
            {
                employee.Email = employeeView.Email;
            }
            if(employeeView.MobileNumber != null)
            {
                employee.MobileNumber = employeeView.MobileNumber;
            }
            if(employeeView.JoinDate != null)
            {
                employee.JoinDate = employeeView.JoinDate;
            }
            if(employeeView.Department != null && employeeView.JobTitle != null && employeeView.Location != null)
            {
                employee.RoleId = _renderOptions.GetRoleId(employeeView.Department, employeeView.Location!, employeeView.JobTitle);
            }
            if (employeeView.Manager != null)
            {
                var manager = _renderOptions.GetManager(employeeView.Manager);
                if (manager != null)
                {
                    employee.ManagerId = manager.Id;
                }
            }
            if (employeeView.Project != null)
            {
                var project = _renderOptions.GetProject(employeeView.Project);
                if (project != null)
                {
                    employee.ProjectId = project.Id;
                }
            }

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
                Location = _renderOptions.GetLocationByRoleId(employee.RoleId!.Value),
                Department = _renderOptions.GetDepartmentByRoleId(employee.RoleId!.Value),
                JobTitle = _renderOptions.GetRoleFromId(employee.RoleId!.Value),
                Manager = _renderOptions.GetManagerByID((int)employee.ManagerId!)?.Name,
                Project = _renderOptions.GetProjectByID((int)employee.ProjectId!)?.Name
            };
            return employeeView;
        }
    }
}
