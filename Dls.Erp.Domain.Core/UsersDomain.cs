using Dls.Erp.Domain.Entity;
using Dls.Erp.Domain.Interface;
using Dls.Erp.Infraestructura.Interface;

namespace Dls.Erp.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);    
        }
    }
}
