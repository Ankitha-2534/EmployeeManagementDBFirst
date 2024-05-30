using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace BusinessLogicLayer
{
    public class DropDownOperation : IDropDownOperation
    {
        private readonly IDropDown _dropDown;
        public DropDownOperation(IDropDown dropDown)
        {
            _dropDown = dropDown;
        }

        public Location GetLocation(string LocationName)
        {
            return _dropDown.GetLocation(LocationName);
        }
        public Manager GetManager(string ManagerName)
        {
            return _dropDown.GetManager(ManagerName);
        }
        public Project GetProject(string ProjectName)
        {
            return _dropDown.GetProject(ProjectName);
        }
        public Department GetDepartment(string DepartmentName)
        {
            return _dropDown.GetDepartment(DepartmentName);
        }
        public Department GetDepartmentById(int departmentId)
        {
            return _dropDown.GetDepartmentByID(departmentId);
        }

        public Location GetLocationById(int locationId)
        {
            return _dropDown.GetLocationByID(locationId);
        }
        public int GetRoleId(string DepartmentName, string LocationName)
        {
            return _dropDown.GetRoleId(DepartmentName, LocationName);
        }

        public string GetLocationFromId()
        {
            return _dropDown.GetLocationFromId();
        }

        public string GetDepartmentFromId()
        {
            return _dropDown.GetDepartmentFromId();
        }

        public List<Location> GetAllLocations()
        {
            return _dropDown.GetAllLocations();
        }

        public List<Manager> GetAllManagers()
        {
            return _dropDown.GetAllManagers();
        }

        public List<Project> GetAllProjects()
        {
            return _dropDown.GetAllProjects();
        }

        public List<Role> GetAllRoles()
        {
            return _dropDown.GetAllRoles();
        }

        public List<Department> GetAllDepartments()
        {
            return _dropDown.GetAllDepartments();
        }
    }
}
