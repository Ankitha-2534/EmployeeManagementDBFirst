using DomainModelLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleOperation
    {
        Role StoreData(string roleName, string department, string description, string location);
        void Add(Role role);
        List<Role> GetAllRoles();
    }
}
