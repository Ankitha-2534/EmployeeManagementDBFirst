using System.Data.Entity;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace DataAccessLayer
{
    public class RoleRepository:IRoleRepository
    {
        private readonly EmployeeManagementContext _context;
        public RoleRepository(EmployeeManagementContext context)
        {
            _context = context;
        }

        public void Add(Role role)
        {
            using (var context = new EmployeeManagementContext())
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }
        }

        public List<Role> GetAllRoles()
        {
            using (var context = new EmployeeManagementContext())
            {
                return _context.Roles
                .Include(e => e.Location)
                .Include(e => e.Department)
                .Select(e => e)
                .ToList();
            }
        }
    }
}
