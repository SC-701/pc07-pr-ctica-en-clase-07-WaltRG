using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ProductoDA : IDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ProductoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(ProductoRequest Producto)
        {
            string query = @"AgregarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Guid.NewGuid(),
                CodigoBarras = Producto.CodigoBarras,
                Nombre = Producto.Nombre,
                Descripcion = Producto.Descripcion,
                Stock = Producto.Stock,
                Precio = Producto.Precio,
            
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest Producto)
        {
            await verficarProductoExiste(Id);
            string query = @"EditarProducto";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                CodigoBarras = Producto.CodigoBarras,
                Nombre = Producto.Nombre,
                Descripcion = Producto.Descripcion,
                Stock = Producto.Stock,
                Precio = Producto.Precio,

            }); return resultadoConsulta;
        }


        public async Task<Guid> Eliminar(Guid Id)
        {
            await verficarProductoExiste(Id);
            string query = @"EliminarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            string query = @"ObtenerProductos";

            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query);
            return resultadoConsulta;
        }
        public async Task<ProductoResponse> Obtener(Guid Id)
        {

            string query = @"ObtenerProducto";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query,
            new { });
            return resultadoConsulta.FirstOrDefault();
        }

        private async Task verficarProductoExiste(Guid Id)
        {
            ProductoResponse? resultadoConsultaProducto = await Obtener(Id);
            if (resultadoConsultaProducto == null)
                throw new Exception("No se encontro el Producto");

        }

    }
}
