using ProyectoCapas.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCapas.DAL
{
    public class ProductoRepositorio : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public List<Producto> obtenerTodos()
        {
            return _context.Productos.ToList();
        }
        public Producto ObtenerPorId(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }
        public void Actualizar(Producto producto)
        {
            var existente = ObtenerPorId(producto.Id);
            if (existente != null)
            {
                _context.Productos.Update(existente);
                _context.SaveChanges();
            }
        }

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null) {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }

    }
}
