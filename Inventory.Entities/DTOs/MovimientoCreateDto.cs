using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class MovimientoCreateDto
    {
        public DateTime Fecha { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public string Concepto { get; set; }
        public string Estado { get; set; }
        public int TipoDeMovimiento { get; set; }
    }
}
