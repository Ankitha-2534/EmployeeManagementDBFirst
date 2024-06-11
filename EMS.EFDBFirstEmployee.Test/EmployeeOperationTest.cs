using BusinessLogicLayer;
using DataAccessLayer;
using DomainModelLayer.Models;
using DomainModelLayer.Views;

namespace EMS.EFDBFirstEmployee.Test
{
    public class UnitTest1
    {
        [Fact]
        public void EmployeeOperation_ADD_WhenSuccess()
        {
            var _context = new EmployeeManagementContext();
            var _renderOptions = new RenderOptions(_context);
            var _renderOptionsOperation = new RenderOptionsOperation(_renderOptions);
            var _dataHandler = new DataHandler(_renderOptions);
            var _employeeRepo = new EmployeeRepository(_dataHandler, _renderOptions);
            //var _employeeValidation = new EmployeeValidation(_renderOptionsOperation);
            var _employeeOperation = new EmployeeOperation(_employeeRepo);
            //var _roleValidation = new RoleValidation(_renderOptionsOperation);
            //var _employeeUi = new EmployeeUI(_employeeValidation, _employeeOperation, _renderOptionsOperation);
            EmployeeView employeeToBeAdded = new EmployeeView()
            {
                 Uid="TZ0023",
                 FirstName="xyz",
                 LastName="abc",
                 DateOfBirth=new DateTime(2000,12,05),
                 Email="xyz@gmail.com",
                 MobileNumber="7878787878",
                 JoinDate=new DateTime(2023,11,11),
                 Department="Product Engineering",
                 JobTitle="Developer",
                 Location="Hyderabad",
                 Manager="qwert",
                 Project="tyui"
            };
            var _roleRepository = new RoleRepository(_context);
            _employeeOperation.Add(employeeToBeAdded);
            Assert.NotNull(employeeToBeAdded);
        }
    }
}