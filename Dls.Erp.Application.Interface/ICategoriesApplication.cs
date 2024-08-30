using Dls.Erp.Application.DTO;
using Dls.Erp.Transversal.Common;

namespace Dls.Erp.Application.Interface
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategoriesDto>>> GetAll();
    }
}
