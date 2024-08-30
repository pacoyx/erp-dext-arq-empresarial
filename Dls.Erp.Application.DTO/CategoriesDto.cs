using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dls.Erp.Application.DTO
{
    public class CategoriesDto
    {
        public int CatgeoriesID { get; set; }
        public string Categoryname { get; set; }
        public string Descripcion { get; set; }
        public byte[] Picture { get; set; }
    }
}
