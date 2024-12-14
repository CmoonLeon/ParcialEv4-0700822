using ProyectoCapas.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCapas.DAL
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public List<Usuario> ObtenerTodos()
        {
            return _context.Usuarios.ToList();
        }
        public Usuario ObtenerPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
        public void Actualizar(Usuario usuario)
        {
            var existente = ObtenerPorId(usuario.Id);
            if (existente != null)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
        }

        public void Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var usuario = ObtenerPorId(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

    }
}
