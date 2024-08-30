using AutoMapper;
using Dls.Erp.Application.DTO;
using Dls.Erp.Domain.Entity;

namespace Dls.Erp.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Categories, CategoriesDto>().ReverseMap();
        }
    }
}
