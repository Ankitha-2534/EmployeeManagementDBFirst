using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace DataAccessLayer
{
    public class DropDown: IDropDown
    {
        private readonly EmployeeManagementContext _context;
        public DropDown(EmployeeManagementContext context)
        {
            _context = context;
        }
        public Location GetLocation(string LocationName)
        {
            return _context.Locations.FirstOrDefault(e => e.Name == LocationName)!;
        }
        public Manager GetManager(string ManagerName)
        {
            return _context.Managers.FirstOrDefault(e => e.Name == ManagerName)!;
        }
        public Project GetProject(string ProjectName)
        {
            return _context.Projects.FirstOrDefault(e => e.Name == ProjectName)!;
        }
        public Department GetDepartment(string DepartmentName)
        {
            return _context.Departments.FirstOrDefault(e => e.Name == DepartmentName)!;
        }

        public Department GetDepartmentByID(int departmentId)
        {
            return _context.Departments.FirstOrDefault(e => e.Id == departmentId)!;
        }

        public Location GetLocationByID(int locationId)
        {
            return _context.Locations.FirstOrDefault(e => e.Id == locationId)!;
        }

        public Manager GetManagerByID(int managerId)
        {
            return _context.Managers.FirstOrDefault(e => e.Id == managerId)!;
        }

        public Project GetProjectByID(int projectId)
        {
            return _context.Projects.FirstOrDefault(e => e.Id == projectId)!;
        }

        public int GetRoleId(string departmentName, string locationName)
        {
            int idLocation = _context.Locations.SingleOrDefault(e => (e.Name == locationName)).Id;
            int idDepartment = _context.Departments.SingleOrDefault(e => (e.Name == departmentName)).Id;
            return _context.Roles.FirstOrDefault(e => e.LocationId == idLocation && e.DepartmentId == idDepartment).RoleId;
        }

        public string GetRoleFromId(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == id);
            return role?.RoleName!;
        }

        public string GetLocationFromId()
        {
            return _context.Locations.FirstOrDefault(e => (_context.Roles.Any(d => d.LocationId == e.Id))).Name;
        }

        public string GetDepartmentFromId()
        {
            return _context.Departments.FirstOrDefault(e => (_context.Roles.Any(d => d.DepartmentId == e.Id))).Name;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }
        public List<Manager> GetAllManagers()
        {
            return _context.Managers.ToList();
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

    }
}
