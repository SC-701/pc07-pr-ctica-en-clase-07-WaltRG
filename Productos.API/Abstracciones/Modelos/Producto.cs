using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        [RegularExpression(
           @"^[A-Za-zÁÉÍÓÚáéíóúÑñ]{1,200}$",
           ErrorMessage = "La propiedad solo debe contener letras y tener entre 1 y 200 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad Descripcion es requerida")]
        [StringLength(200, ErrorMessage = "La propiedad Descripcion debe ser mayor a 4 caracteres y menor a 40", MinimumLength = 5)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La propiedad Precio es requerida")]
        [RegularExpression(
            @"^[0-9]+$",
            ErrorMessage = "La propiedad solo debe contener números")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La propiedad Stock es requerida")]
        [RegularExpression(
            @"^[0-9]+$",
            ErrorMessage = "La propiedad solo debe contener números")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La propiedad CodigoBarras es requerida")]
        [RegularExpression(
            @"^[0-9]+$",
            ErrorMessage = "La propiedad solo debe contener números")]
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string SubCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
