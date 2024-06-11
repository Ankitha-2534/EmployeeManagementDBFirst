using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace BusinessLogicLayer
{
    public class RenderOptionsOperation : IRenderOptionsOperation
    {
        private readonly IRenderOptions _renderOptions;
        public RenderOptionsOperation(IRenderOptions renderOptions)
        {
            _renderOptions = renderOptions;
        }

        public Location GetLocation(string locationName)
        {
            return _renderOptions.GetLocation(locationName);
        }
        public Manager GetManager(string managerName)
        {
            return _renderOptions.GetManager(managerName);
        }
        public Project GetProject(string projectName)
        {
            return _renderOptions.GetProject(projectName);
        }
        public Department GetDepartment(string departmentName)
        {
            return _renderOptions.GetDepartment(departmentName);
        }
        public Department GetDepartmentById(int departmentId)
        {
            return _renderOptions.GetDepartmentByID(departmentId);
        }

        public Location GetLocationById(int locationId)
        {
            return _renderOptions.GetLocationByID(locationId);
        }
        public int GetRoleId(string departmentName, string locationName, string roleName)
        {
            return _renderOptions.GetRoleId(departmentName, locationName, roleName);
        }

        public List<Location> GetAllLocations()
        {
            return _renderOptions.GetAllLocations();
        }

        public List<Manager> GetAllManagers()
        {
            return _renderOptions.GetAllManagers();
        }

        public List<Project> GetAllProjects()
        {
            return _renderOptions.GetAllProjects();
        }

        public List<Role> GetAllRoles(string department,string location)
        {
            return _renderOptions.GetAllRoles(department,location);
        }

        public List<Department> GetAllDepartments(string location)
        {
            return _renderOptions.GetAllDepartments(location);
        }

        public List<Employee> GetAllIds()
        {
            return _renderOptions.GetAllIds();
        }

        public string GetDepartmentByRoleId(int roleId)
        {
            return _renderOptions.GetDepartmentByRoleId(roleId);
        }

        public string GetLocationByRoleId(int roleId)
        {
            return _renderOptions.GetLocationByRoleId(roleId);
        }

        public string GetRoleFromId(int id)
        {
            return _renderOptions.GetRoleFromId(id);
        }

        public Project GetProjectByID(int projectId)
        {
            return _renderOptions.GetProjectByID(projectId);
        }

        public Manager GetManagerByID(int managerId)
        {
            return _renderOptions.GetManagerByID(managerId);
        }
    }
}
