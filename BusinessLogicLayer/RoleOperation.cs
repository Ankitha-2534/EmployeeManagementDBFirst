using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DomainModelLayer.Models;

namespace BusinessLogicLayer
{
    public class RoleOperation:IRoleOperation
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IDropDown _dropDown;
        public RoleOperation(IRoleRepository roleRepository,IDropDown dropDown)
        {
            _roleRepository = roleRepository;
            _dropDown = dropDown;
        }

        public Role StoreData(string roleName, string department, string description, string location)
        {
            Role role = new Role()
            {
                RoleName = roleName,
                DepartmentId = _dropDown.GetDepartment(department)?.Id,
                Description = description,
                LocationId = _dropDown.GetLocation(location)?.Id

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
