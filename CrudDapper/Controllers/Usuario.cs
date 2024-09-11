using CrudDapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public Usuario(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();

            if(usuarios.Situacao == false)
            {
                return NotFound(usuarios);
            }

            return Ok(usuarios);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int usuarioId)
        {
            var usuarios = await _usuarioInterface.BuscarUsuarioPorId(usuarioId);

            if (usuarios.Situacao == false)
            {
                return NotFound(usuarios);
            }

            return Ok(usuarios);
        }
    }
}
