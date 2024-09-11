using CrudDapper.Dto;
using CrudDapper.Models;

namespace CrudDapper.Services
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
        Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId); 
    }
}
