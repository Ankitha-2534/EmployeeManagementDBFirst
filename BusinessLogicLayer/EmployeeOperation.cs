using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Views;

namespace BusinessLogicLayer
{
    public class EmployeeOperation : IEmployeeOperation
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeOperation(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public EmployeeView StoreData(string employeeId, string firstName, string lastName, DateTime dateOfBirth, string email, DateTime joinDate, string location, string jobTitle, string department, string manager, string project)
        {
            EmployeeView employeeView = new EmployeeView()
            {
                Uid = employeeId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                JoinDate = joinDate,
                Location = location,
                JobTitle = jobTitle,
                Department = department,
                Manager = manager,
                Project = project
            };
            return employeeView;
        }
        public void Add(EmployeeView emp)
        {
            _employeeRepo.Add(emp);
        }

        public List<EmployeeView> GetAllEmployees()
        {
            return _employeeRepo.GetAllEmployees();
        }

        public List<EmployeeView> GetEmployee(string empId)
        {
            return _employeeRepo.GetEmployee(empId);
        }

        public void Update(EmployeeView emp)
        {
            _employeeRepo.Update(emp);
        }

        public void Delete(string empId)
        {
            _employeeRepo.Delete(empId);
        }
    }
}
