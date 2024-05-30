using DomainModelLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDropDownOperation
    {
        Location GetLocation(string LocationName);
        Manager GetManager(string ManagerName);
        Project GetProject(string ProjectName);
        Department GetDepartment(string DepartmentName);
        int GetRoleId(string DepartmentName, string LocationName);
        string GetLocationFromId();
        string GetDepartmentFromId();
        Department GetDepartmentById(int departmentId);
        Location GetLocationById(int locationId);
        List<Location> GetAllLocations();
        List<Manager> GetAllManagers();
        List<Project> GetAllProjects();
        List<Role> GetAllRoles();
        List<Department> GetAllDepartments();
    }
}
