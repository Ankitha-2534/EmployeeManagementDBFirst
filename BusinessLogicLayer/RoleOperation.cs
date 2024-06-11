using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace BusinessLogicLayer
{
    public class RoleOperation:IRoleOperation
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRenderOptions _renderOptions;
        public RoleOperation(IRoleRepository roleRepository,IRenderOptions renderOptions)
        {
            _roleRepository = roleRepository;
            _renderOptions = renderOptions;
        }

        public Role StoreData(string roleName, string department, string description, string location)
        {
            Role role = new Role()
            {
                RoleName = roleName,
                DepartmentId = _renderOptions.GetDepartment(department)?.Id,
                Description = description,
                LocationId = _renderOptions.GetLocation(location)?.Id

            };
            return role;
        }
        public void Add(Role role)
        {
            _roleRepository.Add(role);
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
    }
}
