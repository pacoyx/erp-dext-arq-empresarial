using Dls.Erp.Domain.Entity;
using Dls.Erp.Domain.Interface;
using Dls.Erp.Infraestructura.Interface;

namespace Dls.Erp.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region metodos sincronos
        public bool Insert(Customers customers)
        {
            return _unitOfWork.Customers.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _unitOfWork.Customers.Update(customers);
        }

        public bool Delete(string customersId)
        {
            return _unitOfWork.Customers.Delete(customersId);
        }

        public Customers Get(string customersId)
        {
            return _unitOfWork.Customers.Get(customersId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
        }

        public int Count()
        {
            return _unitOfWork.Customers.Count();
        }

        #endregion

        #region metodos Asyncronos
        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _unitOfWork.Customers.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _unitOfWork.Customers.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customersId)
        {
            return await _unitOfWork.Customers.DeleteAsync(customersId);
        }

        public async Task<Customers> GetAsync(string customersId)
        {
            return await _unitOfWork.Customers.GetAsync(customersId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

       

        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Customers.CountAsync();
        }

        #endregion

    }
}
