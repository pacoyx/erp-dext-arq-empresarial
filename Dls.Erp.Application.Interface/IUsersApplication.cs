using Dls.Erp.Application.DTO;
using Dls.Erp.Transversal.Common;

namespace Dls.Erp.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
