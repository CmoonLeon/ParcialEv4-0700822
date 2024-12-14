using ProyectoCapas.DAL;
namespace ProyectoCapas.BLL
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _repository.ObtenerTodos();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            var usuario = _repository.ObtenerPorId(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"No se encontró un usuario con ID {id}");
            }
            return usuario;
        }

        public void AgregarUsuario(Usuario usuario) => _repository.Agregar(usuario);

        public void ActualizarUsuario(Usuario usuario) => _repository.Actualizar(usuario);

        public void EliminarUsuario(int id) => _repository.Eliminar(id);
    }
}
