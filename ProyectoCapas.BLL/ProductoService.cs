using ProyectoCapas.DAL;
namespace ProyectoCapas.BLL
{
    public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public List<Producto> ObtenerProductosDisponibles()
        {
            return _repository.obtenerTodos().Where(p => p.Stock > 0).ToList();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            var producto = _repository.ObtenerPorId(id);
            if(producto == null)
            {
                throw new KeyNotFoundException($"No se encontró un producto con ID {id}");
            }
            return producto;
        }

        public void AgregarProducto(Producto producto) => _repository.Agregar(producto);

        public void ActualizarProducto(Producto producto) => _repository.Actualizar(producto);

        public void EliminarProducto(int id) => _repository.Eliminar(id);
    }
}
