using Dls.Erp.Domain.Entity;

namespace Dls.Erp.Infraestructura.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
