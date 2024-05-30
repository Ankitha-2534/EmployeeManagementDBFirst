using DomainModelLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository
    {
        void Add(Role role);
        List<Role> GetAllRoles();
    }
}
