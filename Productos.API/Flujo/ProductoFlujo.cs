using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ProductoFlujo : IProducto
    {
        private IDA _IDA;

        public ProductoFlujo(IDA iDA)
        {
            _IDA = iDA;
        }

        public Task<Guid> Agregar(ProductoRequest producto)
        {
            return _IDA.Agregar(producto);
        }

        public Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return _IDA.Editar(Id, producto);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _IDA.Eliminar(Id);
        }

        public Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return _IDA.Obtener();
        }

        public Task<ProductoResponse> Obtener(Guid Id)
        {
            return _IDA.Obtener(Id);
        }
    }
}
