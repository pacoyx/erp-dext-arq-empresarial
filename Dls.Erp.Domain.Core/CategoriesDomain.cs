using Dls.Erp.Domain.Entity;
using Dls.Erp.Domain.Interface;
using Dls.Erp.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dls.Erp.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }
    }
}
