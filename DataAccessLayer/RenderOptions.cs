using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace DataAccessLayer
{
    public class RenderOptions : IRenderOptions
    {
        private readonly EmployeeManagementContext _context;
        public RenderOptions(EmployeeManagementContext context)
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

        public int GetRoleId(string departmentName, string locationName, string roleName)
        {
            var location = _context.Locations.SingleOrDefault(e => (e.Name == locationName));
            int idLocation = 0;
            if (location is not null)
            {
                idLocation = location.Id;
            }
            var department = _context.Departments.SingleOrDefault(e => (e.Name == departmentName));
            int idDepartment = 0;
            if (department is not null)
            {
                idDepartment = department.Id;
            }             
            return _context.Roles.FirstOrDefault(e => e.LocationId == idLocation && e.DepartmentId == idDepartment && e.RoleName==roleName).RoleId;
        }

        public string GetRoleFromId(int roleid)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleid);
            Console.WriteLine(role?.RoleName);
            return role?.RoleName;
        }

        public string GetDepartmentByRoleId(int roleId)
        {
            //var role = _context.Roles.FirstOrDefault(d => d.RoleId == roleId);
            //return role.Department.Name;
           // return _context.Departments.FirstOrDefault(_ => _.Id == role.DepartmentId).Name;
            return _context.Departments.FirstOrDefault(e => (_context.Roles.Any(d => d.DepartmentId == e.Id && d.RoleId == roleId))).Name;
        }

        public string GetLocationByRoleId(int roleId)
        {
            //var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
            //return role.Location.Name;
            // return _context.Departments.FirstOrDefault(_ => _.Id == role.DepartmentId).Name;
            return _context.Locations.FirstOrDefault(l => (_context.Roles.Any(r => r.LocationId == l.Id && r.RoleId == roleId))).Name;
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

        public List<Role> GetAllRoles(string department, string location)
        {
            int idDepartment = _context.Departments.SingleOrDefault(e => (e.Name == department)).Id;
            int idLocation = _context.Locations.SingleOrDefault(e => (e.Name == location)).Id;
            var roles = _context.Roles.Where(r => r.DepartmentId == idDepartment && r.LocationId == idLocation).ToList();
            return roles;
        }


        public List<Department> GetAllDepartments(string location)
        {
            int idLocation = _context.Locations.SingleOrDefault(e => (e.Name == location)).Id;
            var departmentIds = _context.Roles.Where(r => r.LocationId == idLocation).Select(r => r.DepartmentId).ToList();
            return _context.Departments.Where(d => departmentIds.Contains(d.Id)).ToList();
        }

        public List<Employee> GetAllIds()
        {
            return _context.Employees.ToList();
        }

    }
}
