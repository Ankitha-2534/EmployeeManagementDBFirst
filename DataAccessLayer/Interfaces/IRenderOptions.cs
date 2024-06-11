using DomainModelLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRenderOptions
    {
        Location GetLocation(string locationName);
        Manager GetManager(string managerName);
        Project GetProject(string projectName);
        Department GetDepartment(string departmentName);
        int GetRoleId(string departmentName, string locationName, string roleName);
        string GetRoleFromId(int Id);
        Manager GetManagerByID(int managerId);
        Project GetProjectByID(int projectId);
        Department GetDepartmentByID(int departmentId);
        Location GetLocationByID(int locationId);
        List<Location> GetAllLocations();
        List<Manager> GetAllManagers();
        List<Project> GetAllProjects();
        List<Role> GetAllRoles(string department,string location);
        List<Department> GetAllDepartments(string location);
        List<Employee> GetAllIds();
        string GetDepartmentByRoleId(int roleId);
        string GetLocationByRoleId(int roleId);

    }
}
