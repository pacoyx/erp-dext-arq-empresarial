using AutoMapper;
using Dls.Erp.Application.DTO;
using Dls.Erp.Application.Interface;
using Dls.Erp.Application.Validator;
using Dls.Erp.Domain.Interface;
using Dls.Erp.Transversal.Common;

namespace Dls.Erp.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _usersDtoValidator;
        public UsersApplication(IUsersDomain usersDomain, IMapper IMapper, UserDtoValidator usersDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = IMapper;
            _usersDtoValidator = usersDtoValidator;
        }
        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            var validation = _usersDtoValidator.Validate(new UsersDTO() { Password = password , UserName = username});
            if(!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess= false;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;                
            }
            return response;
        }
    }
}
