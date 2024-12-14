using Microsoft.AspNetCore.Mvc;
using ProyectoCapas.BLL;

namespace ProyectoCapas.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioService.ObtenerUsuarios();
            return View(usuarios);
        }

        public IActionResult Detalle(int id)
        {
            var usuario = _usuarioService.ObtenerUsuarioPorId(id);
            return View(usuario);
        }
    }
}
