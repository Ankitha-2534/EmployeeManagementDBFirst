using DomainModelLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IDropDown
    {
        Location GetLocation(string LocationName);
        Manager GetManager(string ManagerName);
        Project GetProject(string ProjectName);
        Department GetDepartment(string DepartmentName);
        int GetRoleId(string DepartmentName, string LocationName);
        string GetLocationFromId();
        string GetDepartmentFromId();
        string GetRoleFromId(int Id);
        Manager GetManagerByID(int managerId);
        Project GetProjectByID(int projectId);
        Department GetDepartmentByID(int departmentId);
        Location GetLocationByID(int locationId);
        List<Location> GetAllLocations();
        List<Manager> GetAllManagers();
        List<Project> GetAllProjects();
        List<Role> GetAllRoles();
        List<Department> GetAllDepartments();
    }
}
