using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase, IProductoController
    {
        private IProducto _IFlujo;
        private ILogger<ProductoController> _logger;

        public ProductoController(IProducto iFlujo, ILogger<ProductoController> logger)
        {
            _IFlujo = iFlujo;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ProductoRequest producto)
        {
            var resultado = await _IFlujo.Agregar(producto);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, ProductoRequest producto)
        {
            if (!await VerificarProductoExiste(Id))
                return NotFound("El producto no existe");
            var resultado = await _IFlujo.Editar(Id, producto);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarProductoExiste(Id))
                return NotFound("El vehículo no existe");
            var resultado = await _IFlujo.Eliminar(Id);
            return NoContent();

        }

        public async Task<IActionResult> Obtener()
        {
            var resultado = await _IFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _IFlujo.Obtener(Id);
            return Ok(resultado);
        }

        private async Task<bool> VerificarProductoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _IFlujo.Obtener(Id);
            if (resultadoVehiculoExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
    }
}
