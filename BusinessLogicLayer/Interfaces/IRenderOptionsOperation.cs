using DomainModelLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRenderOptionsOperation
    {
        Location GetLocation(string locationName);
        Manager GetManager(string managerName);
        Project GetProject(string projectName);
        Department GetDepartment(string departmentName);
        int GetRoleId(string departmentName, string locationName, string roleName);
        Department GetDepartmentById(int departmentId);
        Location GetLocationById(int locationId);
        List<Location> GetAllLocations();
        List<Manager> GetAllManagers();
        List<Project> GetAllProjects();
        List<Role> GetAllRoles(string department,string location);
        List<Department> GetAllDepartments(string location);
        List<Employee> GetAllIds();
        string GetDepartmentByRoleId(int roleId);
        string GetLocationByRoleId(int roleId);
        string GetRoleFromId(int id);
        Project GetProjectByID(int projectId);
        Manager GetManagerByID(int managerId);
    }
}
