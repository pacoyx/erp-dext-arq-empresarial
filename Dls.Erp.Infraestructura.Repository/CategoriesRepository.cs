using Dapper;
using Dls.Erp.Domain.Entity;
using Dls.Erp.Infraestructura.Data;
using Dls.Erp.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dls.Erp.Infraestructura.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * from Categories";
            var categories = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
            return categories;
        }
    }
}
