using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;
using DomainModelLayer.Views;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDataHandler _dataHandler;        
        private readonly IDropDown _dropDown;

        public EmployeeRepository(IDataHandler dataHandler, IDropDown dropDown)
        {
            _dataHandler = dataHandler;
            _dropDown = dropDown;
        }

        public void Add(EmployeeView emp)
        {
            using (var context = new EmployeeManagementContext())
            {
                try
                {
                    var employee = _dataHandler.MapEmployeeViewToEmployee(emp);
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public List<EmployeeView> GetAllEmployees()
        {

            using (var context = new EmployeeManagementContext())
            {
                return context.Employees.Select(e => _dataHandler.GetAllEmployeeView(e)).ToList();
            }
        }

        public List<EmployeeView> GetEmployee(string empId)
        {
            using (var context = new EmployeeManagementContext())
            {
                var employees = context.Employees
                    .Where(e => e.Uid == empId)
                    .ToList();

                return employees.Select(e => _dataHandler.GetAllEmployeeView(e)).ToList();
            }
        }       

        public void Update(EmployeeView emp)
        {
            using (var context = new EmployeeManagementContext())
            {
                var existingEmployee = context.Employees.SingleOrDefault(e => e.Uid == emp.Uid);

                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = emp.FirstName;
                    existingEmployee.LastName = emp.LastName;
                    existingEmployee.DateOfBirth = emp.DateOfBirth;
                    existingEmployee.Email = emp.Email;
                    existingEmployee.MobileNumber = emp.MobileNumber;
                    existingEmployee.JoinDate = emp.JoinDate;
                    existingEmployee.RoleId = _dropDown.GetRoleId(emp.Department, emp.Location);
                    existingEmployee.ManagerId = _dropDown.GetManager(emp.Manager).Id;
                    existingEmployee.ProjectId = _dropDown.GetProject(emp.Project).Id;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Employee not found");
                }
            }
        }

        public void Delete(string empId)
        {
            using (var context = new EmployeeManagementContext())
            {
                var emp = context.Employees.SingleOrDefault(e => e.Uid == empId);
                if (emp != null)
                {
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                    Console.WriteLine("Employee deleted successfully");
                }
                else
                {
                    Console.WriteLine("No employee is found with the ID you provided.");
                }
            }
        }
    }
}

